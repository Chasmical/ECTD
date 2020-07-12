## Ссылки ##
* [Скачать ECTD](https://github.com/Abbysssal/ECTD/releases)
* [ECTD на GitHub](https://github.com/Abbysssal/ECTD)
* [Руководство в Стиме (англ.)](https://steamcommunity.com/sharedfiles/filedetails/?id=2093706214)

## Содержание ##
1.	[Что такое ECTD?](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#ectd-edit-characters-through-description)
2.	[Установка](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#установка)
3.	[Деинсталляция](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#деинсталляция)
4.	[Как пользоваться ECTD?](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#как-добавлять-предметыособенности)
5.	[Список команд](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#список-команд)
6.	[Новые мутаторы](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#новые-мутаторы)
7.	[Персонажи, созданные с ECTD](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#персонажи-созданные-с-ectd)
8.	[Список изменений](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#список-изменений)

## ECTD (Edit Characters Through Description) ##
#### Версия игры: v89 и новее<br/>Версия мода: v2.5<br/>Автор мода: Abbysssal#2020 ####

**С ECTD вы можете:**
*	Изменять значения характеристик в диапазоне ±2147483647;
*	Добавлять любые предметы, например Гранаты или Плазменный Меч;
*	Добавлять любые особенности, в том числе и улучшения;
*	Ставить любые способности, например Рывок Вервольфа;
*	Изменять цвета частей тела (+ кастомные цвета R,G,B,A);
*	Ставить новый добавляемый этим модом мутатор;

## Установка ##
1.	Установите BepInEx:
    1.	[Скачайте свежую версию BepInEx](https://github.com/BepInEx/BepInEx/releases);
    2.	Перенесите файлы из архива в папку /Steam/SteamApps/common/Streets of Rogue/;
    3.	Запустите игру, чтобы BepInEx создал нужные файлы и папки, и выйдите из игры;
2.	[Скачайте свежую версию ECTD](https://github.com/Abbysssal/ECTD/releases);
3.	Перенесите файл "ECTD.dll" из архива в папку /Steam/SteamApps/common/Streets of Rogue/BepInEx/plugins;
4.	Готово. Запускайте игру и наслаждайтесь!

## Деинсталляция ##
1.	Просто уберите файл "ECTD.dll" из папки/Steam/SteamApps/common/Streets of Rogue/BepInEx/plugins.

## Как добавлять предметы/особенности? ##
Вам нужно ввести специальные команды в описании вашего кастомного персонажа:
```
++PlasmaSword
^^Strength=228
**BananaLover2
%%WerewolfLunge
^^Speed=-2
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

* `--<ID предмета>` - убирает предмет с указанным ID у кастомного персонажа;
<br/>Примеры: `--Grenade`, `--PlasmaSword`, `--Hypnotizer2`;

* `**<ID особенности>` - добавляет особенность с указанным ID кастомному персонажу;
<br/>Примеры: `**UpperCrusty`, `**BananaLover2`, `**ReloadWeaponsNewLevel`;
<br/>ID особенностей смотрите тут - [All Trait IDs.txt](https://github.com/Abbysssal/ECTD/blob/master/All%20Trait%20IDs.txt);

* `//<ID особенности>` - убирает особенность с указанным ID у кастомного персонажа;
<br/>Примеры: `//UpperCrusty`, `//BananaLover2`, `//ReloadWeaponsNewLevel`;

* `^^Strength=<Значение>` или `^^Str=<Значение>` - изменяет Силу кастомного персонажа на заданное значение;
<br/>Примеры: `^^Strength=11`, `^^Strength=-6`, `^^Str=50`;

* `^^Endurance=<Значение>` или `^^End=<Значение>` - изменяет Выносливость кастомного персонажа на заданное значение;
<br/>Примеры: `^^Endurance=488755541`, `^^Endurance=-2`, `^^End=16`;

* `^^Accuracy=<Значение>` или `^^Acc=<Значение>` - изменяет Стрельбу кастомного персонажа на заданное значение;
<br/>Примеры: `^^Accuracy=1337`, `^^Accuracy=-4`, `^^Acc=228`;

* `^^Speed=<Значение>` или `^^Spd=<Значение>` - изменяет Скорость кастомного персонажа на заданное значение;
<br/>Примеры: `^^Speed=40`, `^^Speed=-6`, `^^Spd=69`;

* `%%<ID способности>` - изменяет специальную способность кастомного персонажа;
<br/>Примеры: `%%Charge`, `%%WerewolfLunge`, `%%MindControl`;
<br/>ID способностей смотрите тут - [All Ability IDs.txt](https://github.com/Abbysssal/ECTD/blob/master/All%20Ability%20IDs.txt);

* `!!items` - показывает список ID всех добавленных предметов у кастомного персонажа;

* `!!traits` - показывает список ID всех добавленных особенностей у кастомного персонажа;

* `::Skin|Hair|Legs|Body|Eyes` - получает цвет кожи/волос/ног/тела/глаз у кастомного персонажа;

* `::Skin|Hair|Legs|Body|Eyes=<Цвет>` - изменяет цвет кожи/волос/ног/тела/глаз у кастомного персонажа на заданный цвет;
<br/>Примеры: `::Skin=Purple`, `::Eyes=RobotSkin`, `::Hair=255|12|86|220`, `::Body=23-62`, `::Legs=255,0,255,127`;
<br/>ID цветов смотрите тут - [All Color IDs.txt](https://github.com/Abbysssal/ECTD/blob/master/All%20Color%20IDs.txt);

## Новые мутаторы ##
Вы можете выбрать новые мутаторы на Базе!

* **[ECTD] Безлимитные наггетсы** - Если включен, позволяет вам набирать более 99 наггетсов. Если выключен, НЕ сбрасывает количество наггетсов.

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

* [Киборг](https://steamcommunity.com/sharedfiles/filedetails/?id=2092648215) и [Джедай](https://steamcommunity.com/sharedfiles/filedetails/?id=2098216250) [(Qenapp)](https://steamcommunity.com/id/Qenapp)
* [Видимый человек](https://steamcommunity.com/sharedfiles/filedetails/?id=2098168599) [(Abbysssal)](https://steamcommunity.com/id/Abbysssal/)

## Список изменений ##

#### ECTD v2.5 ####
* Убрал мутаторы "ECTD-RocketBullets" и "ECTD-GiantExplosions", потому что [aToM](https://github.com/Abbysssal/aToM) добавляет похожие мутаторы;
* Убрал мутаторы "ECTD-OneHitPlayer" и "ECTD-SuperSpeed", потому что они очень багованные;
* Добавил команды в чате!;
* "!help" перечисляет все доступные команды;
* "!item <ItemID> [Amount]" спавнит предмет у курсора;
* "!agent <AgentID>" или "!npc <AgentID>" спавнит персонажа у курсора;
* Исправил баг, из-за которого ECTD не распознавал ID предметов с '-' и другими символами;

#### ECTD v2.4.1 ####
* Исправил баг, из-за которого мутаторы ECTD заменяли оригинальные мутаторы в Меню мутаторов;

#### ECTD v2.4 ####
* Добавил новый мутатор "ECTD-NoLimitNuggets";
* Добавил новый мутатор "ECTD-OneHitPlayer";
* Добавил новый мутатор "ECTD-GiantExplosions";
* Добавил новый мутатор "ECTD-SuperSpeed";

#### ECTD v2.3 ####
* Портировал мод на BepInEx. Теперь не придётся постоянно обновлять мод на мелкие багфиксы;
* Теперь "ECTD-RocketBullets" работает на снаряды, выпущенные ловушками;
* Если команда удаления предмета или особенности не найдёт указанный ID, команда не будет выполнена;

#### ECTD v2.2: ####
* Добавил `::<Part>` для получения цвета части тела;
* Добавил `::<Part>=<Color>` для установки цвета части тела (+ кастомные цвета);

#### ECTD v2.1.1: ####
* Со включенным "ECTD-RocketBullets", Дробовик будет стрелять 3 ракеты вместо 1;

#### ECTD v2.1: ####
* Добавил новый мутатор "ECTD-RocketBullets";

#### ECTD v2.0: ####
* Переписал часть кода;
* Команды теперь будут применять изменения к файлам кастомных персонажей. Это значит, что теперь некоторые предметы и особенности будут работать у других игроков без мода;
* Убрал `+<Item>++<Count>`, потому что он не будет работать с новой структурой;
* Заменил `+<Item>` на `++<Item>`;
* Заменил `*<Trait>` на `**<Trait>`;
* Заменил `^<Stat>=<Value>` на `^^<Stat>=<Value>`;
* Добавил `--<Item>` для убирания предметов;
* Добавил `//<Trait>` для убирания особенностей;
* Добавил `%%<Ability>` для установки специальных способностей;
* Добавил `!!items` для перечисления добавленных предметов;
* Добавил `!!traits` для перечисления добавленных особенностей;

#### ~~ECTD v1.4:~~ ####
* ~~Теперь команды будут спавнить предметы/НПС туда, куда указывает курсор;~~

#### ~~ECTD v1.3:~~ ####
* ~~Портировал мод на uMod Framework (UMF);~~
* ~~Добавил консольную команду `/item <ID>`;~~
* ~~Добавил консольную команду `/npc <ID>`;~~

#### ECTD v1.2: ####
* `^<Stat>=<Value>` теперь работает и на отрицательных значениях;

#### ECTD v1.1: ####
* Добавил команду `+<Item>++<Count>`;
* Добавил команду `*<Trait>`;
* Добавил команду `^<Stat>=<Value>`;

#### ECTD v1.0 (старое название - Any Items Mod): ####
* Добавил команду `+<Item>`.