using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Tournament tournament = new Tournament("Championship");


        var players = new List<Player>();
        var manager = new PlayerManager();
        string dataPath = "data.txt";
        if (System.IO.File.Exists(dataPath))
        {
            var lines = System.IO.File.ReadAllLines(dataPath);
            int lineNo = 0;
            foreach (var line in lines)
            {
                lineNo++;
                if (string.IsNullOrWhiteSpace(line)) continue;
                try
                {
                    var parts = line.Split('|');
                    if (parts.Length < 6) throw new FormatException($"Line {lineNo} does not have enough fields.");
                    string name = parts[0];
                    string gamertag = parts[1];
                    if (!int.TryParse(parts[2], out int score)) throw new FormatException($"Score is invalid on line {lineNo}");
                    string rank = parts[3];
                    string game = parts[4];
                    string playStyle = parts[5];
                    string team = parts.Length >= 7 ? parts[6] : null;

                    var p = new Player(name, gamertag, score, rank, game, playStyle, team);
                    players.Add(p);
                    manager.Add(p);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load line {lineNo}: {ex.Message}");
                }
            }
        }

        Console.WriteLine("=== 1. Classes, UML, and Relationships ===");
        Console.WriteLine($"Loaded {players.Count} players into manager.");


        var teams = new List<Team>();

        teams.Add(new Team("Team A", players.FindAll(p => p.TeamName == "Team A")));
        teams.Add(new Team("Team B", players.FindAll(p => p.TeamName == "Team B")));

        var scheduler = new Scheduler();
        scheduler.BuildRounds(1, teams);
        var schedReport = scheduler.RunAll();
        Console.WriteLine("\nScheduler output:");
        Report.Print(schedReport);


        var entities = new List<GameEntity>();
        foreach (var t in teams) entities.Add(t);
        foreach (var p in players) entities.Add(p);
        entities.Add(new Spectator("Observer", "Obs1", 0, "Balcony"));

        Console.WriteLine("=== 2. Inheritance and Abstraction ===");
        Console.WriteLine("\nDescribing all entities via base type: (polymorphism)");
        foreach (var e in entities)
        {
            var s = e.Describe();
            Report.Print(s);
        }

        Console.WriteLine("=== 3. Polymorphism and Interfaces ===");


        string UseDescriber(IDescribe d)
        {
            if (d is IDescribe) { }
            return d.Describe();
        }

        Console.WriteLine("\nCalling interface-based method with Player and Team:");
        if (players.Count > 0) Report.Print(UseDescriber(players[0]));
        Report.Print(UseDescriber(teams[0]));


        var keys = new List<GamerKey>
        {
            new GamerKey("John Doe","TheGamerGod42"),
            new GamerKey("Jane Smith","JaneTheGreat"),
            new GamerKey("John Doe","TheGamerGod42"),
            new GamerKey("Randy Marsh","RandyTheRanger")
        };

        Console.WriteLine("=== 4. Built in Contracts and Collections ===");
        Report.Print($"\nGamerKey list count before HashSet: {keys.Count}");
        var set = new HashSet<GamerKey>(keys);
        Report.Print($"GamerKey count after HashSet dedupe: {set.Count}");

        Report.Print("\nSorting GamerKey list using IComparable (natural order):");
        keys.Sort();
        foreach (var k in keys) Report.Print(k.ToString());

        Report.Print("\nSorting same list by Name via IComparer:");
        keys.Sort(new GamerKeyNameComparer());
        foreach (var k in keys) Report.Print(k.ToString());

        Report.Print("\nSorting same list by Gamertag via second IComparer:");
        keys.Sort(new GamerKeyGamertagComparer());
        foreach (var k in keys) Report.Print(k.ToString());

        string logPath = "app.log";
        Console.WriteLine("=== 5. Exceptions and Files ===");

        try
        {
            using (var logger = new Logger(logPath))
            {
                logger.Log("Starting risky operation");

                throw new InvalidOperationException("Intentional failure inside using block");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught exception: {ex.Message}");
        }


        if (System.IO.File.Exists(logPath))
        {
            Console.WriteLine("\nLog file contents:");
            Report.Print(System.IO.File.ReadAllText(logPath));
        }


        if (teams.Count >= 2)
        {
            var tourReport = tournament.RunTournament(players);
            Report.Print(tourReport);
        }


    }
}
