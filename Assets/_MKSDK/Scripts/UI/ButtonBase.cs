using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MKSDK
{
    public class ButtonBase : MonoBehaviourBase, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
    {
        public delegate void ClickEvent(ButtonBase i_Button);
        public event ClickEvent OnClick = delegate { };
        public delegate void DownEvent(ButtonBase i_Button, int i_Pointerid, Vector2 i_ScreenPosition);
        public event DownEvent OnDown = delegate { };
        public delegate void UpEvent(ButtonBase i_Button, int i_Pointerid, Vector2 i_ScreenPosition);
        public event UpEvent OnUp = delegate { };
        public delegate void MoveEvent(ButtonBase i_Button, int i_Pointerid, Vector2 i_ScreenPosition);
        public event MoveEvent OnMove = delegate { };
        [SerializeField]
        private Button m_Button;
        //[SerializeField]
        //private MenuScreenBase m_MenuScreen;
        [SerializeField]
        private ActionEffect[] m_ClickActions;
        [SerializeField]
        private ActionEffect[] m_DownActions;
        [SerializeField]
        private ActionEffect[] m_UpActions;
        [SerializeField]
        private ActionEffect[] m_PointerEnterActions;

        // Start is called before the first frame update
        protected virtual void Start()
        {

        }
        protected virtual void OnEnable()
        {
            if (m_Button != null)
            {
                m_Button.onClick.AddListener(ButtonClickCallback);
            }
        }
        protected virtual void OnDisable()
        {
            if (m_Button != null) m_Button.onClick.RemoveListener(ButtonClickCallback);
        }
        protected virtual void ButtonClickCallback()
        {
            ActionEffect.StartEffects(m_ClickActions);
            OnClick(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            ActionEffect.StartEffects(m_PointerEnterActions);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            ActionEffect.StartEffects(m_DownActions);
            OnDown(this, eventData.pointerId, eventData.position);
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            ActionEffect.StartEffects(m_UpActions);
            OnUp(this, eventData.pointerId, eventData.position);
        }
        public void OnPointerMove(PointerEventData eventData)
        {
            OnMove(this, eventData.pointerId, eventData.position);
        }
        protected override void OnValidate()
        {
            base.OnValidate();
            if (m_Button == null) m_Button = GetComponent<Button>();
        }
        protected override void SetRefs()
        {
            base.SetRefs();
            m_Button = GetComponent<Button>();
            m_ClickActions = transform.FindDeepChilds<ActionEffect>("ClickActions");
            m_DownActions = transform.FindDeepChilds<ActionEffect>("DownActions");
            m_UpActions = transform.FindDeepChilds<ActionEffect>("UpActions");
            m_PointerEnterActions = transform.FindDeepChilds<ActionEffect>("PointerEnterActions");
        }

    }
}