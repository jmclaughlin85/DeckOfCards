using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cards
{
    public class Card
    {
        //class fields and properties

            /// <summary>
            /// Enumerator for four different suit types a card object can "have"
            /// </summary>
        public enum Suit
        {
            HEARTS = 1, DIAMONDS, CLUBS, SPADES
        }

        /// <summary>
        /// Enumerator for the thirteen different face values a card object can "have"
        /// </summary>
        public enum Face
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
        }

        private readonly Suit suit;//card object's suit value
        public Suit Suit_Prop
        {
            get{return suit;}
            //no setter for suit as I don't want a card to be able to change its suit after it is created!
        }

        private readonly Face face;//card object's face value
        public Face Face_Prop
        {
            get {return face;}
            //no setter for Face for same reason as suit property
        }

        /// <summary>
        /// If available value is "false" then this card object has been dealt and is no longer considered available to "pull" from deck
        /// </summary>
        private bool available;//value to identify whether or not the card is available to be dealt
        public bool Avail_Prop
        {
            get{return available;}
            set{available = value;}
        }

        //=========CLASS CONSTRUCTORS===========
      
        /// <summary>
        /// Creates card object with read-only properties of specified Suit and Face values.  "avail" value is 
        /// defaulted to be true as it is assumed at card object creation that it has not already been "dealt".
        /// This "avail" value can be over-ridden if desired. 
        /// </summary>
        /// <param name="suitType">Enum Suit type of card object</param>
        /// <param name="faceType">Enum Face type of card object</param>
        /// <param name="avail">card's "playable" or "dealable" status</param>
        public Card(Suit suitType, Face faceType, bool avail = true)
        {
            suit = suitType;
            face = faceType;
            available = avail;
        }


        /// <summary>
        /// Method will display Card object's suit, face, and availability details on one line of console output
        /// </summary>
        public void DisplayCardInfo()
        {
            string isOrIsnt = null; 
            if (available == true)
            {
                isOrIsnt = "has NOT";
            }
            else if (available == false)
            {
                isOrIsnt = "has";
            }
            WriteLine("This card is a(n) {0} of {1}. It {2} been dealt.", face, suit, isOrIsnt);
        }

    }
}
