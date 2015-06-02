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
            
            result = "<h2>Setting Things Up ...</h2><br />";
            
            // Create Players and House
            HousePlayer housePlayer = new HousePlayer();
            GamePlayer gamePlayer1 = new GamePlayer();
            GamePlayer gamePlayer2 = new GamePlayer();
            
            //SetupWar
            DeckOfCards cardDeck = new DeckOfCards(DeckOfCards.DeckType.Standard);
            cardDeck.BuildDeck();
            cardDeck.PerformShuffles();


            //InitialDeal
            result = "<h2>Dealing cards ...</h2><br />";
            
            
            //BattleRound
            
            
            //WarRound
            
            
            //WinningCondition
            
            
            //FinalScoring




            resultLabel.Text = result;
        }
    }
}