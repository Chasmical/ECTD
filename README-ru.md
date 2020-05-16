## Ссылки ##
* [Скачать ECTD](https://github.com/Abbysssal/ECTD/releases)
* [ECTD на GitHub](https://github.com/Abbysssal/ECTD)
* [Руководство в Стиме (англ.)](https://steamcommunity.com/sharedfiles/filedetails/?id=2093706214)

## Содержание ##
1.	[Что такое ECTD?](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#ectd-edit-characters-through-description)
2.	[Установка](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#установка)
3.	[Деинсталляция](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#деинсталляция-это-также-уберёт-всю-кастомную-локализацию)
4.	[Как пользоваться ECTD?](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#как-добавлять-предметыособенности)
5.	[Список команд](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#список-команд)
6.	[Новые мутаторы](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#новые-мутаторы)
7.	[Персонажи, созданные с ECTD](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#персонажи-созданные-с-ectd)
8.	[Список изменений](https://github.com/Abbysssal/ECTD/blob/master/README-ru.md#список-изменений)

## ECTD (Edit Characters Through Description) ##
#### Версия игры: v89k<br/>Версия мода: v2.1.1<br/>Автор мода: Abbysssal#2020 ####

Вы когда-нибудь хотели создать интересного кастомного персонажа, но во внутриигровом редакторе не было всех предметов и особенностей, которые вам были нужны? Вообщем, этот мод позволяет вам добавлять недоступные в редакторе предметы, особенности и способности вашим кастомным персонажам!

А ещё, этот мод добавляет один мутатор "ECTD-RocketBullets" - Все пули и снаряды заменяются на ракеты. *Работает и на игроках, и на НПС.* Вот небольшое видео про этот мутатор: https://www.youtube.com/watch?v=XBQcWCL9fwo

## Установка ##
1.	[Скачайте свежий релиз ECTD](https://github.com/Abbysssal/ECTD/releases);
2.  Перенесите файл "Assembly-CSharp.dll" из архива в папку /Steam/SteamApps/common/Streets of Rogue/StreetsOfRogue_Data/Managed/ (Заменить по необходимости);
3.  Готово. Запускайте игру и наслаждайтесь!

## Деинсталляция (Это также уберёт всю кастомную локализацию!) ##
1.  Нажмите правой кнопкой мыши по Streets of Rogue в Steam и выберите "Свойства";
2.  Выберите категорию "Локальные файлы";
3.  Нажмите "Проверить целостность файлов игры".

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

* ECTD-RocketBullets - заменяет все пули и снаряды на ракеты. Да настанет настоящий хаос!

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

* [Cyborg](https://steamcommunity.com/sharedfiles/filedetails/?id=2092648215) [(Qenapp)](https://steamcommunity.com/id/Qenapp)
* [Visible Man](https://steamcommunity.com/sharedfiles/filedetails/?id=2098168599) [(Abbysssal)](https://steamcommunity.com/id/Abbysssal/)

## Список изменений ##

#### ECTD v2.2: ####
* Добавил `::<Part>` для получения цвета части тела;
* Добавил `::<Part>=<Color>` для установки цвета части тела (+ кастомные цвета);

#### ECTD v2.1.1: ####
* Со включенным "ECTD-RocketBullets", Дробовик будет стрелять 3 ракеты вместо 1;

#### ECTD v2.1: ####
* Добавлен мутатор "ECTD-RocketBullets" - заменяет все пули и снаряды на ракеты;

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