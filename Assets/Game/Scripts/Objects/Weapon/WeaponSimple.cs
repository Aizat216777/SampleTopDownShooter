using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class WeaponSimple : WeaponBase
    {
        [SerializeField]
        private eType m_Type;
        public override eType Type => m_Type;
        public override void Shoot()
        {
            CreateBullet(transform.rotation);
        }
    }
}