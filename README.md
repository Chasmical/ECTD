<div align="center">
  <h2>ECTD (Edit Characters Through Description)</h2>
  <a href="https://github.com/Abbysssal/ECTD/releases/latest">
    <img src="https://img.shields.io/github/v/release/Abbysssal/ECTD?label=Latest%20release&logo=github&style=for-the-badge" alt="Latest release"/>
  </a>
    <a href="https://github.com/Abbysssal/ECTD/releases">
      <img src="https://img.shields.io/github/v/release/Abbysssal/ECTD?include_prereleases&label=Latest%20pre-release&style=for-the-badge&logo=github" alt="Latest pre-release"/>
  <br/>
  <a href="https://github.com/Abbysssal/ECTD/releases">
    <img src="https://img.shields.io/github/downloads/Abbysssal/ECTD/total?label=Downloads&style=for-the-badge" alt="Downloads"/>
  </a>
  <a href="https://github.com/Abbysssal/ECTD/subscription">
    <img src="https://img.shields.io/github/watchers/Abbysssal/ECTD?color=green&label=Watchers&style=for-the-badge" alt="Watchers"/>
  </a>
  <a href="https://github.com/Abbysssal/ECTD/stargazers">
    <img src="https://img.shields.io/github/stars/Abbysssal/ECTD?color=green&style=for-the-badge" alt="Stars"/>
  </a>
</div>

# RogueLibs v3 does not support ECTD!
# You'll have to choose between RLv3 mods and ECTD.
  
**With ECTD you can:**
*	Set Strength/Endurance/Accuracy/Speed to any value in range ±2147483647;
*	Add any items, like Grenades, Plasma Sword or Laser Blazer;
*	Add any traits, ability upgrades and upgraded traits;
*	Set unavailable abilities, for example WerewolfLunge or TutorialAbility;
*	Set colors of body parts (+ custom colors R,G,B,A);
*	Use new mutator, added by this mod;

