using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class AttackGiverEnemy : AttackGiver
    {
        [SerializeField]
        private EnemyController m_EnemyController;
        protected override int GetDamage(AttackReceiverBase i_AttackReceiver)
        {
            return m_EnemyController != null ? m_EnemyController.Damage : 1;
        }
        protected override void SetRefs()
        {
            base.SetRefs();
            m_EnemyController = GetComponent<EnemyController>();
        }
    }
}