using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKSDK
{

    public class Destructor : MonoBehaviour
    {
        private enum eType
        {
            Destroy,
            Disable
        }
        [SerializeField]
        private float m_Delay;
        [SerializeField]
        private eType m_Type = eType.Destroy;
        private float m_TimeNow;
        // Start is called before the first frame update
        void Start()
        {

        }
        private void OnEnable()
        {
            m_TimeNow = 0;
        }

        // Update is called once per frame
        void Update()
        {
            m_TimeNow += Time.deltaTime;
            if (m_TimeNow > m_Delay)
            {
                switch (m_Type)
                {
                    case eType.Destroy:
                        Destroy(gameObject);
                        break;
                    case eType.Disable:
                        gameObject.SetActive(false); 
                        break;
                }
            }
        }
    }
}