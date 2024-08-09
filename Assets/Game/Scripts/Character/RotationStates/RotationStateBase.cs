using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public abstract class RotationStateBase : CharacterStateBase
    {
        [SerializeField]
        protected RotationStateMachine m_RotationStateMachine;
        protected override void SetRefs()
        {
            base.SetRefs();
            m_RotationStateMachine = GetComponentInParent<RotationStateMachine>();
        }
    }
}