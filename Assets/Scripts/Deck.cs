using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Pokerball
{
    public class Deck : IShuffleable
    {
        protected List<Card> deck = new List<Card>();

        public void CreateDeck()
        {
            deck.Clear();

            for (int s = 0; s < 4; s++)
            {
                for (int r = 0; r < 13; r++)
                {
                    deck.Add(new Card { suit = (Suit)s, rank = (Rank)r });
                }
            }
        }

        public void Show()
        {
            foreach(Card c in deck)
            {
                Debug.Log(c);
            }
        }

        public void Shuffle()
        {
            var rnd = new System.Random();
            deck = deck.OrderBy(x => rnd.Next()).ToList();
        }

        public Card DrawOneCard()
        {
            Card output = deck.Take(1).First();
            deck.Remove(output);
            return output;
        }
    }
}