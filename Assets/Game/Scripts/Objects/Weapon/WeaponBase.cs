using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public abstract class WeaponBase : MonoBehaviourBase
    {
        public enum eType
        {
            Pistol,
            Rifle,
            Shotgun,
            Grenade,
        }
        [SerializeField]
        protected Bullet m_BulletPrefab;
        [SerializeField]
        private Transform m_BulletCreatePosition;
        [SerializeField]
        protected WeaponBaseData m_WeaponData;
        public float delayToAttack => m_WeaponData != null ? 1.0f / m_WeaponData.firerate : 0.2f;
        public abstract eType Type { get; }

        public abstract void Shoot();
        protected Bullet CreateBullet(Quaternion i_Rotation)
        {
            ILevel level = ServiceLocator.Resolve<ILevel>();
            Bullet bullet = Instantiate(
                m_BulletPrefab,
                m_BulletCreatePosition.position,
                i_Rotation,
                level.Root);
            bullet.Init(m_WeaponData);
            return bullet;
        }
    }
}