using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaCodeChallengeWar
{
    public class PlayingCard
    {
        public int PlayingCardID { get; set; }
        public RankType Rank { get; set; }
        public int RankValue { get; set; }
        public SuiteType Suite { get; set; }
        public string Name { get; set; }

        public enum RankType {Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace};
        public enum SuiteType { Clubs = 1, Diamonds, Hearts, Spades };

        public PlayingCard(int value, SuiteType suite)
        {
            if ((value < 2) || (value > 14))
            {
                throw new ArgumentOutOfRangeException();
            }
            
            this.RankValue = value;
            this.Suite = suite;
            assignRankAndNameAndID();
        }

        public override string ToString()
        {
            return this.Name;
        }

        private void assignRankAndNameAndID()
        {
            switch (this.RankValue)
            {
                case 2:
                    this.Rank = RankType.Two;
                    break;
                case 3:
                    this.Rank = RankType.Three;
                    break;
                case 4:
                    this.Rank = RankType.Four;
                    break;
                case 5:
                    this.Rank = RankType.Five;
                    break;
                case 6:
                    this.Rank = RankType.Six;
                    break;
                case 7:
                    this.Rank = RankType.Seven;
                    break;
                case 8:
                    this.Rank = RankType.Eight;
                    break;
                case 9:
                    this.Rank = RankType.Nine;
                    break;
                case 10:
                    this.Rank = RankType.Ten;
                    break;
                case 11:
                    this.Rank = RankType.Jack;
                    break;
                case 12:
                    this.Rank = RankType.Queen;
                    break;
                case 13:
                    this.Rank = RankType.King;
                    break;
                case 14:
                    this.Rank = RankType.Ace;
                    break;
            }

            this.Name = this.Rank.ToString() + " of " + this.Suite.ToString();
            this.PlayingCardID = (100 * (int)(this.Suite)) + this.RankValue;
        }
    }
}