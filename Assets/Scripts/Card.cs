using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Pokerball 
{
    public class Card : IEquatable<Card>
    {
        public Rank rank { get; set; }
        public Suit suit { get; set; }


	private static int[] rankPrimes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41 };
	private static int[] suitPrimes = new int[] { 43, 47, 53, 59 };

	public int PrimeRank { get { return rankPrimes[(int)rank]; } }
	public int PrimeSuit { get { return suitPrimes[(int)suit]; } }

        public void LogCard()
        {
            Debug.Log(rank + " of " + suit);
        }

        public bool Equals(Card other)
        {
            return this.rank == other.rank && this.suit == other.suit;
        }
    }

    public enum Rank { TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE };
    public enum Suit { HEARTS, DIAMONDS, CLUBS, SPADES };

}