## Links ##
* [Download ECTD](https://github.com/Abbysssal/ECTD/releases)
* [ECTD on GitHub](https://github.com/Abbysssal/ECTD)
* [Steam guide](https://steamcommunity.com/sharedfiles/filedetails/?id=2093706214)
* [Steam collection of characters using ECTD](https://steamcommunity.com/sharedfiles/filedetails/?id=2098198414)

## Contents ##
1.	[Installation](https://github.com/Abbysssal/ECTD#installation)
2.	[Deinstallation](https://github.com/Abbysssal/ECTD#deintallation)
3.	[How to use ECTD?](https://github.com/Abbysssal/ECTD#how-to-add-itemstraits)
4.	['Description Commands'](https://github.com/Abbysssal/ECTD#description-commands)
5.	[New Mutators](https://github.com/Abbysssal/ECTD#new-mutators)
6.	[Characters created using ECTD](https://github.com/Abbysssal/ECTD#characters-created-using-ectd)
7.	[Changelog](https://github.com/Abbysssal/ECTD#changelog)

## Installation ##
1.	Install BepInEx:
    1.	[Download the latest version of BepInEx](https://github.com/BepInEx/BepInEx/releases);
    2.	Drag all files from the archive into directory /Steam/SteamApps/common/Streets of Rogue/;
    3.	Run the game, so BepInEx can create needed files and directories, and close the game;
2.	[Download the latest version of ECTD](https://github.com/Abbysssal/ECTD/releases);
3.  Drag the file "ECTD.dll" from the archive into directory /Steam/SteamApps/common/Streets of Rogue/BepInEx/plugins;
4.  Done! Now run the game and enjoy!

## Deinstallation ##
1.	Just remove "ECTD.dll" from /Steam/SteamApps/common/Streets of Rogue/BepInEx/plugins.

## How to add items/traits? ##
You need to type 'description commands' in your custom character's description, like so:
```
++PlasmaSword
^^Strength=228
**BananaLover2
%%WerewolfLunge
^^Speed=-2
```
After saving the character, a text will appear in the description, describing the changes that were made:
```
[ITEM 'PlasmaSword' ADDED]
[STAT 'Strength' SET TO '228']
[TRAIT 'BananaLover2' ADDED]
[ABILITY 'WerewolfLunge' ADDED]
[STAT 'Speed' SET TO '-2']
```

See the [guide in Steam](https://steamcommunity.com/sharedfiles/filedetails/?id=2093706214) for more information.

## 'Description Commands' ##

* `++<Item ID>` - adds an item with the specified ID to the custom character;
<br/>Examples: `++Grenade`, `++PlasmaSword`, `++Hypnotizer2`;
<br/>See [All Item IDs.txt](https://github.com/Abbysssal/ECTD/blob/master/All%20Item%20IDs.txt);

  **Now you can specify item counts! *(v2.7)*:**<br/>
`++RocketLauncher+Inf`, `++Grenade+Infinity`, `++BananaPeel+Infinite`.

* `--<Item ID>` - removes an item with the specified ID from the custom character;
<br/>Examples: `--Grenade`, `--PlasmaSword`, `--Hypnotizer2`;

* `**<Trait ID>` - adds a trait with the specified ID to the custom character;
<br/>Examples: `**UpperCrusty`, `**BananaLover2`, `**ReloadWeaponsNewLevel`;
<br/>See [All Trait IDs.txt](https://github.com/Abbysssal/ECTD/blob/master/All%20Trait%20IDs.txt);

* `//<Trait ID>` - removes a trait with the specified ID from the custom character;
<br/>Examples: `//UpperCrusty`, `//BananaLover2`, `//ReloadWeaponsNewLevel`;

* `^^Strength=<Value>` or `^^Str=<Value>` - sets the custom character's Strength to the specified value;
<br/>Examples: `^^Strength=11`, `^^Strength=-6`, `^^Str=50`;

* `^^Endurance=<Value>` or `^^End=<Value>` - sets the custom character's Endurance to the specified value;
<br/>Examples: `^^Endurance=488755541`, `^^Endurance=-2`, `^^End=16`;

* `^^Accuracy=<Value>` or `^^Acc=<Value>` - sets the custom character's Firearms to the specified value;
<br/>Examples: `^^Accuracy=1337`, `^^Accuracy=-4`, `^^Acc=228`;

* `^^Speed=<Value>` or `^^Spd=<Value>` - sets the custom character's Speed to the specified value;
<br/>Examples: `^^Speed=40`, `^^Speed=-6`, `^^Spd=69`;

* `%%<Ability ID>` - sets the custom character's special ability;
<br/>Examples: `%%Charge`, `%%WerewolfLunge`, `%%MindControl`;
<br/>See [All Ability IDs.txt](https://github.com/Abbysssal/ECTD/blob/master/All%20Ability%20IDs.txt);

* `!!items` - lists all item IDs that were added to the custom character;

* `!!traits` - lists all trait IDs that were added to the custom character;

* `::Skin|Hair|Legs|Body|Eyes` - gets the custom character's skin/hair/legs/body/eyes color;

* `::Skin|Hair|Legs|Body|Eyes=<Color>` - sets the custom character's skin/hair/legs/body/eyes color to the specified color;
<br/>Examples: `::Skin=Purple`, `::Eyes=RobotSkin`, `::Hair=255|12|86|220`, `::Body=23-62`, `::Legs=255,0,255,127`;
<br/>See [All Color IDs.txt](https://github.com/Abbysssal/ECTD/blob/master/All%20Color%20IDs.txt);

## Tired of these annoying messages? ***(v2.8)*** ##

Here's how you can remove messages like "[Item 'Fud+50' added]":

Find a file called "ectd-nomessages.cfg" in BepInEx/config and write "true" in it. (if the file doesn't exist, start the game, the file will be created automatically, or create it yourself)

## New Mutators ##
You can select new mutators at Home Base!

* **[ECTD] No Limit Nuggets** - If enabled, allows you to get more than 99 nuggets. If disabled, does NOT reset the nuggets amount.

## Characters created using ECTD ##
When you're publishing your custom characters, you can use this template on Steam Workshop:
```
[b]This character requires ECTD to work!
You can find the latest release here:
https://github.com/Abbysssal/ECTD/releases[/b]
```

https://steamcommunity.com/sharedfiles/filedetails/?id=2098198414

## Changelog ##

#### ECTD v2.5.1 ####
* Fixed a bug, when custom special abilities and big quests didn't work with imported characters;
* Fixed "[ECTD] No Limit Nuggets" mutator's position in the Mutator Menu;

#### ECTD v2.5 ####
* Removed mutators "ECTD-RocketBullets" and "ECTD-GiantExplosions", because [aToM](https://github.com/Abbysssal/aToM) adds similar mutators;
* Removed mutators "ECTD-OneHitPlayer" and "ECTD-SuperSpeed", because they are very buggy;
* Added chat commands!;
* "!help" lists all available commands;
* "!item \<ItemID\> [Amount]" spawns the item at cursor's position;
* "!agent \<AgentID\>" or "!npc \<AgentID\>" spawns the agent at cursor's position;
* Fixed a bug, when ECTD didn't recognize item IDs with '-' and other symbols;

#### ECTD v2.4.1 ####
* Fixed a bug, when ECTD's mutators replaced original mutators in the Mutator Menu;

#### ECTD v2.4 ####
* Added new mutator "ECTD-NoLimitNuggets";
* Added new mutator "ECTD-OneHitPlayer";
* Added new mutator "ECTD-GiantExplosions";
* Added new mutator "ECTD-SuperSpeed";

#### ECTD v2.3 ####
* Ported the mod to BepInEx. Now I don't have to update the mod for every single bugfix;
* "ECTD-RocketBullets" now works on projectiles, shot by traps;
* If the item or trait removal command can't find the specified ID, the command won't be executed;

#### ECTD v2.2: ####
* Added `::<Part>` to get body part's color;
* Added `::<Part>=<Color>` to set body part's color (+ custom colors);

#### ECTD v2.1.1: ####
* With "ECTD-RocketBullets" enabled, Shotgun will shoot 3 rockets instead of 1;

#### ECTD v2.1: ####
* Added mutator "ECTD-RocketBullets" - all projectiles are replaced by rockets;

#### ECTD v2.0: ####
* Rewrote some of the code;
* Description commands now will apply changes to the character files. It means that some of the added items or traits will work for other players without the mod too;
* Removed `+<Item>++<Count>`, because it won't work with the new structure;
* Replaced `+<Item>` with `++<Item>`;
* Replaced `*<Trait>` with `**<Trait>`;
* Replaced `^<Stat>=<Value>` with `^^<Stat>=<Value>`;
* Added `--<Item>` to remove items;
* Added `//<Trait>` to remove traits;
* Added `%%<Ability>` to set special abilities;
* Added `!!items` to list all added items;
* Added `!!traits` to list all added traits;

#### ~~ECTD v1.4:~~ ####
* ~~Now the commands spawn items/agents at the cursor's position;~~

#### ~~ECTD v1.3:~~ ####
* ~~Ported to uMod Framework (UMF);~~
* ~~Added console command `/item <ID>`;~~
* ~~Added console command `/npc <ID>`;~~

#### ECTD v1.2: ####
* `^<Stat>=<Value>` now works for negative values too;

#### ECTD v1.1: ####
* Added `+<Item>++<Count>` description command;
* Added `*<Trait>` description command;
* Added `^<Stat>=<Value>` description command;

#### ECTD v1.0 (also known as Any Items Mod): ####
* Added `+<Item>` description command.
