#������ (The lightning)

**(ru)**

&nbsp; &nbsp; &nbsp; &nbsp; ������ - ��� ���� ���� ��� Android, ������� ���� ���� ������� ��� �������� ������� ��� ����� ��������.

**����**

&nbsp; &nbsp; &nbsp; &nbsp; �� ������� ����������� ��������� ��������: ������ � ����.  � ������ ���������� ������� ���������� ����� ��������. ����� �������� �� ����� �������� ������, ������� ����� ������� �������, �� ������� ����������� ����. � ����� ����� ������ ������� ��� ����� ������ ����� �� ���������� �����.

**�������� ������**
  - ������ �������� ����� ������� ����, ���������� ������, �� ��� ������ ���� ����������.
  - ���� �������� ����� ������� ����, ����� ���� ������� �������,  �� ��� ������ ���� ������������.
  - ��� ��������� �� �������� ������� - ��� ����������� � ��������
  - ��� ���������� ������������� ������������ ������� - �������� �������
  - ��� ������ ��������, ��� ��������� ��� �������������. ��� ������ �������� - ��� ������� ��� ��������.
  - ���� ����� ������������� �� ������ ����� ������� � �� �������, �� ������������ ������ "������", ���� �������� ����� ������� � ������� ���, �� ���������� ������ � ��������� ��� ������ � ������� ����������� ������. ��� ���� ���� �� ������ ����������.
  - ���� ����� �������� ������ ����� ��������, �� ������ ��������� ����� ����� ������� �������������. ����� ����� ����� ������� ��� ������ �� ������, ��������� ������ ��������� ������ � ����.
  - ���� ������������ �������� ����� ��������, �� ��� ������ ���������� ����� �������� - ��� ������ ����������� �������� ��������, ��� ������ ���������� - ��� ������ �����������.
  - �� ��������� �������� ������� ������������ ���������� ��������� ����� � ������ "������� ����" - ��� ������ �� ��������� ����� � "������ ������" - ����� ��������� ����.
  - � ���� � ������ ������ ���� ������ ���� ������ "�����", ��� ������� �� ������� ���������� ����, � ������� ���� ������ "������� ����" - ��� ������ �� ��������� ����� � "����������" - ��� ����������� ����.
    
---

### ��� ��������� ����

&nbsp; &nbsp; &nbsp; &nbsp; ���������� ����� ������� `apk` ���� �� ����� `CompiledApk` � ��������� �� Android.


### ���������

![](http://gamedev.iprogrammer.pro/5_testTaskIceCat/screenshots/screenshot_1.jpg)

![](http://gamedev.iprogrammer.pro/5_testTaskIceCat/screenshots/screenshot_2.jpg)

### ��������� �����

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
