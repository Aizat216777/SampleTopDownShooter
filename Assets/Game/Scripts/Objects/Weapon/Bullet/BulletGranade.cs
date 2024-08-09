using MKSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class BulletGranade : Bullet
    {
        [SerializeField]
        private BulletExplosion m_BulletExplosion;
        private WeaponGrenadeData m_WeaponGrenadeData;
        private Vector3 m_TargetPosition;
        public override int Damage => m_WeaponGrenadeData != null ? m_WeaponGrenadeData.damage : 1;

        private void OnEnable()
        {
            m_TargetPosition = ServiceLocator.Resolve<IInputManager>().MouseWorldPosition;
        }
        protected override void Update()
        {
            base.Update();
            transform.position = Vector3.MoveTowards(transform.position, m_TargetPosition, m_WeaponGrenadeData.speed * Time.deltaTime);
            if (ExtensionMethodsV2.DistanceSquare(m_TargetPosition, transform.position) < 0.001f)
            {
                m_BulletExplosion.transform.localScale = Vector3.one * m_WeaponGrenadeData.radius * 2;
                m_BulletExplosion.Init(m_WeaponGrenadeData);
                m_BulletExplosion.transform.SetParent(ServiceLocator.Resolve<ILevel>().Root);
                Destroy(gameObject);
            }
        }
        public override void Init(WeaponBaseData i_WeaponData)
        {
            m_WeaponGrenadeData = i_WeaponData as WeaponGrenadeData;
        }
    }
}