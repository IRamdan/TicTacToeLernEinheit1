using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTacToeLernEinheit1.Models
{
    

    public class Player
    {
        internal string Name;
        internal int Wins;

        public Player(string Playername, int PlayerWins)
        {
            Name = Playername;
            Wins = PlayerWins;
        }

    }
}
