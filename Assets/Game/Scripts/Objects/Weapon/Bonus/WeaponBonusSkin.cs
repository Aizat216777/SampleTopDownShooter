using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class WeaponBonusSkin : MonoBehaviour
    {
        [SerializeField]
        private WeaponBase.eType m_Type;
        public WeaponBase.eType Type => m_Type;
    }
}