using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pokerball
{
    [CreateAssetMenu(fileName = "new Team", menuName = "Team", order = 51 )]
    public class Team : ScriptableObject
    {
        [SerializeField]
        public string school;
        [SerializeField]
        public string shortname;
        [SerializeField]
        public string teamName;
        [SerializeField]
        public string conference;
        [SerializeField]
        public Sprite sprite;

        public Team() {}

        public Team(string newSchool, string newShortname, string newTeamName, string newConference)
        {
            this.school = newSchool;
            this.shortname = newShortname;
            this.teamName = newTeamName;
            this.conference = newConference;
        }
    }
}