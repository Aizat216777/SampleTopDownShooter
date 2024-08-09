using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "MKGames/EnemyData"), System.Serializable]
    public class EnemyData : ScriptableObject
    {
        public int health;
        public float speed;
        public int killScore;
        public float chanceSpawn;
    }
}

