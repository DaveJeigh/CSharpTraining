using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MegaCodeChallengeWar;

namespace MegaCodeChallengeWar.Tests
{
    [TestClass]
    public class UnitTestCard
    {
        [TestMethod]
        public void TestConstructor()
        {
            PlayingCard playingCard = new PlayingCard(2, PlayingCard.SuiteType.Clubs);
            Assert.IsNotNull(playingCard);
        }

        [TestMethod]
        public void TestCardName()
        {
            PlayingCard playingCard = new PlayingCard(2, PlayingCard.SuiteType.Clubs);
            Assert.AreEqual(playingCard.Name, "Two of Clubs");
        }

        [TestMethod]
        public void CardID()
        {
            PlayingCard playingCard = new PlayingCard(2, PlayingCard.SuiteType.Clubs);
            Assert.AreEqual(playingCard.PlayingCardID, 102);
        }

        [TestMethod]
        public void CardRank()
        {
            PlayingCard playingCard = new PlayingCard(2, PlayingCard.SuiteType.Clubs);
            Assert.AreEqual(playingCard.Rank, PlayingCard.RankType.Two);
        }

        [TestMethod]
        public void CardToString()
        {
            PlayingCard playingCard = new PlayingCard(2, PlayingCard.SuiteType.Clubs);
            Assert.AreEqual(playingCard.ToString(), "Two of Clubs");
        }

        [TestMethod]
        public void AceOfDiamonds()
        {
            PlayingCard playingCard = new PlayingCard(14, PlayingCard.SuiteType.Diamonds);
            Assert.AreEqual(playingCard.Name, "Ace of Diamonds");
            Assert.AreEqual(playingCard.PlayingCardID, 214);
        }

        [TestMethod]
        public void KingOfHearts()
        {
            PlayingCard playingCard = new PlayingCard(13, PlayingCard.SuiteType.Hearts );
            Assert.AreEqual(playingCard.Name, "King of Hearts");
            Assert.AreEqual(playingCard.PlayingCardID, 313);
        }

        [TestMethod]
        public void QueenOfSpades()
        {
            PlayingCard playingCard = new PlayingCard(12, PlayingCard.SuiteType.Spades );
            Assert.AreEqual(playingCard.Name, "Queen of Spades");
            Assert.AreEqual(playingCard.PlayingCardID, 412);
        }

        [TestMethod]
        public void TooLowValue()
        {
            try
            {
                PlayingCard playingCard = new PlayingCard(1, PlayingCard.SuiteType.Spades);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentOutOfRangeException);       
            }
        }

