using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ECTD
{
	[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
	public class ECTDPlugin : BaseUnityPlugin
	{
		public const string pluginGuid = "abbysssal.streetsofrogue.ectd";
		public const string pluginName = "ECTD";
		public const string pluginVersion = "2.7";

		public Dictionary<int, int> nuggetsDictionary;
		public string nuggetsPath = Path.Combine(Paths.ManagedPath, "znuggets_big.cfg");

		public Harmony harmony;

		public void PrefixAndLog(Type type, string methodName, Type[] types = null, int extra = 0)
		{
			try
			{
				MethodInfo original = AccessTools.Method(type, methodName, types);
				string patchName = type.Name + "_" + methodName;
				if (extra != 0) patchName += extra;
				MethodInfo patch = AccessTools.Method(typeof(ECTDPatches), patchName);
				harmony.Patch(original, new HarmonyMethod(patch));
				Logger.LogInfo(type.Name + "." + methodName + "(..) patched.");
			}
			catch (Exception e)
			{
				Logger.LogError(type.Name + "." + methodName + "(..) patch failed!");
				Logger.LogError(e);
			}
		}
		public void PostfixAndLog(Type type, string methodName, Type[] types = null)
		{
			try
			{
				MethodInfo original = AccessTools.Method(type, methodName, types);
				MethodInfo patch = AccessTools.Method(typeof(ECTDPatches), type.Name + "_" + methodName);
				harmony.Patch(original, null, new HarmonyMethod(patch));
				Logger.LogInfo(type.Name + "." + methodName + "(..) patched.");
			}
			catch (Exception e)
			{
				Logger.LogError(type.Name + "." + methodName + "(..) patch failed!");
				Logger.LogError(e);
			}
		}
		public void LoadConfigFile()
		{
			try
			{
				nuggetsDictionary = new Dictionary<int, int>();
				if (!File.Exists(nuggetsPath))
					File.WriteAllText(nuggetsPath, "1:-1\n2:-1\n3:-1\n4:-1\n5:-1");
				string data = File.ReadAllText(nuggetsPath);
				string[] lines = data.Split('\n');
				foreach (string line in lines)
				{
					string[] parts = line.Split(':');
					if (parts.Length != 2) return;
					if (!int.TryParse(parts[0], out int slot) || !int.TryParse(parts[1], out int nuggets))
						return;
					nuggetsDictionary.Add(slot, nuggets);
				}
			}
			catch (Exception e)
			{
				Logger.LogError("Error parsing " + nuggetsPath + "!");
				Logger.LogError(e);
			}

			SessionDataBig session = GameController.gameController.sessionDataBig;
			if (session == null)
			{
				Logger.LogWarning("Could not read sessionDataBig!");
				return;
			}

			if (!nuggetsDictionary.ContainsKey(session.saveSlot))
				nuggetsDictionary.Add(session.saveSlot, session.nuggets);
			int ectdNuggets = nuggetsDictionary[session.saveSlot];
			if (session.nuggets == 99 && ectdNuggets > 99)
				session.nuggets = ectdNuggets;
			else if (session.nuggets != ectdNuggets)
				if (ectdNuggets != -1)
					session.nuggets = nuggetsDictionary[session.saveSlot] = Mathf.Min(session.nuggets, ectdNuggets);
				else
					nuggetsDictionary[session.saveSlot] = session.nuggets;
			SaveNuggets();
		}
		public void SaveNuggets()
		{
			List<string> data = new List<string>();
			foreach (KeyValuePair<int, int> pair in nuggetsDictionary)
				data.Add(pair.Key + ":" + pair.Value);
			File.WriteAllText(nuggetsPath, string.Join("\n", data.ToArray()));
			Logger.LogInfo("Saved Nuggets - " + string.Join("|", data.ToArray()) + ".");
		}
		public void Start()
		{
			ECTDPatches.plugin = this;

			Logger.LogInfo(string.Concat(pluginName, " v", pluginVersion, " (", pluginGuid, ") has started."));

			LoadConfigFile();

			harmony = new Harmony(pluginGuid);

			// ECTD Classic
			PrefixAndLog(typeof(CharacterCreation), "LoadCharacter2");
			PrefixAndLog(typeof(CharacterCreation), "SaveCharacter");
			PrefixAndLog(typeof(AgentHitbox), "GetColorFromString");

			// ECTD-NoLimitNuggets
			PrefixAndLog(typeof(Unlocks), "AddNuggets");

			PrefixAndLog(typeof(InvItem), "SetupDetails");
			PrefixAndLog(typeof(InvDatabase), "AddItemPlayerStart");

			PrefixAndLog(typeof(InvDatabase), "SubtractFromItemCount", new Type[] { typeof(int), typeof(int), typeof(bool) });
			PrefixAndLog(typeof(InvDatabase), "SubtractFromItemCount", new Type[] { typeof(InvItem), typeof(int), typeof(bool) }, 2);

			// ECTD Localization
			PostfixAndLog(typeof(NameDB), "GetName");
			// ECTD Mutators
			PostfixAndLog(typeof(ScrollingMenu), "SortUnlocks");

			Logger.LogInfo("All patches were applied.");

		}
	}
	public static class ECTDPatches
	{
		public static ECTDPlugin plugin;

		public static void CharacterCreation_LoadCharacter2(CharacterCreation __instance, string characterName, bool secondTry, bool foundFile, object mySaveObject)
		{
			CharacterCreation cc = __instance;
			#region part from original code
			cc.gc = GameController.gameController;
			string str = Application.persistentDataPath;
			if ((!cc.gc.consoleVersion || cc.gc.fakeConsole) && cc.gc.usingMyDocuments && !cc.gc.macVersion && !cc.gc.linuxVersion)
				str = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/" + cc.gc.dataFolder;
			string text = string.Concat(new string[]
			{
				"/CloudData/Characters/",
				characterName,
				"/",
				characterName,
				".dat"
			});
			if (secondTry)
			{
				text = "/BackupData/Backup" + characterName + "2.dat";
			}
			SaveCharacterData saveCharacterData = null;
			cc.loadedCharacter = true;
			if (foundFile)
			{
				FileStream fileStream = null;
				try
				{
					if (cc.gc.consoleVersion && !cc.gc.fakeConsole)
						saveCharacterData = (SaveCharacterData)mySaveObject;
					else
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						fileStream = File.Open(str + text, FileMode.Open);
						saveCharacterData = (SaveCharacterData)binaryFormatter.Deserialize(fileStream);
						fileStream.Close();
					}
				}
				catch
				{
					try
					{
						fileStream?.Close();
					}
					catch
					{
					}
				}
			}
			#endregion
			#region changes
			if (saveCharacterData != null)
			{
				foreach (string unlockName in saveCharacterData.traits)
					if (cc.gc.unlocks.GetUnlock(unlockName, "Trait") == null)
						cc.gc.unlocks.AddUnlock(unlockName, "Trait", true);
				foreach (string unlockName2 in saveCharacterData.items)
					if (cc.gc.unlocks.GetUnlock(unlockName2, "Item") == null)
						cc.gc.unlocks.AddUnlock(unlockName2, "Item", true);

				if (cc.gc.unlocks.GetUnlock(saveCharacterData.specialAbility, "Ability") == null)
					cc.gc.unlocks.AddUnlock(saveCharacterData.specialAbility, "Ability", true);
				if (cc.gc.unlocks.GetUnlock(saveCharacterData.bigQuest + "_BQ", "BigQuest") == null)
					cc.gc.unlocks.AddUnlock(saveCharacterData.bigQuest + "_BQ", "BigQuest", true);
			}
			#endregion
		}
		public static void CharacterCreation_SaveCharacter(CharacterCreation __instance)
		{
			CharacterCreation cc = __instance;

			foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\+\\+(.+)", RegexOptions.ECMAScript))
			{
				string itemID = match.Groups[1].Value;
				cc.itemsChosen.Add(new Unlock(itemID, "Item", true));
				cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, "[Item '" + itemID + "' added]");
			}
			foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\-\\-(.+)", RegexOptions.ECMAScript))
			{
				string itemID = match.Groups[1].Value.ToLower();
				int index = cc.itemsChosen.FindIndex(item => item.unlockName.ToLower() == itemID);
				if (index != -1)
				{
					cc.itemsChosen.RemoveAt(index);
					cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, "[Item '" + itemID + "' removed]");
				}
			}
			foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\*\\*(.+)", RegexOptions.ECMAScript))
			{
				string traitID = match.Groups[1].Value;
				cc.traitsChosen.Add(new Unlock(traitID, "Trait", true));
				cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, "[Trait '" + traitID + "' added]");
			}
			foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\/\\/(.+)", RegexOptions.ECMAScript))
			{
				string traitID = match.Groups[1].Value;
				int index = cc.traitsChosen.FindIndex(item => item.unlockName == traitID);
				if (index != -1)
				{
					cc.traitsChosen.RemoveAt(index);
					cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, "[Trait '" + traitID + "' removed]");
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
				string statID = match.Groups[1].Value;
				if (int.TryParse(match.Groups[2].Value, out int value))
				{
					cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, "['" + statID + "' set to '" + value + "']");
					if (statID == "Strength" || statID == "Str")
						cc.strength = value - 1;
					else if (statID == "Endurance" || statID == "End")
						cc.endurance = value - 1;
					else if (statID == "Accuracy" || statID == "Acc")
						cc.accuracy = value - 1;
					else if (statID == "Speed" || statID == "Spd")
						cc.speed = value - 1;
				}
			}
			foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\%\\%(.+)", RegexOptions.ECMAScript))
			{
				string abilityID = match.Groups[1].Value;
				cc.abilityChosen = abilityID;
				cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, "[Ability set to '" + abilityID + "']");
			}
			foreach (Match match in Regex.Matches(cc.descriptionChosen, "\\:\\:(Skin|Hair|Legs|Body|Eyes)(\\=.+)?", RegexOptions.ECMAScript))
			{
				string partID = match.Groups[1].Value;
				if (match.Groups[2].Success)
				{
					string colorID = match.Groups[2].Value.Substring(1);
					if (match.Groups[2].Value.IndexOfAny(new char[] { '-', '.', '|', ':', '_', ',', ';' }) != -1)
						colorID = ":" + colorID;
					if (partID == "Skin") cc.skinColor = colorID;
					else if (partID == "Hair") cc.hairColor = colorID;
					else if (partID == "Legs") cc.legsColor = colorID;
					else if (partID == "Body") cc.bodyColor = colorID;
					else if (partID == "Eyes") cc.eyesColor = colorID;
					if (colorID.StartsWith(":")) colorID = colorID.Substring(1);
					cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, "[Color of '" + partID + "' set to '" + colorID + "']");
				}
				else
				{
					string curColor = "???";
					if (partID == "Skin") curColor = cc.skinColor;
					else if (partID == "Hair") curColor = cc.hairColor;
					else if (partID == "Legs") curColor = cc.legsColor;
					else if (partID == "Body") curColor = cc.bodyColor;
					else if (partID == "Eyes") curColor = cc.eyesColor;
					if (curColor.StartsWith(":")) curColor = curColor.Substring(1);
					cc.descriptionChosen = cc.descriptionChosen.Replace(match.Value, "[Color of '" + partID + "' is '" + curColor + "']");
				}
			}

		}
		public static bool AgentHitbox_GetColorFromString(AgentHitbox __instance, string colorChoice, string bodyPart)
		{
			AgentHitbox ah = __instance;
			Color32 color = Color.white;
			bool noncustom = false;
			switch (colorChoice)
			{
				case "Clear":
					color = AgentHitbox.skinClear;
					break;
				default:
					noncustom = true;
					break;
			}
			if (colorChoice.StartsWith(":"))
			{
				color = new Color32(0, 0, 0, 255);
				noncustom = false;
				string[] splitted = colorChoice.Substring(1).Split(new char[] { '-', '.', '|', ':', '_', ',', ';' });
				if (splitted.Length >= 1 && int.TryParse(splitted[0], out int red))
					color.r = (byte)Mathf.Clamp(red, 0, 255);
				if (splitted.Length >= 2 && int.TryParse(splitted[1], out int green))
					color.g = (byte)Mathf.Clamp(green, 0, 255);
				if (splitted.Length >= 3 && int.TryParse(splitted[2], out int blue))
					color.b = (byte)Mathf.Clamp(blue, 0, 255);
				if (splitted.Length >= 4 && int.TryParse(splitted[3], out int aaa))
					color.a = (byte)Mathf.Clamp(aaa, 0, 255);
			}
			if (noncustom) return true;
			if (bodyPart == "Skin") ah.skinColor = color;
			else if (bodyPart == "Hair") ah.hairColor = color;
			else if (bodyPart == "Legs") ah.legsColor = color;
			else if (bodyPart == "Body") ah.bodyColor = color;
			else if (bodyPart == "Eyes") ah.eyesColor = color;
			return false;
		}

		public static bool Unlocks_AddNuggets(int numNuggets)
		{
			SessionDataBig session = GameController.gameController.sessionDataBig;

			int previous = session.nuggets;
			session.nuggets += numNuggets;
			if (!GameController.gameController.challenges.Contains("ECTD-NoLimitNuggets") && session.nuggets > 99 && previous <= 99)
				session.nuggets = 99;
			plugin.nuggetsDictionary[session.saveSlot] = session.nuggets;
			plugin.SaveNuggets();

			GameController.gameController.unlocks.SaveUnlockData(true);
			return false;
		}

		private static bool DoTheNumber(ref string itemName, ref int itemCount)
		{
			int index = itemName.IndexOf('+');
			if (index != -1)
			{
				string numStr = itemName.Substring(index + 1);
				if (string.Equals(numStr, "INF", StringComparison.InvariantCultureIgnoreCase)
					|| string.Equals(numStr, "INFINITE", StringComparison.InvariantCultureIgnoreCase)
					|| string.Equals(numStr, "INFINITY", StringComparison.InvariantCultureIgnoreCase))
				{
					itemName = itemName.Substring(0, index);
					itemCount = -1;
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
		public static void InvDatabase_AddItemPlayerStart(ref string itemName, ref int itemCount) => DoTheNumber(ref itemName, ref itemCount);

		public static bool InvDatabase_SubtractFromItemCount(InvDatabase __instance, int slotNum) => __instance.InvItemList[slotNum].invItemCount != -1;
		public static bool InvDatabase_SubtractFromItemCount2(InvItem invItem) => invItem.invItemCount != -1;

		public static void NameDB_GetName(NameDB __instance, string myName, ref string __result)
		{
			int count = 0;
			DoTheNumber(ref myName, ref count);
			// "english", "schinese", "german", "spanish", "brazilian", "russian", "french", "koreana"
			string language = __instance.language;

			if (myName == "ECTD-NoLimitNuggets")
				__result = language == "russian"
					? "[ECTD] Безлимитные наггетсы"
					: "[ECTD] No Limit Nuggets";
			else if (myName == "D_ECTD-NoLimitNuggets")
				__result = language == "russian"
					? "Если включен, позволяет вам набирать более 99 наггетсов. Если выключен, НЕ сбрасывает количество наггетсов."
					: "If enabled, allows you to get more than 99 nuggets. If disabled, does NOT reset the nuggets amount.";
		}
		public static void ScrollingMenu_SortUnlocks(ScrollingMenu __instance, string unlockType)
		{
			List<Unlock> listUnlocks = (List<Unlock>)AccessTools.Field(typeof(ScrollingMenu), "listUnlocks").GetValue(__instance);
			if (unlockType == "Challenge")
			{
				listUnlocks.Insert(1, new Unlock("ECTD-NoLimitNuggets", "Challenge", true));
				__instance.numButtons++;
			}
		}
	}
}
