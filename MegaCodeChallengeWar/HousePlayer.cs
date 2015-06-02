using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

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

        public void DealCardsForWar()
        {
            int i = 0;
            PlayingCard card;

            while (_deckOfCards.SetOfCards.Count != 0)
            {
                card = _deckOfCards.SetOfCards.First();

                if (IsEven(i)) dealToPlayer(card,_player1);
                else dealToPlayer(card, _player2);
                i++;
            }
        }

        private void dealToPlayer(PlayingCard card, GamePlayer player)
        {
            player.HandOfCards.Add(card);
            _deckOfCards.SetOfCards.Remove(card);

            Debug.Print(string.Format("{0} is dealt the {1}", player.Name, card.Name ));
        }

        public static bool IsEven(int value)
        {
            return ((value % 2) == 0);
        }
    }
}