using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaCodeChallengeWar
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            string result = "";
            const int NumberOfBattleRounds = 20;
            
            //SetupWar
            DeckOfCards cardDeck = new DeckOfCards(DeckOfCards.DeckType.Standard);
            cardDeck.BuildDeck();
            cardDeck.PerformShuffles();

            // Create Players and House
            GamePlayer gamePlayer1 = new GamePlayer("Tim");
            GamePlayer gamePlayer2 = new GamePlayer("Steve");
            WarGameBoard gameBoard = new WarGameBoard();
            HousePlayer housePlayer = new HousePlayer(cardDeck, gamePlayer1, gamePlayer2, gameBoard);

            //InitialDeal
            result = "<h2>Dealing cards ...</h2><br />";
            housePlayer.DealCardsForWar();

            result += housePlayer.Result;
            housePlayer.Result = "";
            
            //BattleRounds - includes WarRounds
            result += "<h2>Begin battle ...</h2><br />";

            housePlayer.ConductBattles(NumberOfBattleRounds);

            result += housePlayer.Result;

            //WinningCondition
            
            
            //FinalScoring




            resultLabel.Text = result;
        }
    }
}