#Молния (The lightning) - Unity3d version: 5.3.5

---
 
 Unity3d version: 5.3.5
 
---

**(ru)**

&nbsp; &nbsp; &nbsp; &nbsp; Молния - это мини игра для Android, которую надо было сделать как тестовое задание для одной компании.

**Суть**

&nbsp; &nbsp; &nbsp; &nbsp; По игровой поверхности двигаются существа: добрые и злые.  С каждым интервалом времени появляются новые существа. Игрок нажатием на экран вызывает молнию, которой может убивать существ, за которых начисляются очки. В итоге игрок должен набрать как можно больше очков за отведенное время.

**Исходные данные**
  - Доброе существо имеет зеленый цвет, постоянный размер, за его гибель очки вычитаются.
  - Злое существо имеет красный цвет, может быть разного размера,  за его гибель очки прибавляются.
  - При попадании на существо молнией - оно уменьшается в размерах
  - При достижении определенного минимального размера - существо умирает
  - Чем больше существо, тем медленнее оно передвигается. Чем меньше существо - тем быстрее оно движется.
  - Если игрок дотрагивается до экрана одним пальцем и не двигает, то показывается кнопка "молния", если касается одним пальцем и двигает его, то появляется молния и двигается как змейка в сторону перемещения пальца. При этом урон от молнии постоянный.
  - Если игрок касается экрана двумя пальцами, то молния возникает между двумя точками прикосновений. Игрок может также двигать два пальца по экрану, заставляя молнию двигаться вместе с ними.
  - Если пользователь касается двумя пальцами, то чем больше расстояние между пальцами - тем больше повреждений получает существо, чем меньше расстояние - тем меньше повреждений.
  - По истечении игрового времени отображается количество набранных очков и кнопки "Главное меню" - для выхода на начальный экран и "Начать заново" - чтобы повторить игру.
  - В игре в нижнем правом углу должна быть кнопка "Назад", при нажатии на которую появляется меню, в котором есть кнопка "Главное меню" - для выхода на начальный экран и "Продолжить" - для продолжения игры.
    
---

### Как запустить игру

&nbsp; &nbsp; &nbsp; &nbsp; Достаточно взять готовый `apk` файл из папки `CompiledApk` и запустить на Android.


### Скриншоты

![](http://gamedev.iprogrammer.pro/5_testTaskIceCat/screenshots/screenshot_1.jpg)

![](http://gamedev.iprogrammer.pro/5_testTaskIceCat/screenshots/screenshot_2.jpg)

### Небольшое видео

[![game video](http://gamedev.iprogrammer.pro/5_testTaskIceCat/screenshots/screenshot_3.jpg)](https://youtu.be/iXfbHYbQQrA "game video - click to watch")

---


**(en)**

&nbsp; &nbsp; &nbsp; &nbsp; Lightning - mini game for Android, which had to be done as a test task for one company.

**The game**

&nbsp; &nbsp; &nbsp; &nbsp; There is a game area where good and evil creatures are moving. Creature is spawning every some time interval. Player has to Invoke the lightning, wich can kill the creatures. Creatures give some points. As the result: player has to score points as many as possible within the allotted time.

**Initial conditions**


  - Good creature has green color, permanent size, if it dies - points have to be subtracted
  - Evil creature has red color, has random size, it it dies - points have to be added
  - If a creature crosses the lightning - creature's size should decrease
  - If creature gets minimum size - creature dies
  - The greater size of a creature, the slower it's moving. The smaller size of a creature, the faster it's moving
  - If player touches the screen with one finger and do not moves it, the "lightning" button appears. If player touches the screen with one finger and moves it, the lightning appears and it is moving like a snake in finger direction. Damage from that kind of lightning is constant
  - If player touches the screen with two fingers, the lightning appears between these points of touches. Player can move these fingers around the screen. The lightning moves together with the fingers.
  - If player touches the screen with two fingers: the bigger distance between fingers, the bigger damage gets a creature. The smaller distance, the smaller damage. 
  - If time is up - the result screen appears. Player can see total points that he scored, "Main menu" button (if he wants to go on Main screen) and "Restart" button (if he wants to play the game again).
  - At the right bottom corner should be "Back" button. If player clicks it, then menu appears. It contains "Main menu" button (if he wants to go on Main screen) and "Resume" button (if he wants to resume play the game)
  
---
  
### How to launch the game

&nbsp; &nbsp; &nbsp; &nbsp; You can get `apk` from the `CompiledApk` folder and install it on Android.

### Screenshots and a little preview

You can see it above at **ru** section of description :)
