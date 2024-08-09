using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public abstract class AttackGiver : MonoBehaviourBase
    {
        [SerializeField]
        private AttackReceiverBase.eType[] m_CanDamage;
        // Start is called before the first frame update
        void Start()
        {

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out AttackReceiverBase attackReceiver))
            {
                if (m_CanDamage.Contains(attackReceiver.Type))
                {
                    attackReceiver.Hit(GetDamage(attackReceiver));
                    HitCompleted();
                }
            }
        }
        protected abstract int GetDamage(AttackReceiverBase i_AttackReceiver);
        protected virtual void HitCompleted()
        {
        }
    }
}