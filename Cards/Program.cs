using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck(1);//instantiates new "Deck" object with label of "1"
            newDeck.DisplayDeckInfo();//will print deck information to console for deck 1

            Deck newDeck2 = new Deck(2);//instantiates new "Deck" object with label of "2"
            newDeck2.DisplayDeckInfo();// will print deck information for deck 2

            Card[] playerOne; Card[] playerTwo;
            Write("\n\n");
            newDeck2.DealTwoHands(out playerOne, out playerTwo);
            WriteLine("~~~Two Hands from Deck 2~~~");
            WriteLine("Player One's Hand");
            foreach (Card card in playerOne)
            {
                card.DisplayCardInfo();
            }
            WriteLine("End of Player One's Hand\n\n");

            WriteLine("Player Two's Hand");
            foreach (Card card in playerTwo)
            {
                card.DisplayCardInfo();
            }
            WriteLine("End of Player Two's Hand");

            ReadLine();   
        }
    }
}
