using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace MK.Game
{
    public class InputMain : MonoBehaviourBase, IInputManager, IPointerDownHandler, IPointerUpHandler
    {
        public Vector2 MouseScreenPosition
        {
            get
            {
                PlayerInput playerInput = ServiceLocator.Resolve<PlayerInput>();
                if (playerInput != null)
                {
                    return playerInput.actions[nameof(eGameplayActionType.MousePosition)].ReadValue<Vector2>();
                }
                return Vector2.zero;
            }
        } 

        public event InputManagerEvents.SimpleEvent OnInputDown = delegate { };
        public event InputManagerEvents.SimpleEvent OnInputUp = delegate { };
        private void OnEnable()
        {
            
        }
        private void OnDisable()
        {
            
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            OnInputDown(0, eventData.position);
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            OnInputUp(0, eventData.position);
        }
    }
}