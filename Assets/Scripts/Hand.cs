using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Pokerball
{
    public class Hand
    {
        public List<Card> Cards;

        public Hand() 
        {
            Cards = new List<Card>();
        }

        public void LogHand()
        {
            foreach(Card c in Cards)
            {
                c.LogCard();
            }
        }

        public int ScoreHand(bool away)
        {
            var cardCounts = Cards.GroupBy(card => (int)card.rank).Select(group => group).ToList();
            var quads = -1;
            var trips = -1;
            var onePair = -1;
            var twoPairs = -1;
            var high = -1;

            int rankProduct = Cards.Select(card => card.PrimeRank).Aggregate((acc, r) => acc * r);
			int suitProduct = Cards.Select(card => card.PrimeSuit).Aggregate((acc, r) => acc * r);

            bool straight =
                rankProduct == 8610			// 5-high straight
                || rankProduct == 2310		// 6-high straight
                || rankProduct == 15015		// 7-high straight
                || rankProduct == 85085		// 8-high straight
                || rankProduct == 323323	// 9-high straight
                || rankProduct == 1062347	// T-high straight
                || rankProduct == 2800733	// J-high straight
                || rankProduct == 6678671	// Q-high straight
                || rankProduct == 14535931	// K-high straight
                || rankProduct == 31367009; // A-high straight

            bool flush = 
                suitProduct == 147008443		// Spades
                || suitProduct == 229345007		// Hearts
                || suitProduct == 418195493		// Diamonds
                || suitProduct == 714924299;    // Clubs

            foreach(var group in cardCounts)
            {
                var rank = group.Key;
                var count = group.Count();

                if(count == 4) quads = rank;
                else if(count == 3) trips = rank;
                else if(count == 2)
                {
                    twoPairs = onePair;
                    onePair = rank;
                }
            }

            high = Cards.Select(card => (int)card.rank).Reverse().ToList().First();

            //Score straight flushes
            if (straight && flush)
            {
                if(high < 8) return 114;
                else if(high < 11) return 115;
                else if(high < 14) return 116;
                else if(high == 14) return 117;
            }
            //Score four of a kind
            else if( quads > 0 )
            {
                if(quads < 6) return 108;
                else if(quads < 10) return 109;
                else if(quads < 13) return 110;
                else if(quads < 14) return 111;
                else if(quads == 14) return 112;
            }
            //Score Full House
            else if(trips > 0 && onePair > 0)
            {
                if(trips < 6) return 104;
                else if(trips < 10) return 105;
                else if(trips < 14) return 106;
                else if(trips == 14) return 107;
            }
            //Score Flush
            else if(flush)
            {
                if(high < 9) return 99;
                else if(high < 11) return 100;
                else if(high < 13) return 101;
                else if(high < 14) return 102;
                else if(high == 14) return 103;
            }
            //Score Straight
            else if(straight)
            {
                if(high < 8) return 95;
                else if(high < 11) return 96;
                else if(high < 14) return 97;
                else if(high == 14) return 98;
            }
            //Score Three of a Kind
            else if(trips > 0) return trips + 80;
            //Score Two Pairs
            else if(twoPairs > 0)
            {
                int highPair;
                if(twoPairs > onePair) highPair = twoPairs;
                else highPair = onePair;

                if(highPair < 5) return 74;
                else if(highPair < 7) return 75;
                else if(highPair < 9) return 76;
                else if(highPair < 11) return 77;
                else return highPair + 67;
            }
            //Score One Pair
            else if(onePair > 0 ) return onePair + 59;
            //Score High Card
            return high + 46;
        }
    }
}