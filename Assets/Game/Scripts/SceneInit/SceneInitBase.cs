using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class SceneInitBase : MonoBehaviourBase
    {
        protected virtual void Awake()
        {
            ServiceLocator.Reset();
        }
    }
}
