using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public abstract class AttackReceiverBase : MonoBehaviourBase
    {
        public enum eType
        {
            Player,
            Enemy,
        }
        public abstract eType Type { get; }
        public abstract void Hit(int i_Damage);
    }
}