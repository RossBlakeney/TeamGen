using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamGen
{
    class Program
    {
        public const int MAX_NUMBER_OF_PLAYERS = 4;
        public const int NUMBER_OF_TEAMS = 2;
        public const int TEAM_ONE = 1;
        public const int TEAM_TWO = 2;

        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            List<Team> teams = new List<Team>();

            Player Travis = new Player("Travis");
            Player Neil = new Player("Neil");
            Player Tristan = new Player("Tristan");
            Player Ryan = new Player("Ryan");
            Player Ross = new Player("Ross");
            Player Leonidas = new Player("Leonidas");
            Player FaceHugs = new Player("Face-Hugs");

            Console.Write("TeamGen (v0.5)\n\t...BUCKLE UP!\n");

            // Check what players are playing
            while (true)
            {
                // Reset all players and clear the list of players
                foreach (Player player in players)
                {
                    player.Initialize();
                }
                players.Clear();

                // Check individual players
                RequestPlayerPresence(Travis, ref players);
                RequestPlayerPresence(Neil, ref players);
                RequestPlayerPresence(Tristan, ref players);
                RequestPlayerPresence(Ryan, ref players);
                RequestPlayerPresence(Ross, ref players);
                RequestPlayerPresence(Leonidas, ref players);
                RequestPlayerPresence(FaceHugs, ref players);

                // Not enough players playing
                if (players.Count != MAX_NUMBER_OF_PLAYERS)
                {
                    Console.Write("\nThere needs to be exactly {0} players...\n", MAX_NUMBER_OF_PLAYERS);
                    Console.Write("...Try again champ\n");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                if (players.Count == 0)
                {
                    Console.Write("[ERR]Players is empty\n");
                    return;
                }

                teams.Clear();

                // Create the desired number of teams
                for (int i = 0; i < NUMBER_OF_TEAMS; i++)
                {
                    teams.Add(new Team(i + 1));
                }

                // Create a shallow copy of all players in the game
                List<Player> playersWithoutATeam = new List<Player>();
                foreach (Player player in players)
                {
                    playersWithoutATeam.Add(player);
                }

                // Randomly assign teams
                int playersPerTeam = MAX_NUMBER_OF_PLAYERS / NUMBER_OF_TEAMS;
                Random random = new Random(DateTime.Now.Millisecond);
                int randomIndex = 0;
                Player randomlySelectedPlayer = null;
                foreach (Team team in teams)
                {
                    for (int i = 0; i < playersPerTeam; i++)
                    {
                        randomIndex = random.Next(0, playersWithoutATeam.Count - 1);
                        randomlySelectedPlayer = playersWithoutATeam[randomIndex];
                        team.AddPlayer(randomlySelectedPlayer);
                        playersWithoutATeam.Remove(randomlySelectedPlayer);
                    }
                }

                // Report teams to console
                Console.Write("----------------------------------------------\n");

                foreach (Team team in teams)
                {
                    Console.Write("\nTeam-{0}:", team.teamNumber);
                    foreach (Player player in team.players)
                    {
                        Console.Write("\t{0}", player.playerName);
                    }
                    Console.WriteLine();
                }

                bool userResponseIsGood = false;
                while (!userResponseIsGood)
                {
                    Console.Write("\nGenerate new Teams?\nY/N> ");
                    String responseString = Console.ReadLine().ToUpper().Trim();
                    if (responseString == "Y" || responseString == "N")
                    {
                        userResponseIsGood = true;
                        if (responseString == "N")
                        {
                            Console.Write("\nClosing...\n\n");
                            return;
                        }
                    }
                    else
                    {
                        Console.Write("\n...Try again champ\n");
                        userResponseIsGood = false;
                    }
                }
            }
        }

        private static void RequestPlayerPresence(Player player, ref List<Player> players)
        {
            if (players.Count == MAX_NUMBER_OF_PLAYERS)
            {
                return;
            }

            bool userResponseIsGood = false;
            String responseString;
            while (!userResponseIsGood)
            {
                Console.Write("\nIs {0} playing?\nY/N> ", player.playerName);
                responseString = Console.ReadLine().ToUpper().Trim();
                if (responseString == "Y" || responseString == "N")
                {
                    userResponseIsGood = true;
                    if (responseString == "Y")
                    {
                        player.isPlaying = true;
                        players.Add(player);
                        return;
                    }
                }
                else
                {
                    Console.Write("\n...Try again champ\n");
                    userResponseIsGood = false;
                }
            }
            return;
        }
    }
}
