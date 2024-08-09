using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class AttackReceiverCharacter : AttackReceiverBase
    {
        [SerializeField]
        private CharacterBase m_Character;
        [SerializeField]
        private bool m_IsPlayer;
        public override eType Type => m_IsPlayer ? eType.Player : eType.Enemy;
        // Start is called before the first frame update
        void Start()
        {

        }
        public override void Hit(int i_Damage)
        {
            if (m_Character != null)
            {
                m_Character.Hit(i_Damage);
            }
        }

        protected override void SetRefs()
        {
            base.SetRefs();
            m_Character = GetComponent<CharacterBase>();
        }
    }
}