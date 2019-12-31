using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pokerball
{
    public class Exhibition : MonoBehaviour
    {
        public void Start()
        {
            Player player1 = new Player("TestName1");
            Deck deck = new Deck();
            deck.CreateDeck();
            deck.Shuffle();
        }
    }
}