        [TestMethod]
        public void TooHighValue()
        {
            try
            {
                PlayingCard playingCard = new PlayingCard(15, PlayingCard.SuiteType.Spades);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentOutOfRangeException);
            }
        }

    }

    [TestClass]
    public class TestDeck
    {
        [TestMethod]
        public void DeckConstructor()
        {
            DeckOfCards cardDeck = new DeckOfCards(DeckOfCards.DeckType.Standard);
            Assert.IsNotNull(cardDeck);
        }

        [TestMethod]
        public void DeckConstructorNonStandard()
        {
            try
            {
                DeckOfCards cardDeck = new DeckOfCards(DeckOfCards.DeckType.StandardPlus2Jokers);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is NotImplementedException);
            }
        }

        [TestMethod]
        public void TestBuildDeck()
        {
            DeckOfCards cardDeck = new DeckOfCards(DeckOfCards.DeckType.Standard);
            cardDeck.BuildDeck();
            Assert.AreEqual(cardDeck.SetOfCards.Count, 52);
            Assert.AreEqual(cardDeck.SetOfCards[0].Name, "Two of Clubs");
            Assert.AreEqual(cardDeck.SetOfCards[1].Name, "Three of Clubs");
            Assert.AreEqual(cardDeck.SetOfCards[12].Name, "Ace of Clubs");
            Assert.AreEqual(cardDeck.SetOfCards[13].Name, "Two of Diamonds");
            Assert.AreEqual(cardDeck.SetOfCards[50].Name, "King of Spades");
            Assert.AreEqual(cardDeck.SetOfCards[51].Name, "Ace of Spades");
        }

        [TestMethod]
        public void TestShuffle()
        {
            DeckOfCards cardDeck = new DeckOfCards(DeckOfCards.DeckType.Standard);
            cardDeck.BuildDeck();
            cardDeck.ShuffleDeck();
            // Not a good test of Randomness - since a shuffle COULD produce this
            //  But the odds are very, very long 
            //  - and thus a very simple test to make sure a shuffle occurred
            Assert.IsFalse(
                (cardDeck.SetOfCards[0].Name == "Two of Clubs") &&
                (cardDeck.SetOfCards[51].Name == "Ace of Spades") &&
                (cardDeck.SetOfCards[12].Name == "Ace of Clubs")
                );
        }

        [TestMethod]
        public void TestPerformShuffles()
        {
            DeckOfCards cardDeck = new DeckOfCards(DeckOfCards.DeckType.Standard);
            cardDeck.BuildDeck();
            cardDeck.PerformShuffles();
            Assert.IsFalse(
                (cardDeck.SetOfCards[0].Name == "Two of Clubs") &&
                (cardDeck.SetOfCards[51].Name == "Ace of Spades") &&
                (cardDeck.SetOfCards[12].Name == "Ace of Clubs")
                );
        }

        [TestMethod]
        public void TestCutDeck()
        {
            DeckOfCards cardDeck = new DeckOfCards(DeckOfCards.DeckType.Standard);
            cardDeck.BuildDeck();
            cardDeck.CutDeck();
        }
    }

    [TestClass]
    public class TestHousePlayer
    {
        [TestMethod]
        public void HousePlayerConstructor()
        {
            DeckOfCards cardDeck = new DeckOfCards(DeckOfCards.DeckType.Standard);
            cardDeck.BuildDeck();
            //cardDeck.PerformShuffles();
            GamePlayer player1 = new GamePlayer("James");
            Assert.IsNotNull(player1.HandOfCards);

            GamePlayer player2 = new GamePlayer("Don");
            WarGameBoard gameBoard = new WarGameBoard();

            HousePlayer housePlayer = new HousePlayer(cardDeck, player1, player2, gameBoard);
            Assert.IsNotNull(housePlayer);
        }


        [TestMethod]
        public void HousePlayerDeal()
        {
            DeckOfCards cardDeck = new DeckOfCards(DeckOfCards.DeckType.Standard);
            cardDeck.BuildDeck();
            cardDeck.PerformShuffles();
            GamePlayer player1 = new GamePlayer("Jimmy");
            GamePlayer player2 = new GamePlayer("Teresa");
            WarGameBoard gameBoard = new WarGameBoard();

            HousePlayer housePlayer = new HousePlayer(cardDeck, player1, player2, gameBoard);
            housePlayer.DealCardsForWar();

            Assert.AreEqual(player1.HandOfCards.Count, 26);
            Assert.AreEqual(player2.HandOfCards.Count, 26);
        }

        [TestMethod]
        public void GameBoardConstructor()
        {
            WarGameBoard myBoard = new WarGameBoard();
            Assert.IsNotNull(myBoard);
        }

        [TestMethod]
        public void TestConductBattles()
        {
            DeckOfCards cardDeck = new DeckOfCards(DeckOfCards.DeckType.Standard);
            cardDeck.BuildDeck();
            cardDeck.PerformShuffles();
            GamePlayer player1 = new GamePlayer("Jimmy");
            GamePlayer player2 = new GamePlayer("Teresa");
            WarGameBoard gameBoard = new WarGameBoard();
            HousePlayer housePlayer = new HousePlayer(cardDeck, player1, player2, gameBoard);
            housePlayer.DealCardsForWar();

            housePlayer.ConductBattles(2000);

        }

    }
}
