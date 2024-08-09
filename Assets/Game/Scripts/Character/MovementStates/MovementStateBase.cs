using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public abstract class MovementStateBase : CharacterStateBase
    {
        [SerializeField]
        protected MovementStateMachine m_MovementStateMachine;
        protected Vector3 MovementDirection => m_MovementStateMachine != null && m_MovementStateMachine.Direction!=null ? m_MovementStateMachine.Direction.Dir : Vector3.zero;
        protected float MovementSpeed => m_MovementStateMachine != null && m_MovementStateMachine.Speed != null ? m_MovementStateMachine.Speed.Speed : 0;
        public interface IDirection
        {
            Vector3 Dir { get; }
        }
        public interface ISpeed
        {
            float Speed { get; }
        }
        public interface IExtraBehaviour
        {
            Vector3 GetNewPosition(Vector3 i_Position);
        }
        protected override void SetRefs()
        {
            base.SetRefs();
            m_MovementStateMachine = GetComponentInParent<MovementStateMachine>();
        }
    }
}