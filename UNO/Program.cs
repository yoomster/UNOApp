using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UNO;

namespace UNO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to UNO (:");
            Console.WriteLine();
            //open discard pile, type value and color to play a card and check if 1 of the 2 matches
            Console.WriteLine("We will show the card that has to be matched to play, you must match either the number or the color. You do so by typing it's value and color");
            //type draw to draw
            Console.WriteLine("In case of no match in your hand, you must draw a card, by typing 'draw'.");

            Console.WriteLine("When you're ready, press enter. Let's goo!");


            Console.ReadLine();

            UNODeck uno = new UNODeck();

            


            Console.ReadLine();
        }
    }
    public class Deck
    {
        List<CardModel> fullDeck = new List<CardModel>();
        List<CardModel> drawPile = new List<CardModel>();
        List<CardModel> discardPile = new List<CardModel>();

        

        public void CreateDeck()
        {
            for (int color = 0; color < 4; color++)
            {
                for (int value = 0; value < 12; value++)
                {
                    fullDeck.Add(new CardModel { Color = (CardColor)color, Value = (CardValue)value });
                }
            }
        }
        public void ShuffleDeck()
        {
            var rnd = new Random();
            drawPile = fullDeck.OrderBy(x => rnd.Next()).ToList();
        }

        public List<CardModel> DealCards()
        {
            List<CardModel> hand = new List<CardModel>();

            for (int i = 0; i < 7; i++)
            {
                hand.Add(DrawCard());
            }

            return hand;
        }

        public void PlayCard(List<CardModel> discardPile)
        {
            Console.WriteLine("Choose the card you wish to play: ");
            string ChosenCard = Console.ReadLine();
            //convert string into a CardModel 


            discardPile.Add(ChosenCard);

            ////check if is in hand; make a method for this
            CheckCardMatch(ChosenCard);


        }

        public void CheckCardMatch(string playCard)
        {
            // is it easier to represent each card in your hand by a number,
            // and then to play a card by typing the array index?
            // you can easily check if your hand is empty


            //if (PlayCard = in hand)
            //{
            // remove from hand
            // add to discard pile
            // show as card to be matched
            //}
            //else{
            //      Console.WriteLine("incorrect, no match found");

            //}
        }

        public CardModel DrawCard()
        {
            var draw = drawPile.Take(1).First();
            drawPile.Remove(draw);

            return draw;
        }

        public List<CardModel> CreateDiscardPile()
        {
            List<CardModel> discardPile = new List<CardModel>();

            var draw = DrawCard();

            discardPile.Add(draw);

            Console.WriteLine($"The card that has to be matched is: {draw.Value} {draw.Color}");
    

            return discardPile;


        }
    }

    //public class PlayActions : Deck
    //{
        //move playable action here?
    //}

    public class UNODeck : Deck
    {
        public UNODeck()
        {
            CreateDeck();
            ShuffleDeck();
            CreateDiscardPile();

            List<CardModel> hand = DealCards();
            //hand needs to be updated etc. is this the right location?
            //I think not instead have a showHand method

            Console.WriteLine();
            Console.WriteLine("Your hand contains:");
            foreach (var card in hand)
            {
                Console.WriteLine($"{card.Value} {card.Color}");
            }

            // Ask for action
            Console.WriteLine("Action: (choose play or draw)");
            string action = Console.ReadLine();
            if (action.ToLower() == "draw")
            {
                DrawCard();
            }
            else
            {
                //PlayCard();
                Console.WriteLine
            }

            // When action is to play, check if valid

            //If valid, add played card to discard pile and show it



        }
    }
}