using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaCodeChallengeWar
{
    public class HousePlayer
    {
        private DeckOfCards _deckOfCards;
        private GamePlayer _player1;
        private GamePlayer _player2;

        public HousePlayer(DeckOfCards deckOfCards, GamePlayer player1, GamePlayer player2)
        {
            this._deckOfCards = deckOfCards;
            this._player1 = player1;
            this._player2 = player2;
        }

    }
}