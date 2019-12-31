using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Pokerball
{
    public class Interface : MonoBehaviour
    {
        public static void Shuffle(IEnumerable<Object> objects)
        {
            var rnd = new System.Random();
            objects = objects.OrderBy(x => rnd.Next()).ToList();

        }
    }
}