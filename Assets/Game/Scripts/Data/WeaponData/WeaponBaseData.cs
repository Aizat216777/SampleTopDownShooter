using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    [System.Serializable]
    public class WeaponBaseData : ScriptableObject
    {
        public int damage;
        public float firerate;
        public float speed;
    }
}