# LegoLand_1032
Project: LEGO LAND

About: Collecting all golds to win, also avoid 3 enemies and 1 boss.

How to play: Click on the floor to move.

Design Pattern: 1.SOLID's OCP principles are relevant to this task, with the WinSfx code separating the operation of playing the sfx sound when winning from the logic of whether the player wins or not, following the Single Responsibility Principle: just play the sound. - apply Observer Pattern

2.The ButtonManager code is a code that is created to create a function to Undo and Redo, to increase the power value, where in the function will be a command that specifies the Command Manager and the function to be performed, it is like pressing the remote control to make the Command Manager code work in accordance with the command in the ButtonManager code. – apply Command Pattern

The Boss have the state codes such as, BossIntroState, BossChaseStage, and BossEnrageState, those are control by the BossStateMachine code to break down the boss's routine into sections that can be developed separately. – apply State Pattern
