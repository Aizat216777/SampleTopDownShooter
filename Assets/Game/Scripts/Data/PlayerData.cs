using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MK.Game
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "MKGames/PlayerData"), System.Serializable]
    public class PlayerData : ScriptableObject
    {
        public float speedMove;
        public float speedRotation;
    }
}
