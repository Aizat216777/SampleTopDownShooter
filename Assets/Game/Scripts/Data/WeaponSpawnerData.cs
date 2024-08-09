using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    [CreateAssetMenu(fileName = "WeaponSpawnerData", menuName = "MKGames/WeaponSpawnerData"), System.Serializable]
    public class WeaponSpawnerData : ScriptableObject
    {
        public float delayToSpawn;
    }
}