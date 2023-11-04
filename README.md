<div align="center"><img src="https://github.com/itspixxel/Crabs-Ahoy/blob/amethyst/Assets/UI/CrabsAhoyIcon.png" width=80></div>
<h1 align="center">Sarthak (Pixx) Sachdeva</h1>
<p align="center"><strong>Crabs Ahoy</strong>
<br><em>2D platformer made with Unity!</em></p>
<br/>
<div align="center"><img src="demo.gif"></img></div>
<h2>About</h2>

Crabs Ahoy! is a challenging 2D platformer where the player takes control of Crabby the crab. Unlike any other platformer, Crabby moves side to side on his own so the player has to time their jumps precisely in order to beat the levels which makes the game unique and fun.

<h2>Gameplay Mechanics / Implemented Features:</h2>
Crabs Ahoy! has a wide range of gameplay mechanics as follows:

1. Advanced movement: Due to the uniqueness of the main mechanic, I had to implement a new character controller script completely from scratch. The character constantly moves side-to-side and the only control that the player gets is making the character jump which makes the game challenging and quite unique. The character controller features various platformer mechanics like coyote time that lets the player jump even a little bit after they've left a platform, and wall jumping, when touching a wall and not being grounded, the character automatically jumps between walls by bouncing off with a certain force using the rigidbody component.

2. Moving Platforms: Platforms that have a defined start and end point with visual aid gizmos that draw in the editor and an advanced inspector view where one can adjust the speed and wait time for different moving platforms.

3. Stopwatch: I implemented an advanced timer script that has options to count down, up, and until a limited time. It keeps track of the time spent on each level so players can compare their times with others and compete on how fast they can beat a level!
 

4. Shooter Traps: 
By attaching a projectile spawner script to different types of shooting enemies and a projectile script that spawns and moves the projectiles at a given speed attached to cannons and wood spikes. These are the enemies I implemented into the game.
     a. Totems: These enemies shoot little wooden spikes in a given direction, be very careful as they're super hard to see and dodge. Causes 1 heart of damage if hit.
     b. Cannons: Just classic cannons that shoot cannonballs in a given direction which can cause 1 heart of damage to the player.

5. Spike Traps: These sharp spikes are not to be taken lightly, if the player touches a spike, they're instantly teleported to the start of the current level, and a heart of health is taken off. Tread carefully!

6. Health System:
The player starts off with 6 hearts, the health system listens out for every time the player takes damage and then sets the color of the last item in the array of hearts to black and the health to 1 less. When the player's health hits 0, the player is sent back to level 1 to start all over again (the game loop).

7. Collectibles: 
     a. Hearts: The player can collect hearts only if the player has taken damage (otherwise the heart isn't picked up)
     b. Coins: Coins are scattered throughout the levels for the player to collect which are then added to a variable that keeps track of the coins the player has collected in the level and displays it on the HUD.

8. Levels: I have implemented 2 different and unique levels that transition seamlessly when the player reached the end of a level. If the player reaches the last level as defined in the Build Settings for the game then the game shows the game won screen and the player is told to exit the game by pressing Q.

9. Sound Effects: The game features great audio feedback for the player. Things like background music, jump sound effect, and a damage sound effect really immerse the player into the experience.

<h2>Project status</h2>
<div><img src="https://progress-bar.dev/100"></div>
