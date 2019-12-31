using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Pokerball{
    public class Leaderboard : MonoBehaviour
    {
        void Awake()
        {

        }

        void Start()
        {
            TeamList list = TeamList.CreateInstance<TeamList>();
            list = (TeamList)Resources.Load("Assets/Scripts/Teams/all_teams");
            list.GetFirstTeam();
        }
    }
}