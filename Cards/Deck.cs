using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Cards
{
    public class Deck
    {
        //class fields and properties

        private int cardsInDeck;//current number of cards in deck object
        public int Cards_In_Deck_Prop
        {
            get { return cardsInDeck; }
            set { cardsInDeck = value; }
        }

        private int deckNumber;//identifier used to keep track of decks if multiple decks are being used/created
        public int Deck_Num_Prop
        {
            get { return deckNumber; }
            set { deckNumber = value; }
        }

        /// <summary>
        /// stores boolean value representing whether or not the deck object is "empty."
        /// Empty is defined as having zero card objects whose "available" property is true.  They have all been dealt already!
        /// </summary>
        private bool isEmpty;
        public bool Is_Empty_Prop
        {
            get { isEmpty = EmptyDeckStatus(); return isEmpty; }
            set { isEmpty = value; }
        }

        /// <summary>
        /// holds all individual card objects for deck object.
        /// </summary>
        private Card[] deckOCards;// I suppose I could already specify the size of this Card array but I chose to do that in the deck constructor.

        //=======CLASS CONSTRUCTORS CREATE STANDARD 52 CARD DECK=========

            /// <summary>
            /// Deck object constructor, contains 52 individually constructed Card objects, one for each suit and face combination.
            /// Constructor DOES 'shuffle' the deck by default, placing all 52 cards in a randomly generated order.
            /// </summary>
            /// <param name="deckId">number passed to simply distinguish one deck from another.  could be particularily useful
            /// if more than one deck is "in play"</param>
        public Deck(int deckId)
        {
            deckNumber = deckId;
            Card[] tempDeck1 = new Card[52];
            
            //Creates 52 card objects representing standard deck (IN ORDER)
            int c = 0;
            foreach (Card.Suit suit_value in Enum.GetValues(typeof(Card.Suit)))
                //for hearts, diamonds, clubs, and spades
            {
                foreach (Card.Face face_value in Enum.GetValues(typeof(Card.Face)))
                {//create a card of 2, 3, 4, 5, ....to 14 (Ace)
                    tempDeck1[c] = new Card(suit_value, face_value);
                    ++c;
                }
            }
            //End of creating 52 card objects

            cardsInDeck = c; //establishes Deck field value to be equal to "52" at instantiation
            deckOCards = new Card[52]; //holds 52 card objects to be represented in deck - is the Deck object field
            //Card[] tempDeck2 = new Card[52];
            List<Card> cardList = tempDeck1.ToList();//puts deck that was created IN ORDER to a list that will be used to 'pull from' when randomizing the order

            int a = 0;
            while (a < 2)//"shuffle" twice to ensure "random-ness"
            {
                Random rnd = new Random(); //random object used to generate random number used in "shuffle"
                int n = 52;
                while (n > 0)
                {
                    --n;
                    int k = rnd.Next(n);//k is a random number whose value is between 0 and n
                    //n is decreased each time so that the random number dynamically reflects the number of Card objects
                    //in the cardList.
                    deckOCards[n] = cardList[k];//place the Card object from the cardList into the 'final'
                    //Card array which will represent the shuffled deck.
                    cardList.RemoveAt(k);//removes Card from cardList so the Card object cannot be 'chosen' again
                }
                ++a;
                if (a == 1)//only happens after the 'first' shuffle
                {
                    cardList = deckOCards.ToList();//puts the now shuffled array back into List form to be 'shuffled' again
                }
            }
        }

        /// <summary>
        /// Chooses first 'available' card in Deck which method is called on.  Method does set chosen card's
        /// availability value to false since it is now considered 'dealt' or 'played'.
        /// </summary>
        /// <returns>Card object that was available but has now been considered 'dealt'</returns>
        public Card DealCard()
        {
            int currentIndex = 52 - cardsInDeck; // represents index value to "pull" out of deckOCards array
            Card dealCard = this.deckOCards[currentIndex];
            this.deckOCards[currentIndex].Avail_Prop = false;
            --cardsInDeck;
            return dealCard;
        }
        
        /// <summary>
        /// Deals two, five-card hands
        /// </summary>
        /// <param name="player1">Card array holding five cards for player1</param>
        /// <param name="player2">Card array holding five cards for player2</param>
        public void DealTwoHands(out Card[] player1, out Card[] player2)
        {
            player1 = new Card[5]; player2 = new Card[5];
            for (int i = 0; i < 5; ++i)
            {
                Card temp1 = this.DealCard();
                Card temp2 = this.DealCard();
                player1[i] = temp1; player2[i] = temp2;
            }
        }

        /// <summary>
        /// Writes card details for each object of the deck to console, one line at a time, separated by a header and footer identifying the deck.  
        /// This method displays all 52 cards of the deck, regardless of if they have been "dealt" already or not.
        /// </summary>
        public void DisplayDeckInfo()
        {
            WriteLine("******Begin Deck Information for Deck {0}********\n", deckNumber);
            foreach (Card card in deckOCards)
            {
                card.DisplayCardInfo();
            }
            Write("******End Deck Information for Deck {0}********\n", deckNumber);
        }

        /// <summary>
        /// Determines whether or not a deck has existing card objects who are available to be dealt.
        /// Essentially iterates through the deck object's Card array and once it finds a card object
        /// whose available property is true it should stop searching and return false.
        /// </summary>
        /// <returns>true if deck is out of "playable" cards; false if deck has available cards</returns>
        public bool EmptyDeckStatus()
        {
            bool status = false; 
            if (this.Cards_In_Deck_Prop == 0)
            {
                status = true;
            }
            else if (this.Cards_In_Deck_Prop > 0)
            {
                for (int i = 0; i < Cards_In_Deck_Prop; ++i)
                {
                    if (this.deckOCards[i].Avail_Prop == true)
                    {
                        //if it gets here then there is a card that can be dealt!
                        status = false;
                        break;
                    }
                }
            }
            //status = true;
            return status;
        }

        #region Unused Code

        /*if (givenDeck.Is_Empty_Prop == true)
           {
           givenDeck.Cards_In_Deck_Prop = 0;
           Card randomPick = null;
           return randomPick;
           }
           return Card randomPick;*/
        //Card noCard = new Card();//FIGURE THIS OUT LATER
        //return noCard;//FIGURE OUT WHAT TO DO IF DECK IS EMPTY!

        //public Card GenerateRandomCard()
        //{
        //    Card cardToSend = FindAvailableRandom(this);
        //    return cardToSend;
        //}


        // public Card FindAvailableRandom(Deck givenDeck /*, out Card randomPick*/)
        // {
        //    //int i = GenerateRandomNumber();
        //    while (givenDeck.Is_Empty_Prop == false) //(Is_Deck_Empty(givenDeck) == false)
        //    {
        //        int i = GenerateRandomNumber();
        //        if (givenDeck.deckOCards[i].Avail_Prop == true)
        //       {

        //            Card randomPick = givenDeck.deckOCards[i];
        //             return randomPick;
        //         }
        //    }
        //     Card NoRandomPick = null;
        //     return NoRandomPick;
        //}

        ///// <summary>
        ///// Determines if a card object has been "played"/"dealt"
        ///// </summary>
        ///// <param name="selectedCard">Card object to determine availabilty of</param>
        ///// <returns>false if card has already been played/dealth; true if it is available to be played/dealt</returns>
        //public bool Is_Card_Available(Card selectedCard)
        //{
        //    if (selectedCard.Avail_Prop == true)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public int GenerateRandomNumber()
        //{
        //    Random rnd = new Random();
        //    int randomIndex = rnd.Next(51); // creates a number between 0 and 51
        //    return randomIndex;
        //}
        #endregion

    }
}
