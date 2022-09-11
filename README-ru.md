## ECTD (Edit Characters Through Description) ##

<div align="center">
  <a href="https://github.com/Abbysssal/ECTD/releases/latest">
    <img src="https://img.shields.io/github/v/release/Abbysssal/ECTD?label=Latest%20release&logo=github&style=for-the-badge" alt="Последний релиз"/>
  </a>
  <br/>
  <a href="https://github.com/Abbysssal/ECTD/releases">
    <img src="https://img.shields.io/github/downloads/Abbysssal/ECTD/total?label=Downloads&style=for-the-badge" alt="Скачивания"/>
  </a>
  <a href="https://github.com/Abbysssal/ECTD/subscription">
    <img src="https://img.shields.io/github/watchers/Abbysssal/ECTD?color=green&label=Watchers&style=for-the-badge" alt="Смотрители(?)"/>
  </a>
  <a href="https://github.com/Abbysssal/ECTD/stargazers">
    <img src="https://img.shields.io/github/stars/Abbysssal/ECTD?color=green&style=for-the-badge" alt="Звёзды"/>
  </a>
</div>

# ECTD v3.0.0 теперь поддерживает RogueLibs v3.3.0!

**С ECTD вы можете:**
*	Изменять значения характеристик в диапазоне ±2147483647;
*	Добавлять любые предметы, например Гранаты или Плазменный Меч;
*	Добавлять любые особенности, в том числе и улучшения;
*	Ставить любые способности, например Рывок Вервольфа;
*	Изменять цвета частей тела (+ кастомные цвета R,G,B,A);
*	Ставить новый добавляемый этим модом мутатор;

