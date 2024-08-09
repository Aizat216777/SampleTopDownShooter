using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class BulletSimple : Bullet
    {
        private WeaponBaseData m_WeaponBaseData;
        public override int Damage => m_WeaponBaseData != null ? m_WeaponBaseData.damage : 1;
        protected override void Update()
        {
            base.Update();
            transform.position += transform.up * m_WeaponBaseData.speed * Time.deltaTime;
        }
        public override void Init(WeaponBaseData i_WeaponData)
        {
            m_WeaponBaseData = i_WeaponData;
        }
    }
}