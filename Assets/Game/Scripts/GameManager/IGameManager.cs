using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public interface IGameManager
    {
        event GameManagerEvents.SimpleEvent OnGameOver;        
    }
    public class GameManagerEvents
    {
        public delegate void SimpleEvent();
    }
}