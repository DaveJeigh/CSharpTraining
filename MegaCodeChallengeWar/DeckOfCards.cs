using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace MegaCodeChallengeWar
{
    public class DeckOfCards
    {
        public DeckType DeckOfCardType { get; set; }
        public List<PlayingCard> SetOfCards = new List<PlayingCard>();
        private Random randomGen = new Random();

        public enum DeckType { Standard, StandardPlus2Jokers };

        public DeckOfCards(DeckType deckType)
        {
            if (deckType == DeckType.StandardPlus2Jokers) throw new NotImplementedException();
            
            this.DeckOfCardType = deckType;
        }

        public void BuildDeck(){
            PlayingCard iCard;

            foreach (PlayingCard.SuiteType suiteType in Enum.GetValues(typeof(PlayingCard.SuiteType)))
            {
                // For Standard Deck, Ranks are 2-10, Jack, Queen, King, Ace: i=2-14
                for (int i = 2; i < 15; i++)
                {
                    iCard = new PlayingCard(i, suiteType);
                    SetOfCards.Add(iCard);
                }
            }
        }

        public void ShuffleDeck()
        {
            // Based on Knuth shuffle (aka the Fisher-Yates shuffle)
            // Take the first card and swap it with another random card further down the deck
            // Then take the second card and do the same, but always from further down the deck
            for (int i = 0; i < this.SetOfCards.Count; i++)
            {
                // Set a random number to a number between the current location and the end
                int k = i + randomGen.Next(0, this.SetOfCards.Count - i);

                // Copy a reference of this card at this position to  
                //   just past the last card (a temp holding location)
                SetOfCards.Add(SetOfCards[i]);
                
                // Set this position now to the randomly chosen card
                SetOfCards[i] = SetOfCards[k];

                // And copy the original (now at the end) to where that random card was
                SetOfCards[k] = SetOfCards[SetOfCards.Count - 1];

                // Finally, remove the temporary card at the end
                SetOfCards.Remove(SetOfCards.ElementAt(SetOfCards.Count -1));

            }
        }

        public void PerformShuffles()
        {
            const int MinimumShuffles = 3;
            const int MaximumPossibleShuffles = 15;
            int NumberOfShuffles = randomGen.Next(MinimumShuffles, MaximumPossibleShuffles +1);
            int i;

            for (i = 0; i < NumberOfShuffles + 1; i++)
            {
                this.ShuffleDeck();
            }
        }

        public void CutDeck()
        {
            int cutSelect = randomGen.Next(0, this.SetOfCards.Count);

            for (int i = 0; i < cutSelect; i++)
            {
                SetOfCards.Add(SetOfCards.ElementAt(0) );
                SetOfCards.Remove(SetOfCards.ElementAt(0));
            }

        }

    }
}