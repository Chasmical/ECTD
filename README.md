## ⚰️ ECTD has been discontinued ⚰️

The project's repository is archived as part of the GitHub Archive Program. ECTD's code and the documentation will no longer be updated. See more information in the [latest RogueLibs blog post](https://chasmical.github.io/RogueLibs/blog/2024/02/03/discontinuing-roguelibs). Feel free to fork the repository to continue working on the project.

<div align="center">
  <h2>ECTD (Edit Characters Through Description)</h2>
  <a href="https://github.com/SugarBarrel/ECTD/releases/latest">
    <img src="https://img.shields.io/github/v/release/SugarBarrel/ECTD?label=Latest%20release&logo=github&style=for-the-badge" alt="Latest release"/>
  </a>
    <a href="https://github.com/SugarBarrel/ECTD/releases">
      <img src="https://img.shields.io/github/v/release/SugarBarrel/ECTD?include_prereleases&label=Latest%20pre-release&style=for-the-badge&logo=github" alt="Latest pre-release"/>
  <br/>
  <a href="https://github.com/SugarBarrel/ECTD/releases">
    <img src="https://img.shields.io/github/downloads/SugarBarrel/ECTD/total?label=Downloads&style=for-the-badge" alt="Downloads"/>
  </a>
  <a href="https://github.com/SugarBarrel/ECTD/subscription">
    <img src="https://img.shields.io/github/watchers/SugarBarrel/ECTD?color=green&label=Watchers&style=for-the-badge" alt="Watchers"/>
  </a>
  <a href="https://github.com/SugarBarrel/ECTD/stargazers">
    <img src="https://img.shields.io/github/stars/SugarBarrel/ECTD?color=green&style=for-the-badge" alt="Stars"/>
  </a>
</div>

### ECTD v3.0.0 now works with RogueLibs v3.3.0!
  
**With ECTD you can:**
*	Set Strength/Endurance/Accuracy/Speed to any value in range ±2147483647;
*	Add any items, like Grenades, Plasma Sword or Laser Blazer;
*	Add any traits, ability upgrades and upgraded traits;
*	Set unavailable abilities, for example WerewolfLunge or TutorialAbility;
*	Set colors of body parts (+ custom colors R,G,B,A);
*	Use new mutator, added by this mod;

## Links ##
* [Download ECTD](https://github.com/SugarBarrel/ECTD/releases)
* [ECTD on GitHub](https://github.com/SugarBarrel/ECTD)
* [Steam guide](https://steamcommunity.com/sharedfiles/filedetails/?id=2093706214)
* [Steam collection of characters using ECTD](https://steamcommunity.com/sharedfiles/filedetails/?id=2098198414)

## Contents ##
1.	[Installation](https://github.com/SugarBarrel/ECTD#installation)
2.	[Deinstallation](https://github.com/SugarBarrel/ECTD#deintallation)
3.	[How to use ECTD?](https://github.com/SugarBarrel/ECTD#how-to-add-itemstraits)
4.	['Description Commands'](https://github.com/SugarBarrel/ECTD#description-commands)
5.	[New Mutators](https://github.com/SugarBarrel/ECTD#new-mutators)
6.	[Characters created using ECTD](https://github.com/SugarBarrel/ECTD#characters-created-using-ectd)
7.	[Changelog](https://github.com/SugarBarrel/ECTD#changelog)

## Installation ##
1.	Install BepInEx:
    1.	[Download the latest version of BepInEx](https://github.com/BepInEx/BepInEx/releases/latest);
    2.	Drag all files from the archive into directory /Steam/SteamApps/common/Streets of Rogue/;
    3.	Run the game, so BepInEx can create needed files and directories, and close the game;
2.  Install RogueLibs:
    1.  [Download the latest version of RogueLibs](https://github.com/SugarBarrel/RogueLibs/releases/latest);
    2.  Drag `RogueLibsCore.dll` into directory /Steam/SteamApps/common/Streets of Rogue/BepInEx/plugins;
    3.  Drag `RogueLibsPatcher.dll` into directory /Steam/SteamApps/common/Streets of Rogue/BepInEx/patchers;
3.	[Download the latest version of ECTD](https://github.com/SugarBarrel/ECTD/releases/latest);
4.  Drag the file "ECTD.dll" into directory /Steam/SteamApps/common/Streets of Rogue/BepInEx/plugins;
5.  Done! Now run the game and enjoy!

## Deinstallation ##
1.	Just remove "ECTD.dll" from /Steam/SteamApps/common/Streets of Rogue/BepInEx/plugins.

## How to add items/traits? ##
You need to type 'description commands' in your custom character's description, like so:
```
++PlasmaSword
&&Strength=228
**BananaLover2
%%WerewolfLunge
&&Speed=-2
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
<br/>See [All Item IDs.txt](https://github.com/SugarBarrel/ECTD/blob/master/All%20Item%20IDs.txt);

  **Now you can specify item counts! *(v2.7+)*:**<br/>
`++RocketLauncher+Infinity`, `++Grenade+45`, `++BananaPeel+19`.

* `--<Item ID>` - removes an item with the specified ID from the custom character;
<br/>Examples: `--Grenade`, `--PlasmaSword`, `--Hypnotizer2`;

* `**<Trait ID>` - adds a trait with the specified ID to the custom character;
<br/>Examples: `**UpperCrusty`, `**BananaLover2`, `**ReloadWeaponsNewLevel`;
<br/>See [All Trait IDs.txt](https://github.com/SugarBarrel/ECTD/blob/master/All%20Trait%20IDs.txt);

* `//<Trait ID>` - removes a trait with the specified ID from the custom character;
<br/>Examples: `//UpperCrusty`, `//BananaLover2`, `//ReloadWeaponsNewLevel`;

* `&&Strength=<Value>` or `&&Str=<Value>` - sets the custom character's Strength to the specified value;
<br/>Examples: `&&Strength=11`, `&&Strength=-6`, `&&Str=50`;

* `&&Endurance=<Value>` or `&&End=<Value>` - sets the custom character's Endurance to the specified value;
<br/>Examples: `&&Endurance=488755541`, `&&Endurance=-2`, `&&End=16`;

* `&&Accuracy=<Value>` or `&&Acc=<Value>` - sets the custom character's Firearms to the specified value;
<br/>Examples: `&&Accuracy=1337`, `&&Accuracy=-4`, `&&Acc=228`;

* `&&Speed=<Value>` or `&&Spd=<Value>` - sets the custom character's Speed to the specified value;
<br/>Examples: `&&Speed=40`, `&&Speed=-6`, `&&Spd=69`;

* `%%<Ability ID>` - sets the custom character's special ability;
<br/>Examples: `%%Charge`, `%%WerewolfLunge`, `%%MindControl`;
<br/>See [All Ability IDs.txt](https://github.com/SugarBarrel/ECTD/blob/master/All%20Ability%20IDs.txt);

* `!!items` - lists all item IDs that were added to the custom character;

* `!!traits` - lists all trait IDs that were added to the custom character;

* `::Skin|Hair|Legs|Body|Eyes` - gets the custom character's skin/hair/legs/body/eyes color;

* `::Skin|Hair|Legs|Body|Eyes=<Color>` - sets the custom character's skin/hair/legs/body/eyes color to the specified color;
<br/>Examples: `::Skin=Purple`, `::Eyes=RobotSkin`, `::Hair=255|12|86|220`, `::Body=23-62`, `::Legs=255,0,255,127`;
<br/>See [All Color IDs.txt](https://github.com/SugarBarrel/ECTD/blob/master/All%20Color%20IDs.txt);

## Tired of these annoying messages? ***(v2.8+)*** ##

Here's how you can remove messages like "[Item 'Fud+50' added]":

Find a file called "ectd-nomessages.cfg" in BepInEx/config and write "true" in it. (if the file doesn't exist, start the game, the file will be created automatically, or create it yourself)

## Characters created using ECTD ##
When you're publishing your custom characters, you can use this template on Steam Workshop:
```
[b]This character requires ECTD to work!
You can find the latest release here:
https://github.com/SugarBarrel/ECTD/releases[/b]
```

https://steamcommunity.com/sharedfiles/filedetails/?id=2098198414
