using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace Pokerball
{
    [CreateAssetMenu(fileName = "New Team List", menuName = "Team List", order = 52)]
    public class TeamList : ScriptableObject, IShuffleable
    {
        [SerializeField]
        public List<Team> list;

        public void Shuffle()
        {
            var rnd = new System.Random();
            list = list.OrderBy(x => rnd.Next()).ToList();
        }

        public void GetFirstTeam()
        {
            Debug.Log(list[0].school);
        }
    }

}