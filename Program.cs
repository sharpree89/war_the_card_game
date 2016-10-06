using System;
using System.Collections.Generic;

namespace ConsoleApplication_War
{
    public class Card
    {
        public int value;
        public string suit;
        public Card(int val, string ste)
        {
            value = val;
            suit = ste;
        }
    }
    public class Deck
    {
        int[] value = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
        public Card[] cards = new Card[52];
        public Deck()
        {
            Console.WriteLine("***** Creating Deck... *****");
            int idx = 0;
            for (int s = 0; s < 4; s++)
            {
                for (int v = 0; v < 13; v++)
                {
                    cards[idx] = new Card(value[v], suit[s]);
                    idx++;
                }
            }
            //to print all the cards of the deck before it gets shuffled:
            // for (int k = 0; k < 52; k++)
            // {
            //     Console.WriteLine(cards[k].value + " of " + cards[k].suit);
            // }
            Shuffle();
        }
        public void Shuffle()
        {
            dynamic temp = null;
            Random rand = new Random();
            Console.WriteLine("***** Shuffling Deck... *****");
            for (int i = cards.Length - 1; i >= 0; i--)
            {
                int j = rand.Next(i + 1);
                temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
                Console.WriteLine(cards[i].value + " of " + cards[i].suit);
            }
        }
        public void Deal(Player player1, Player player2)
        {
            Console.WriteLine("***** Dealing Cards... *****");
            for(int i = 0; i < cards.Length; i++) 
            {
                if(i % 2 == 0) 
                {
                    Console.WriteLine($"{player1.name} is dealt {cards[i].value} of {cards[i].suit}"); 
                }
                if(i % 2 != 0) 
                {
                    Console.WriteLine($"{player2.name} is dealt {cards[i].value} of {cards[i].suit}"); 
                }
            }
        }
        public void Reset()
        {
            Console.WriteLine("***** Resetting Deck... *****");
            Deck deckB = new Deck();
        }
    public class Player
    {
        public string name;
        public int wins;
        public int losses;
        public Player(string n)
        {
            name = n;
            wins = 0;
            losses = 0;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Player playerA = new Player("Bilbo Baggins");
            Console.WriteLine($"***** {playerA.name} enters the arena *****");
            Console.WriteLine($"{playerA.name} has won {playerA.wins} games, and lost {playerA.losses} games");

            Player playerB = new Player("D.J. Khaled");
            Console.WriteLine($"***** {playerB.name} enters the arena *****");
            Console.WriteLine($"{playerB.name} has won {playerB.wins} games, and lost {playerB.losses} games");
           
            Deck deckA = new Deck();
            
            deckA.Deal(playerA, playerB);

            deckA.Reset();
            
        }
    }
    }
}
