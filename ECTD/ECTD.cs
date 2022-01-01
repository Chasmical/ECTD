using BepInEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using RogueLibsCore;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace ECTD
{
    [BepInPlugin(GUID, Name, Version)]
    [BepInDependency(RogueLibs.GUID, RogueLibs.CompiledVersion)]
    public class ECTDPlugin : BaseUnityPlugin
    {
        public const string GUID = "abbysssal.streetsofrogue.ectd3";
        public const string Name = "ECTD";
        public const string Version = "3.0.0";

        private const int infinityNumber = 7654321;
        private const string infinityString = "∞";
        private static string configPath;
        public static bool NoMessages;

        public void Start()
        {
            configPath = Path.Combine(Paths.ConfigPath, "ectd-nomessages.cfg");
            NoMessages = File.Exists(configPath);
            StartCoroutine(CheckingConfig());

            RoguePatcher patcher = new RoguePatcher(this);
            patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.SaveCharacter));
            patcher.Prefix(typeof(AgentHitbox), nameof(AgentHitbox.GetColorFromString));

            patcher.Prefix(typeof(InvItem), nameof(InvItem.SetupDetails));
            patcher.Prefix(typeof(InvDatabase), nameof(InvDatabase.AddItemPlayerStart));
            patcher.Prefix(typeof(InvDatabase), nameof(InvDatabase.SubtractFromItemCount), nameof(InvDatabase_SubtractFromItemCount),
                           new Type[] { typeof(int), typeof(int), typeof(bool) });
            patcher.Prefix(typeof(InvDatabase), nameof(InvDatabase.SubtractFromItemCount), nameof(InvDatabase_SubtractFromItemCount2),
                           new Type[] { typeof(InvItem), typeof(int), typeof(bool) });

            const string replaceCounts = nameof(ReplaceCounts);

            patcher.Transpiler(typeof(CharacterSelect), nameof(CharacterSelect.SetupSlotAgent), replaceCounts);
            patcher.Transpiler(typeof(InvSlot), nameof(InvSlot.UpdateInvSlot), replaceCounts);
            patcher.Transpiler(typeof(CharacterCreation), nameof(CharacterCreation.CreatePointTallyText), replaceCounts);
            patcher.Transpiler(typeof(WeaponSelectImage), nameof(WeaponSelectImage.UpdateWeaponSelectImage), replaceCounts);
            patcher.Transpiler(typeof(WeaponSlot), "Update", replaceCounts);
            patcher.Transpiler(typeof(EquippedItemSlot), nameof(EquippedItemSlot.LateUpdateEquippedItemSlot), replaceCounts);
            patcher.Transpiler(typeof(InvItem), nameof(InvItem.ShowPickingUpText), replaceCounts);
        }
        private static IEnumerator CheckingConfig()
        {
            while (true)
            {
                NoMessages = File.Exists(configPath);
                yield return new WaitForSecondsRealtime(5f);
            }
        }

        public static void CharacterCreation_SaveCharacter(CharacterCreation __instance)
        {
            CharacterCreation cc = __instance;

            foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\+\\+(.+)", RegexOptions.ECMAScript))
            {
                string itemId = match.Groups[1].Value;
                cc.itemsChosen.Add(new Unlock(itemId, "Item", true));
                cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, NoMessages ? string.Empty : $"[Item '{itemId}' added]");
            }
            foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\-\\-(.+)", RegexOptions.ECMAScript))
            {
                string itemId = match.Groups[1].Value.ToLower();
                int index = cc.itemsChosen.FindIndex(item => item.unlockName.ToLower() == itemId);
                if (index != -1)
                {
                    cc.itemsChosen.RemoveAt(index);
                    cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, NoMessages ? string.Empty : $"[Item '{itemId}' removed]");
                }
            }
            foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\*\\*(.+)", RegexOptions.ECMAScript))
            {
                string traitId = match.Groups[1].Value;
                cc.traitsChosen.Add(new Unlock(traitId, "Trait", true));
                cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, NoMessages ? string.Empty : $"[Trait '{traitId}' added]");
            }
            foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\/\\/(.+)", RegexOptions.ECMAScript))
            {
                string traitId = match.Groups[1].Value;
                int index = cc.traitsChosen.FindIndex(item => item.unlockName == traitId);
                if (index != -1)
                {
                    cc.traitsChosen.RemoveAt(index);
                    cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, NoMessages ? string.Empty : $"[Trait '{traitId}' removed]");
                }
            }
            foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\!\\!items", RegexOptions.ECMAScript))
            {
                List<string> items = new List<string>();
                foreach (Unlock unlock in cc.itemsChosen)
                    items.Add(unlock.unlockName);
                string txtList = "[" + string.Join(", ", items.ToArray()) + "]";
                cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, txtList);
            }
            foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\!\\!traits", RegexOptions.ECMAScript))
            {
                List<string> traits = new List<string>();
                foreach (Unlock unlock in cc.traitsChosen)
                    traits.Add(unlock.unlockName);
                string txtList = "[" + string.Join(", ", traits.ToArray()) + "]";
                cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, txtList);
            }
            foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\^\\^(Strength|Endurance|Accuracy|Speed|Str|End|Acc|Spd)\\=([0-9-]+)", RegexOptions.ECMAScript))
            {
                string statId = match.Groups[1].Value;
                if (int.TryParse(match.Groups[2].Value, out int value))
                {
                    cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, NoMessages ? string.Empty : $"['{statId}' set to '{value}']");
                    if (statId == "Strength" || statId == "Str")
                        cc.strength = value - 1;
                    else if (statId == "Endurance" || statId == "End")
                        cc.endurance = value - 1;
                    else if (statId == "Accuracy" || statId == "Acc")
                        cc.accuracy = value - 1;
                    else if (statId == "Speed" || statId == "Spd")
                        cc.speed = value - 1;
                }
            }
            foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\%\\%(.+)", RegexOptions.ECMAScript))
            {
                string abilityId = match.Groups[1].Value;
                cc.abilityChosen = abilityId;
                cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, NoMessages ? string.Empty : $"[Ability set to '{abilityId}']");
            }
            foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\:\\:(Skin|Hair|Legs|Body|Eyes)(\\=.+)?", RegexOptions.ECMAScript))
            {
                string partId = match.Groups[1].Value;
                if (match.Groups[2].Success)
                {
                    string colorId = match.Groups[2].Value.Substring(1);
                    if (match.Groups[2].Value.IndexOfAny(new char[] { '-', '.', '|', ':', '_', ',', ';' }) != -1)
                        colorId = ":" + colorId;
                    if (partId == "Skin") cc.skinColor = colorId;
                    else if (partId == "Hair") cc.hairColor = colorId;
                    else if (partId == "Legs") cc.legsColor = colorId;
                    else if (partId == "Body") cc.bodyColor = colorId;
                    else if (partId == "Eyes") cc.eyesColor = colorId;
                    if (colorId.StartsWith(":", StringComparison.Ordinal)) colorId = colorId.Substring(1);
                    cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, NoMessages ? string.Empty : $"[Color of '{partId}' set to '{colorId}']");
                }
                else
                {
                    string curColor = "???";
                    if (partId == "Skin") curColor = cc.skinColor;
                    else if (partId == "Hair") curColor = cc.hairColor;
                    else if (partId == "Legs") curColor = cc.legsColor;
                    else if (partId == "Body") curColor = cc.bodyColor;
                    else if (partId == "Eyes") curColor = cc.eyesColor;
                    if (curColor.StartsWith(":", StringComparison.Ordinal)) curColor = curColor.Substring(1);
                    cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, NoMessages ? string.Empty : $"[Color of '{partId}' is '{curColor}']");
                }
            }
            cc.descriptionChosen = cc.descriptionChosen.Trim();

        }
        public static bool AgentHitbox_GetColorFromString(AgentHitbox __instance, string colorChoice, string bodyPart)
        {
            AgentHitbox ah = __instance;
            Color32 color = Color.white;
            bool isCustom = true;
            switch (colorChoice)
            {
                case "Clear":
                    color = AgentHitbox.skinClear;
                    break;
                default:
                    isCustom = false;
                    break;
            }
            if (colorChoice.StartsWith(":", StringComparison.Ordinal))
            {
                color = new Color32(0, 0, 0, 255);
                isCustom = true;
                string[] split = colorChoice.Substring(1).Split('-', '.', '|', ':', '_', ',', ';');
                if (split.Length >= 1 && int.TryParse(split[0], out int red))
                    color.r = (byte)Mathf.Clamp(red, 0, 255);
                if (split.Length >= 2 && int.TryParse(split[1], out int green))
                    color.g = (byte)Mathf.Clamp(green, 0, 255);
                if (split.Length >= 3 && int.TryParse(split[2], out int blue))
                    color.b = (byte)Mathf.Clamp(blue, 0, 255);
                if (split.Length >= 4 && int.TryParse(split[3], out int aaa))
                    color.a = (byte)Mathf.Clamp(aaa, 0, 255);
            }
            if (!isCustom) return true;
            if (bodyPart == "Skin") ah.skinColor = color;
            else if (bodyPart == "Hair") ah.hairColor = color;
            else if (bodyPart == "Legs") ah.legsColor = color;
            else if (bodyPart == "Body") ah.bodyColor = color;
            else if (bodyPart == "Eyes") ah.eyesColor = color;
            return false;
        }

        private static bool DoTheNumber(ref string itemName, ref int itemCount)
        {
            if (itemName == null) return false;
            int index = itemName.IndexOf('+');
            if (index != -1)
            {
                string numStr = itemName.Substring(index + 1);
                if (string.Equals(numStr, "INF", StringComparison.InvariantCultureIgnoreCase)
                 || string.Equals(numStr, "INFINITE", StringComparison.InvariantCultureIgnoreCase)
                 || string.Equals(numStr, "INFINITY", StringComparison.InvariantCultureIgnoreCase))
                {
                    itemName = itemName.Substring(0, index);
                    itemCount = infinityNumber;
                    return true;
                }
                else if (int.TryParse(numStr, out int count))
                {
                    itemName = itemName.Substring(0, index);
                    itemCount = count;
                    return true;
                }
            }
            return false;
        }

        public static void InvItem_SetupDetails(InvItem __instance)
        {
            if (DoTheNumber(ref __instance.invItemName, ref __instance.invItemCount))
                __instance.rewardCount = __instance.invItemCount;
        }
        public static void InvDatabase_AddItemPlayerStart(ref string itemName, ref int itemCount)
            => DoTheNumber(ref itemName, ref itemCount);
        public static bool InvDatabase_SubtractFromItemCount(InvDatabase __instance, int slotNum)
            => __instance.InvItemList[slotNum].invItemCount != infinityNumber;
        public static bool InvDatabase_SubtractFromItemCount2(InvItem invItem)
            => invItem.invItemCount != infinityNumber;

        private static IEnumerable<CodeInstruction> ReplaceCounts(IEnumerable<CodeInstruction> originalCode)
        {
            FieldInfo invItemCountField = AccessTools.Field(typeof(InvItem), nameof(InvItem.invItemCount));
            MethodInfo intToStringMethod = AccessTools.Method(typeof(int), nameof(int.ToString), Type.EmptyTypes);
            MethodInfo overrideMethod = AccessTools.Method(typeof(ECTDPlugin), nameof(OverrideToString));

            List<CodeInstruction> code = originalCode.ToList();
            for (int i = 0; i < code.Count - 1; i++)
            {
                CodeInstruction current = code[i];
                CodeInstruction next = code[i + 1];
                if (current.opcode == OpCodes.Ldflda && next.opcode == OpCodes.Call
                                                     && (FieldInfo)current.operand == invItemCountField
                                                     && (MethodInfo)next.operand == intToStringMethod)
                {
                    code.RemoveRange(i, 2);
                    code.Insert(i, new CodeInstruction(OpCodes.Call, overrideMethod));
                    i--;
                }
                else if (current.opcode == OpCodes.Ldfld && next.opcode == OpCodes.Box
                                                         && (FieldInfo)current.operand == invItemCountField)
                {
                    code.RemoveRange(i, 2);
                    code.Insert(i, new CodeInstruction(OpCodes.Call, overrideMethod));
                    i--;
                }
            }
            return code;
        }
        private static string OverrideToString(InvItem item)
            => item.invItemCount == infinityNumber ? infinityString : item.invItemCount.ToString();

    }
}
