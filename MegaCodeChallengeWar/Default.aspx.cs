﻿using System;
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
            
            //SetupWar
            DeckOfCards cardDeck = new DeckOfCards(DeckOfCards.DeckType.Standard);
            cardDeck.BuildDeck();
            cardDeck.PerformShuffles();

            // Create Players and House

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