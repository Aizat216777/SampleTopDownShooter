using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    [CreateAssetMenu(fileName = "WeaponShotgunData", menuName = "MKGames/Weapon/WeaponShotgunData"), System.Serializable]
    public class WeaponShotgunData : WeaponBaseData
    {
        public int bulletAmount;
        public float angle;
        public float distance;
    }
}
