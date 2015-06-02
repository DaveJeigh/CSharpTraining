using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaCodeChallengeWar
{
    public class WarGameBoard
    {
        public List<PlayingCard> player1Board { get; set; }
        public List<PlayingCard> player2Board { get; set; }
        public PlayingCard player1BattleCard { get; set; }
        public PlayingCard player2BattleCard { get; set; }

        public WarGameBoard()
        {
            this.player1Board = new List<PlayingCard>();
            this.player2Board = new List<PlayingCard>();
        }
    }
}