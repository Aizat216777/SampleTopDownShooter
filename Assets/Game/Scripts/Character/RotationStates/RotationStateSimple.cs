using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class RotationStateSimple : RotationStateBase
    {
        public override int Index => (int)RotationStateMachine.eState.Simple;
        private void Update()
        {

            m_Character.transform.rotation = Quaternion.RotateTowards(
                m_Character.transform.rotation,
                m_RotationStateMachine.Target,
                m_RotationStateMachine.Speed * Time.deltaTime);
        }
    }
}