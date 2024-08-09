using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class RotationStateMachine :  StateMachineSimple<RotationStateMachine.eState> 
    {
        private IRotationData m_RotationData;
        public float Speed => m_RotationData != null ? m_RotationData.SpeedRotation : 0;
        public Quaternion Target => m_RotationData != null ? m_RotationData.Target : Quaternion.identity;
        public void Init(RotationStateMachine.IRotationData i_RotationData)
        {
            m_RotationData = i_RotationData;
        }
        public enum eState
        {
            Simple
        }
        public interface IRotationData
        {
            float SpeedRotation { get; }
            Quaternion Target { get; }
        }
    }
}