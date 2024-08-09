using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MK.Game
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "MKGames/GameConfig"), System.Serializable]
    public class GameConfig : ScriptableObject
    {
        public PlayerData playerData;
        public EnemySpawnData enemySpawnData;
        public WeaponSpawnerData weaponSpawnerData;
        public PrefabsData prefabsData;
        [System.Serializable]
        public class PrefabsData
        {
            public WeaponBonus weaponBonus;
            [SerializeField]
            private WeaponBase[] m_Weapons;
            public WeaponBase GetWeapon(WeaponBase.eType i_Type)
            {
                for(int i = 0; i< m_Weapons.Length; i++)
                {
                    if (m_Weapons[i].Type == i_Type)
                    {
                        return m_Weapons[i];
                    }
                }
                return null;
            }

        }
    }
}