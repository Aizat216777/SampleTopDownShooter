using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class CharacterBase : MonoBehaviourBase
    {
        public delegate void DiedEvent(CharacterBase i_Character);
        public event DiedEvent OnDied = delegate { };
        public delegate void DamagedEvent(CharacterBase i_Character, int i_Health, int i_OldHealth, int i_Damage);
        public event DamagedEvent OnDamaged = delegate { };

        [SerializeField]
        private MovementStateMachine m_MovementStateMachine;

        protected HealthData m_HealthData = new HealthData(1);

        protected virtual void Start()
        {

        }
        protected virtual void OnEnable()
        {
            m_HealthData.OnDied += HealthDiedCallback;
            m_HealthData.OnDamaged += HealthDamagedCallback;
        }
        protected virtual void OnDisable()
        {
            m_HealthData.OnDied -= HealthDiedCallback;
            m_HealthData.OnDamaged -= HealthDamagedCallback;
        }
        private void HealthDiedCallback(HealthData i_HealthData)
        {
            OnDied(this);
        }
        private void HealthDamagedCallback(HealthData i_HealthData, int i_Health, int i_OldHealth, int i_Damage)
        {
            OnDamaged(this, i_Health, i_OldHealth, i_Damage);
        }
        public void Init(int i_Health, MovementStateBase.IDirection i_MovementDirection, MovementStateBase.ISpeed i_MovementSpeed)
        {
            m_HealthData.Reset(i_Health);
            m_MovementStateMachine.Init(
                i_MovementDirection,
                i_MovementSpeed);
        }
        public void StartMove()
        {
            m_MovementStateMachine.StartState(MovementStateMachine.eState.Move);
        }
        public void StopMove()
        {
            m_MovementStateMachine.StartState(MovementStateMachine.eState.Stop);
        }
        protected override void SetRefs()
        {
            base.SetRefs();
            m_MovementStateMachine = GetComponentInChildren<MovementStateMachine>();
        }
    }
}