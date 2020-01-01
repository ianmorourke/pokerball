using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Pokerball{
    public class Leaderboard : MonoBehaviour
    {
        void Start()
        {
            TeamList teamListInstance = new TeamList();
            List<Team> allTeams = teamListInstance.BuildHardcodedList();
            //allTeams.Shuffle();
            TeamList.GetFirstTeam(allTeams);
        }
    }
}