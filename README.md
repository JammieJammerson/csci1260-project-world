Jacob Hammonds 
Section: CSCI 1260

 This is a small tournament world that models players, teams, matches, scheduling, and logging.

Language: C#

How to run: Open in Visual Studio and run.

Design questions:

1. Explain your two diamonds.
   Aggregation: PlayerManager holds Player objects that are created in Program and passed in via Add. PlayerManager does not own those Player instances exclusively; if the manager is removed the Player objects remain live elsewhere (for example the players list in Program). To change this diamond into composition, modify PlayerManager so it constructs its Player instances internally (for example add factory methods that call new) and stop accepting externally created Player objects. Composition: Scheduler creates and owns Round objects inside BuildRounds; Rounds are private parts and are removed when the Scheduler is discarded. To change this diamond into aggregation, move Round to a public type and require callers (Program) to create Round instances and pass them into Scheduler instead of Scheduler creating them.

2. Justify your interface.
   IDescribe is implemented by GameEntity (and thus Player, Team, Spectator) and also implemented by Score. Score does not inherit from GameEntity, so Describe cannot be placed only on the GameEntity base class without forcing Score into that inheritance chain. The interface provides a lightweight contract that unrelated types can implement to supply a human-readable description without imposing a common superclass.

3. Adding a new kind.
   New kind is a Coach (a kind of Participant that mentors players). Files to create is the Coach.cs (implements Coach : Participant). File to edit is the Program.cs. The PlayerManager does not need to change because it manages Player objects only. Coaches are a different kind and are not stored by PlayerManager, so the manager class remains unchanged.

 Recording: https://youtu.be/Y_IP2ZJ2Y0U
