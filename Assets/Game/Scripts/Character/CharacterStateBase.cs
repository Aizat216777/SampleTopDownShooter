using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public abstract class CharacterStateBase : StateBase
    {
        [SerializeField]
        protected CharacterBase m_Character;
        protected override void SetRefs()
        {
            base.SetRefs();
            m_Character = GetComponentInParent<CharacterBase>();
        }
    }
}