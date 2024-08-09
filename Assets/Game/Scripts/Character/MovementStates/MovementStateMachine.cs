using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class MovementStateMachine : StateMachineSimple<MovementStateMachine.eState>
    {
        public enum eState
        {
            Move,
            Stop,
        }
        private MovementStateBase.IDirection m_Direction;
        private MovementStateBase.ISpeed m_Speed;
        private List<MovementStateBase.IExtraBehaviour> m_ExtraBehaviours;
        public MovementStateBase.IDirection Direction => m_Direction;
        public MovementStateBase.ISpeed Speed => m_Speed;
        public List<MovementStateBase.IExtraBehaviour> ExtraBehaviours => m_ExtraBehaviours;
        public void Init(MovementStateBase.IDirection i_MovementDirection, MovementStateBase.ISpeed i_MovementSpeed)
        {
            m_Direction = i_MovementDirection;
            m_Speed = i_MovementSpeed;
        }

    }
}