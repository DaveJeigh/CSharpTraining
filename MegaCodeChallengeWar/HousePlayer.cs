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
        public string Result { get; set; }
        public int NumberOfRounds { get; set; }

        public HousePlayer(DeckOfCards deckOfCards, GamePlayer player1, GamePlayer player2, WarGameBoard gameBoard)
        {
            this._deckOfCards = deckOfCards;
            this._player1 = player1;
            this._player2 = player2;
            this._warGameBoard = gameBoard;
            this.Result = "";
            this.NumberOfRounds = 0;
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

            this.Result += (string.Format("{0} is dealt the {1}<br />", player.Name, card.Name ));
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
                Debug.Assert(AreThereMoreCards(), "Heading to a Battle with NO cards");
                
                // Main Battle Routine - and calls War if needed, recursively
                if (!Battle())
                {
                    Debug.Print("Ran out of cards");
                    break;
                }
            }

            if (_player1.HandOfCards.Count > _player2.HandOfCards.Count)
            {
                this.Result += string.Format("{0} wins!<br />", _player1.Name );
            }
            else if (_player1.HandOfCards.Count < _player2.HandOfCards.Count)
            {
                this.Result += string.Format("{0} wins!<br />", _player2.Name );
            }
            else
            {
                Debug.Assert(false, "This should not happen");
                this.Result += string.Format("Nobody wins - we have a tie!<br />");
            }

            this.Result += string.Format("{0}: {1}<br />", _player1.Name, _player1.HandOfCards.Count.ToString());
            this.Result += string.Format("{0}: {1}<br />", _player2.Name, _player2.HandOfCards.Count.ToString());

            Debug.Print(string.Format("Finished Conduct of Battles - Finished with more Cards = {0}", StillMoreCards.ToString()));
        }

        private bool AreThereMoreCards()
        {
            if ((_player1.HandOfCards.Count > 0) && (_player2.HandOfCards.Count > 0)) return true;
            else return false;
        }

        public bool Battle()
        {
            PlayingCard card1;
            PlayingCard card2;

            // Check if each have a card to play with
            if ((_player1.HandOfCards.Count < 1) || (_player2.HandOfCards.Count < 1))
            {
                // Dang, not enough cards to play - somebody lost
                //  Leave bearing the bad news
                return false;
            }

            // Take card from Player, put it on the board - then for other player
            card1 = TakeCardPutOnBoard(_player1, _warGameBoard.player1Board);
            card2 = TakeCardPutOnBoard(_player2, _warGameBoard.player2Board);

            this.Result += string.Format("Battle Cards: {0} versus {1}<br />", card1.ToString(), card2.ToString());
            //this.Result += "Bounty ...<br />";
            //this.Result += string.Format("&nbsp{0}<br />&nbsp{1}<br />", card1.ToString(), card2.ToString());

            if (card1.RankValue > card2.RankValue)
            {
                Debug.Print("Player 1 Won the Battle");
                WinnerTakesBoard(_player1);
                this.NumberOfRounds++;

                this.Result += string.Format("<h4>{0} wins!</h4><br />", _player1.Name);
            }
            else if (card1.RankValue < card2.RankValue)
            {
                Debug.Print("Player 2 Won the Battle");
                WinnerTakesBoard(_player1);
                this.NumberOfRounds++;

                this.Result += string.Format("<h4>{0} wins!</h4><br />", _player2.Name);
            }
            else if (card1.RankValue == card2.RankValue)
            {
                Debug.Print("The Battle was a Tie - Time For WAR!!");
                this.Result += "***************WAR***************<br /><br />";

                // Check if there are enough cards to conduct War
                if ((_player1.HandOfCards.Count >= 3) && (_player2.HandOfCards.Count >= 3))
	            {
                    // Good - enough cards to continue to play
                    // After the war, if no cards left (false) then leave
                    if (!War())
                    {
                        return false;
                    }
	            }
                else
                {
                    // Not enough cards left by someone
                    //  so leave - and figure out who won somewhere else
                    return false;
                }
            }
            else
            {
                Debug.Assert(false, "Should never get here");
            }

            return AreThereMoreCards();
        }

        private bool War()
        {
            PlayingCard card1;
            PlayingCard card2;
            PlayingCard card3;
            PlayingCard card4;
            PlayingCard card5;
            PlayingCard card6;

            // Check if each have at least 3 cards to play with
            if ((_player1.HandOfCards.Count < 3) || (_player2.HandOfCards.Count < 3))
            {
                // Dang, not enough cards to play - somebody lost
                //  Leave bearing the bad news
                return false;
            }

            // Take 3 cards from Player, put them on the board - then for other player
            card1 = TakeCardPutOnBoard(_player1, _warGameBoard.player1Board);
            card2 = TakeCardPutOnBoard(_player1, _warGameBoard.player1Board);
            card3 = TakeCardPutOnBoard(_player1, _warGameBoard.player1Board);
            card4 = TakeCardPutOnBoard(_player2, _warGameBoard.player2Board);
            card5 = TakeCardPutOnBoard(_player2, _warGameBoard.player2Board);
            card6 = TakeCardPutOnBoard(_player2, _warGameBoard.player2Board);

            this.Result += string.Format("Battle Cards: {0} versus {1}<br />", card2.ToString(), card5.ToString());
            
            // Compare the Middle Card from each side
            if (card2.RankValue > card5.RankValue)
            {
                Debug.Print("Player 1 Won the War");
                WinnerTakesBoard(_player1);
                this.NumberOfRounds++;
                this.Result += string.Format("<h4>{0} wins!</h4><br />", _player1.Name);
            }
            else if (card2.RankValue < card5.RankValue)
            {
                Debug.Print("Player 2 Won the War");
                WinnerTakesBoard(_player2);
                this.NumberOfRounds++;
                this.Result += string.Format("<h4>{0} wins!</h4><br />", _player2.Name);
            }
            else if (card2.RankValue == card5.RankValue)
            {
                Debug.Print("The War was a Tie - Time For ANOTHER WAR!!");

                // Check if each have at least 3 cards to play with
                if ((_player1.HandOfCards.Count < 3) || (_player2.HandOfCards.Count < 3))
                {
                    // Dang, not enough cards to play - somebody lost
                    //  Leave bearing the bad news
                    return false;
                }

                // Good - enough cards to continue to play
                // After the war, if no cards left (false) then leave
                // Isn't Recursion lovely?
                if (!War())
                {
                    return false;
                }
            }
            else
            {
                Debug.Assert(false, "Should never get here");
            }

            return AreThereMoreCards();
        }

        private PlayingCard TakeCardPutOnBoard(GamePlayer player, List<PlayingCard> boardSlot)
        {
            PlayingCard card;

            card = player.HandOfCards.First();
            player.HandOfCards.Remove(card);
            boardSlot.Add(card);

            return card;
        }

        private void WinnerTakesBoard(GamePlayer player)
        {
            int i = player.HandOfCards.Count;
            int j = _warGameBoard.player1Board.Count;
            int k = _warGameBoard.player2Board.Count;
            
            // This should be the end result when it is all done
            int endResult = i + j + k;
            
            // Pretty sure the two boards will always be equal
            Debug.Assert(j == k);

            this.Result += "Bounty ...<br />";
            //this.Result += string.Format("&nbsp{0}<br />&nbsp{1}<br />", card1.ToString(), card2.ToString());

            // Copy all the cards from Player1's board to the winner's hand
            foreach (PlayingCard card in _warGameBoard.player1Board )
            {
                this.Result += string.Format("&nbsp{0}<br />", card.ToString());
                player.HandOfCards.Add(card);
            }
            // Now empty Player1's board
            _warGameBoard.player1Board.Clear();

            // Now do the same for Player2
            foreach (PlayingCard card in _warGameBoard.player2Board)
            {
                this.Result += string.Format("&nbsp{0}<br />", card.ToString());
                player.HandOfCards.Add(card);
            }
            _warGameBoard.player2Board.Clear();

            // Double check to make sure it worked correctly
            Debug.Assert(player.HandOfCards.Count == endResult);
        }


    }
}