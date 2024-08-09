using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;
using UnityEngine.InputSystem;
using System;

namespace MK.Game
{
    public class PlayerController : MonoBehaviourBase, MovementStateBase.IDirection, MovementStateBase.ISpeed
    {
        [SerializeField]
        private CharacterBase m_Character;
        [SerializeField]
        private PlayerData m_PlayerData;

        private InputAction m_MoveAction;
        private Action<InputAction.CallbackContext> m_MoveStartedCallback;
        private Action<InputAction.CallbackContext> m_MoveCanceledCallback;
        private Action<InputAction.CallbackContext> m_MovePerformedCallback;
        private Vector3 m_MovementDirection;

        public Vector3 Dir => m_MovementDirection;
        public float Speed => m_PlayerData != null ? m_PlayerData.speedMove : 4;

        // Start is called before the first frame update
        void Start()
        {
            m_Character.Init(1, this, this);

        }
        private void OnEnable()
        {
            PlayerInput playerInput = ServiceLocator.Resolve<PlayerInput>();
            if (playerInput != null)
            {
                if(m_MoveAction == null) m_MoveAction = playerInput.actions[nameof(eGameplayActionType.Move)];                
            }
            if (m_MoveStartedCallback == null) m_MoveStartedCallback = (InputAction.CallbackContext ctx) => MoveStartedCallback(ctx);
            if (m_MoveCanceledCallback == null) m_MoveCanceledCallback = (InputAction.CallbackContext ctx) => MoveCanceledCallback(ctx);
            if (m_MovePerformedCallback == null) m_MovePerformedCallback = (InputAction.CallbackContext ctx) => MovePerformedCallback(ctx);
            if (m_MoveAction != null)
            {
                m_MoveAction.started += m_MoveStartedCallback;
                m_MoveAction.canceled += m_MoveCanceledCallback;
                m_MoveAction.performed += m_MovePerformedCallback;
            }
        }
        private void OnDisable()
        {
            if (m_MoveAction != null)
            {
                m_MoveAction.started -= m_MoveStartedCallback;
                m_MoveAction.canceled -= m_MoveCanceledCallback;
                m_MoveAction.performed -= m_MovePerformedCallback;
            }
        }
        private void MoveStartedCallback(InputAction.CallbackContext i_Obj)
        {
            m_Character.StartMove();
            UpdateMovementDirection();
        }
        private void MovePerformedCallback(InputAction.CallbackContext i_Obj)
        {
            UpdateMovementDirection();
        }
        private void MoveCanceledCallback(InputAction.CallbackContext i_Obj)
        {
            UpdateMovementDirection();
            m_Character.StopMove();
        }
        private void UpdateMovementDirection()
        {
            if (m_MoveAction != null)
            {
                Vector2 inputDir = m_MoveAction.ReadValue<Vector2>();
                m_MovementDirection.x = inputDir.x;
                m_MovementDirection.y = inputDir.y;
            }
        }
        
        protected override void SetRefs()
        {
            base.SetRefs();
            m_Character = GetComponent<CharacterBase>();
        }
    }
}