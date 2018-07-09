# BoulderDash
### Prototype for a infinite runner game

Just testing out a prototype for an infinite runner version of my other game Bound. Keeping it very simple this time so read through this Readme to learn about the controls.


Goal is the run as long as possible and collect diamonds.
Avoid obstacles by stopping your movement or moving to the left and right.
If you stop too long, a big boulder will crush you.
That's about it.

Planned to be mobile, though no touch controls are implemented yet. This prototype currently just tests the concept of the game.



#### Controls
Left and Right arrow keys to move
Down arrow key to stop your player.
Spacebar to Disable all movement (for debug and testing purposes)

#### How To
Since it's a Unity project, you have to have Unity downloaded and installed. The game was developed using Unity 2018.2.0x-ImprovedPrefabs (the nested prefab beta version). So at least have this version to run it. From there, you can run it within Unity.

If you just want to play the game, open the Build folder and there should be a build of the game ready to play. The UI will be a bit wonky because it was designed around a mobile screen but the build is for a PC/Standalone.

#### Design
If you're looking to dig into the code, just go through the Scripts folder. Obstacles run on an obstacle timer system. GameData is an overarching static class that stores the data pertaining to a run. 


####Future
This prototype was designed to be a scaled down version of the BoundGame (which you can find as another repo). Just testing the concept of adapting it for an infinite runner.

Current plan is to build an even further scaled down version without the infinite runner component so no art assets would be needed. Will test this idea in a future repo. 


#### Assets
All art assets were found on the internet and not meant to be used for a final product, just as a placeholder. All found on OpenGameArt or SpritersResource
