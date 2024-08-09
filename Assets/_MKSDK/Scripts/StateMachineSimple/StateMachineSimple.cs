using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKSDK
{
     
    public class StateMachineSimple<T> : MonoBehaviourBase where T : System.Enum
    {
        [SerializeField]
        protected StateBase[] m_States;
        // Start is called before the first frame update
        void Start()
        {

        }
        public void StartState(T i_Value)
        {
            StartState((int)(object)i_Value);
        }
        public void StartState(StateBase i_State)
        {
            if (i_State != null)
            {
                StartState(i_State.Index);
            }
        }
        private void StartState(int i_Index)
        {
            //disable other states
            for (int i = 0; i < m_States.Length; i++)
            {
                if (m_States[i] != null &&
                    m_States[i].Index != i_Index)
                {
                    m_States[i].enabled = false;
                }
            }
            //enable correct state
            for (int i = 0; i < m_States.Length; i++)
            {
                if (m_States[i] != null &&
                    m_States[i].Index == i_Index)
                {
                    m_States[i].enabled = true;
                    break;
                }
            }
        }

        protected override void SetRefs()
        {
            base.SetRefs();
            m_States = GetComponentsInChildren<StateBase>();
        }
    }
}