## Ссылки ##
* [Скачать ECTD](https://github.com/Abbysssal/ECTD/releases)
* [ECTD на GitHub](https://github.com/Abbysssal/ECTD)
* [Руководство в Стиме (англ.)](https://steamcommunity.com/sharedfiles/filedetails/?id=2093706214)
* [Коллекция персонажей, созданных с ECTD, в Стиме](https://steamcommunity.com/sharedfiles/filedetails/?id=2098198414)

## Содержание ##
1.	[Установка](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#установка)
2.	[Деинсталляция](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#деинсталляция)
3.	[Как пользоваться ECTD?](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#как-добавлять-предметыособенности)
4.	[Список команд](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#список-команд)
5.	[Новые мутаторы](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#новые-мутаторы)
6.	[Персонажи, созданные с ECTD](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#персонажи-созданные-с-ectd)
7.	[Список изменений](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#список-изменений)

## Установка ##
1.	Установите BepInEx:
    1.	[Скачайте свежую версию BepInEx](https://github.com/BepInEx/BepInEx/releases/latest);
    2.	Перенесите файлы из архива в папку /Steam/SteamApps/common/Streets of Rogue/;
    3.	Запустите игру, чтобы BepInEx создал нужные файлы и папки, и выйдите из игры;
2.  Install RogueLibs:
    1.  [Скачайте свежую версию RogueLibs](https://github.com/Abbysssal/RogueLibs/releases/latest);
    2.  Перенесите `RogueLibsCore.dll` в папку /Steam/SteamApps/common/Streets of Rogue/BepInEx/plugins;
    3.  Перенесите `RogueLibsPatcher.dll` в папку /Steam/SteamApps/common/Streets of Rogue/BepInEx/patchers;
3.	[Скачайте свежую версию ECTD](https://github.com/Abbysssal/ECTD/releases/latest);
4.	Перенесите файл "ECTD.dll" из архива в папку /Steam/SteamApps/common/Streets of Rogue/BepInEx/plugins;
5.	Готово. Запускайте игру и наслаждайтесь!

## Деинсталляция ##
1.	Просто уберите файл "ECTD.dll" из папки/Steam/SteamApps/common/Streets of Rogue/BepInEx/plugins.

## Как добавлять предметы/особенности? ##
Вам нужно ввести специальные команды в описании вашего кастомного персонажа:
```
++PlasmaSword
&&Strength=228
**BananaLover2
%%WerewolfLunge
&&Speed=-2
```
После сохранения персонажа, в описании появится текст, описывающий внесённые изменения:
```
[ITEM 'PlasmaSword' ADDED]
[STAT 'Strength' SET TO '228']
[TRAIT 'BananaLover2' ADDED]
[ABILITY 'WerewolfLunge' ADDED]
[STAT 'Speed' SET TO '-2']
```

Просмотрите [гайд в Стиме](https://steamcommunity.com/sharedfiles/filedetails/?id=2093706214), там побольше информации.

## Список команд ##

* `++<ID предмета>` - добавляет предмет с указанным ID кастомному персонажу;
<br/>Примеры: `++Grenade`, `++PlasmaSword`, `++Hypnotizer2`;
<br/>ID предметов смотрите тут - [All Item IDs.txt](https://github.com/Abbysssal/ECTD/blob/master/All%20Item%20IDs.txt);

  **Можно ставить количества! *(v2.7+)*:**<br/>
`++RocketLauncher+Infinity`, `++Grenade+45`, `++BananaPeel+19`.

* `--<ID предмета>` - убирает предмет с указанным ID у кастомного персонажа;
<br/>Примеры: `--Grenade`, `--PlasmaSword`, `--Hypnotizer2`;

* `**<ID особенности>` - добавляет особенность с указанным ID кастомному персонажу;
<br/>Примеры: `**UpperCrusty`, `**BananaLover2`, `**ReloadWeaponsNewLevel`;
<br/>ID особенностей смотрите тут - [All Trait IDs.txt](https://github.com/Abbysssal/ECTD/blob/master/All%20Trait%20IDs.txt);

* `//<ID особенности>` - убирает особенность с указанным ID у кастомного персонажа;
<br/>Примеры: `//UpperCrusty`, `//BananaLover2`, `//ReloadWeaponsNewLevel`;

* `&&Strength=<Значение>` или `&&Str=<Значение>` - изменяет Силу кастомного персонажа на заданное значение;
<br/>Примеры: `&&Strength=11`, `&&Strength=-6`, `&&Str=50`;

* `&&Endurance=<Значение>` или `&&End=<Значение>` - изменяет Выносливость кастомного персонажа на заданное значение;
<br/>Примеры: `&&Endurance=488755541`, `&&Endurance=-2`, `&&End=16`;

* `&&Accuracy=<Значение>` или `&&Acc=<Значение>` - изменяет Стрельбу кастомного персонажа на заданное значение;
<br/>Примеры: `&&Accuracy=1337`, `&&Accuracy=-4`, `&&Acc=228`;

* `&&Speed=<Значение>` или `&&Spd=<Значение>` - изменяет Скорость кастомного персонажа на заданное значение;
<br/>Примеры: `&&Speed=40`, `&&Speed=-6`, `&&Spd=69`;

* `%%<ID способности>` - изменяет специальную способность кастомного персонажа;
<br/>Примеры: `%%Charge`, `%%WerewolfLunge`, `%%MindControl`;
<br/>ID способностей смотрите тут - [All Ability IDs.txt](https://github.com/Abbysssal/ECTD/blob/master/All%20Ability%20IDs.txt);

* `!!items` - показывает список ID всех добавленных предметов у кастомного персонажа;

* `!!traits` - показывает список ID всех добавленных особенностей у кастомного персонажа;

* `::Skin|Hair|Legs|Body|Eyes` - получает цвет кожи/волос/ног/тела/глаз у кастомного персонажа;

* `::Skin|Hair|Legs|Body|Eyes=<Цвет>` - изменяет цвет кожи/волос/ног/тела/глаз у кастомного персонажа на заданный цвет;
<br/>Примеры: `::Skin=Purple`, `::Eyes=RobotSkin`, `::Hair=255|12|86|220`, `::Body=23-62`, `::Legs=255,0,255,127`;
<br/>ID цветов смотрите тут - [All Color IDs.txt](https://github.com/Abbysssal/ECTD/blob/master/All%20Color%20IDs.txt);

## Надоели эти надоедливые сообщения? ***(v2.8+)*** ##

Вот как вы можете избавиться от сообщений типа "[Item 'Fud+50' added]":

Найдите файл под названием "ectd-nomessages.cfg" в папке BepInEx/config и напишите в нём "true". (Если нету файла, можете либо зайти в игру, он создастся автоматически, либо создайте сами)

## Персонажи, созданные с ECTD ##
Когда вы публикуете своих персонажей в Мастерскую Стима, можете использовать эти заготовки:
```
[b]This character requires ECTD to work!
You can find the latest release here:
https://github.com/Abbysssal/ECTD/releases[/b]

[b]Для работы этого персонажа нужен мод ECTD!
Скачать свежий релиз мода можно здесь:
https://github.com/Abbysssal/ECTD/releases[/b]
```

https://steamcommunity.com/sharedfiles/filedetails/?id=2098198414
