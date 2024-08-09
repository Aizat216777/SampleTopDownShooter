using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKSDK
{
    public class Level : MonoBehaviourBase, ILevel
    {
        [SerializeField]
        private Transform m_Root;
        public Transform Root => m_Root != null ? m_Root : transform;
    }
}