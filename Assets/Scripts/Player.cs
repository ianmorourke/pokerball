using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Pokerball
{
    public class Player : MonoBehaviour
    {
        public static int playerCount = 0;
        [SerializeField]
        public string firstName;
        [SerializeField]
        public string team;
        public Hand hand;

        public Player(string newName)
        {
            this.firstName = newName;
        }

        public void DrawCard(Card draw)
        {
            hand.Cards.Add(draw);
        }
    }
}