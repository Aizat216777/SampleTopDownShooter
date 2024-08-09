using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class BulletExplosion : Bullet
    {
        private WeaponBaseData m_WeaponBaseData;
        public override int Damage => m_WeaponBaseData != null ? m_WeaponBaseData.damage : 1;       
        public override void Init(WeaponBaseData i_WeaponData)
        {
            m_WeaponBaseData = i_WeaponData;
        }
    }
}