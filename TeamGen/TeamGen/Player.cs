using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamGen
{
    class Player
    {
        public String playerName { get; private set; }
        public bool isPlaying { get; set; }
        public Team team { get; set; }

        public Player(String playerName)
        {
            this.playerName = playerName;
            Initialize();
        }

        public void Initialize()
        {
            isPlaying = false;
            team = null;
        }
    }
}
