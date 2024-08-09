using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class WeaponBonus : MonoBehaviourBase
    {
        [SerializeField]
        private WeaponBonusSkin[] m_Skins;
        private WeaponBase.eType m_Type;
        public WeaponBase.eType Type => m_Type;
        // Start is called before the first frame update
        void Start()
        {

        }
        public void Init(WeaponBase.eType i_Type)
        {
            m_Type = i_Type;
            for(int i =0;i< m_Skins.Length; i++)
            {
                m_Skins[i].gameObject.SetActive(m_Skins[i].Type == m_Type);
            }
        }
        protected override void SetRefs()
        {
            base.SetRefs();
            m_Skins = GetComponentsInChildren<WeaponBonusSkin>();
        }
    }
}