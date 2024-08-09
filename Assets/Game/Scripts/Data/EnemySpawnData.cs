using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    [CreateAssetMenu(fileName = "EnemySpawnData", menuName = "MKGames/EnemySpawnData"), System.Serializable]
    public class EnemySpawnData : ScriptableObject
    {
        public float spawnDelayMax;
        public float spawnDelayMin;
        public float delayToUpdateSpawnDelay;
        public float spawnDelayStep;
        public EnemyData[] enemyDatas;
        public EnemyData GetRandomEnemyDataWithChances()
        {
            int allChance = 0;
            for (int i = 0; i < enemyDatas.Length; i++)
            {
                allChance += enemyDatas[i].chanceSpawn;
            }
            int chanceNow = Random.Range(0, allChance);
            for (int i = 0; i < enemyDatas.Length; i++)
            {
                chanceNow -= enemyDatas[i].chanceSpawn;
                if (chanceNow < 0)
                {
                    return enemyDatas[i];
                }
            }
            return enemyDatas[0];
        }
    }
}