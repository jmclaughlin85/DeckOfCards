using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class Player//THIS CLASS IS NOT IN ACTIVE USE YET.
        //IT IS SIMPLY A 'START' TO WHAT COULD POSSIBLY BE USED
        //IN ORDER TO ACTUALLY 'PLAY' A GAME OR HAND
    {
        List<Card> playerHand = new List<Card>();
        private int winStatus;
        private int cumulativeWins;

        public int Win_Status_Prop
        {
            get { return winStatus; }
            set { winStatus = value; }
        }

        public int Cum_Wins_Prop
        {
            get { return cumulativeWins; }
            set { cumulativeWins = value; }
        }

        private void DealHoldEmHand()
        {

        }

    }
}
