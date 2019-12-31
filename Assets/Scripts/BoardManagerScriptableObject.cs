using UnityEngine;

namespace Pokerball
{
    public class BoardManagerScriptableObject : ScriptableObject
    {
        public string prefabName;

        private const int numberOfCoaches = 25;
        public Vector3[] rankLocation;
    }
}