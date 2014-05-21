using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamGen
{
    class Team
    {
        public List<Player> players { get; private set; }
        public int teamNumber { get; private set; }

        public Team(int teamNumber)
        {
            this.teamNumber = teamNumber;
            Initialize();
        }

        public void Initialize()
        {
            players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
    }
}
