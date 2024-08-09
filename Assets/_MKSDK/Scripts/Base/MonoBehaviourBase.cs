using EasyButtons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKSDK
{
    public class MonoBehaviourBase : MonoBehaviour
    {
        protected virtual void OnValidate()
        {
            
        }
        [Button]
        protected virtual void SetRefs()
        {

        }
    }
}