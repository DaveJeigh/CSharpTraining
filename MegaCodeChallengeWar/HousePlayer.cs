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
        private WarGameBoard _warGameBoard;
        public string result { get; set; }

        public HousePlayer(DeckOfCards deckOfCards, GamePlayer player1, GamePlayer player2, WarGameBoard gameBoard)
        {
            this._deckOfCards = deckOfCards;
            this._player1 = player1;
            this._player2 = player2;
            this._warGameBoard = gameBoard;
            this.result = "";
        }

        public void DealCardsForWar()
        {
            int i = 0;
            PlayingCard card;

            // As long as we have more cards
            while (_deckOfCards.SetOfCards.Count != 0)
            {
                // Pick a Card, Any Card - Nope, just the first Card
                card = _deckOfCards.SetOfCards.First();

                // Take turns
                if (IsEven(i))  dealToPlayer(card, _player1);
                else            dealToPlayer(card, _player2);
                i++;
            }
        }

        private void dealToPlayer(PlayingCard card, GamePlayer player)
        {
            // Take from the Deck
            _deckOfCards.SetOfCards.Remove(card);
            
            // Give to player
            player.HandOfCards.Add(card);

            //Debug.Print(string.Format("{0} is dealt the {1}", player.Name, card.Name ));
        }

        private static bool IsEven(int value)
        {
            return ((value % 2) == 0);
        }

        public void ConductBattles(int NumberOfBattleRounds)
        {
            bool StillMoreCards = true;

            // Go until either we run out of cards
            //  OR for 20 rounds, which ever comes first 
            //  Does not include War rounds
            for (int i = 0; i < NumberOfBattleRounds; i++)
            {
                battle();
                
                StillMoreCards = AreThereMoreCards();
                
                if (!StillMoreCards) break;
            }


            Debug.Print("In ConductBattles Method");
        }

        private bool AreThereMoreCards()
        {
            if ((_player1.HandOfCards.Count > 0) && (_player2.HandOfCards.Count > 0)) return true;
            else return false;
        }

        private void battle()
        {

        }

    }
}