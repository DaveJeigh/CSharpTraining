using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaCodeChallengeWar
{
    public class GamePlayer
    {
        public string Name { get; set; }
        public List<PlayingCard> HandOfCards { get; set; }

        public GamePlayer(string name)
        {
            this.Name = name;
            this.HandOfCards = new List<PlayingCard>();
        }
    }
}