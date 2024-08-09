using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class AttackGiverBullet : AttackGiver
    {
        [SerializeField]
        private Bullet m_Bullet;
        protected override int GetDamage(AttackReceiverBase i_AttackReceiver)
        {
            return m_Bullet != null ? m_Bullet.Damage : 1;
        }
        protected override void HitCompleted()
        {
            base.HitCompleted();
            gameObject.SetActive(false);
        }
        protected override void SetRefs()
        {
            base.SetRefs();
            m_Bullet = GetComponent<Bullet>();
        }
    }
}