using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKSDK
{
    public abstract class StateBase : MonoBehaviourBase
    {
        public abstract int Index { get; }
        protected virtual void OnEnable()
        {

        }
        protected virtual void OnDisable()
        {

        }
    }
}