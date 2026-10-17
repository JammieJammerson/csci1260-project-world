using System;
using System.Collections.Generic;

static void Main(string[] args)
{
    Tournament tournament = new Tournament("Championship");
    List<Player> players = new List<Player>();
    players.Add(new Player("John Doe", "TheGamerGod42", 100, "Bronze", "Marvel Rivals", "SinglePlayer"));
    players.Add(new Player("Jane Smith", "JaneTheGreat", 150, "Bronze", "World of Warcraft", "Multiplayer", "Team A"));
    players.Add(new Player("Randy Marsh", "RandyTheRanger", 200, "Silver", "World of Warcraft", "Multiplayer", "Team B"));
    players.Add(new Player("Eric Cartman", "RespectmaAthoratah", 250, "Gold", "World of Warcraft", "Multiplayer", "Team A"));
    players.Add(new Player("Kyle Broflovski", "KyleTheWise", 300, "Gold", "World of Warcraft", "Multiplayer", "Team B"));
    players.Add(new Player("Stan Marsh", "StanTheMan", 350, "Platinum", "World of Warcraft", "Multiplayer", "Team A"));
    players.Add(new Player("Butters Stotch", "ButtersTheButterfly", 400, "Platinum", "Hello Kitty Island Adventure", "Multiplayer", "Team B"));
    players.Add(new Player("PC Principal", "YouWannaBePC", 450, "Diamond", "World of Warcraft", "Multiplayer", "Team A"));
    players.Add(new Player("Doom Slayer", "IDontKnowWhy", 500, "Diamond", "World of Warcraft", "Multiplayer", "Team B"));

    tournament.RunTournament(players);
}
