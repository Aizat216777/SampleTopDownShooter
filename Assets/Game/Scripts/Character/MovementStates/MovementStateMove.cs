using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class MovementStateMove : MovementStateBase
    {
        public override int Index => (int)MovementStateMachine.eState.Move;
        private void Update()
        {
            if (m_Character != null)
            {
                Vector3 position = m_Character.transform.position + MovementDirection * MovementSpeed * Time.deltaTime;
                if(m_MovementStateMachine!=null &&
                    m_MovementStateMachine.ExtraBehaviours != null)
                {
                    for(int i = 0; i< m_MovementStateMachine.ExtraBehaviours.Count; i++)
                    {
                        if (m_MovementStateMachine.ExtraBehaviours[i] != null)
                        {
                            position = m_MovementStateMachine.ExtraBehaviours[i].GetNewPosition(position);
                        }
                    }
                }
                m_Character.transform.position = position;
            }
        }        
    }
}