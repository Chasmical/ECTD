## Links ##
* [Download ECTD](https://github.com/Abbysssal/ECTD/releases)
* [ECTD at GitHub](https://github.com/Abbysssal/ECTD)

## ECTD (Edit Characters Through Description) ##
#### Game version: v89j2<br/>Mod version: v2.1.1<br/>Created by: Abbysssal#2020 ####

Have you ever wanted to create an interesting custom character, but the in-game editor didn't have all items or traits that you needed? Well, now you can! This mod allows you to add unavailable items, traits and abilities to your custom characters.

Also this mod adds one mutator "ECTD-RocketBullets" - All bullets and projectiles are replaced by rockets. *Works on both players and NPCs.* Here's a short video about this mutator: https://www.youtube.com/watch?v=XBQcWCL9fwo

## Installation ##
1.  Drag the file "Assembly-CSharp.dll" into the directory /Steam/SteamApps/common/Streets of Rogue/StreetsOfRogue_Data/Managed/ (Replace if needed);
2.  Done! Now run the game and enjoy!

## Deintallation (This will also remove any custom localizations!) ##
1.  Right-Click on Streets of Rogue in Steam;
2.  Select "Properties";
3.  Choose category "Local files";
4.  Press "Verify integrity of game files".

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

## 'Description Commands' ##

* `++<Item ID>` - adds an item with the specified ID to the custom character;
<br/>Examples: `++Grenade`, `++PlasmaSword`, `++Hypnotizer2`;
<br/>See [All Item IDs.txt](https://github.com/Abbysssal/ECTD/blob/master/All%20Item%20IDs.txt);

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

## New mutators ##
You can select new mutators at Home Base!

* ECTD-RocketBullets - all bullets and projectiles are replaced by rockets. Let the TRUE chaos begin!

## Characters created using ECTD ##
When you're publishing your custom characters, you can use this template on Steam Workshop:
```
[b]This character requires ECTD to work![/b]
[b]You can find the latest release here:[/b]
[b]https://github.com/Abbysssal/ECTD/releases[/b]
```

* [Cyborg](https://steamcommunity.com/sharedfiles/filedetails/?id=2092648215) by [Qenapp](https://steamcommunity.com/id/Qenapp)

## Changelog ##

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
