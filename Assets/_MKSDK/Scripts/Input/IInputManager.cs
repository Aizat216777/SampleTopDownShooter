using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MK.Game
{
    public interface IInputManager 
    {
        event InputManagerEvents.SimpleEvent OnInputDown;
        event InputManagerEvents.SimpleEvent OnInputUp;
        Vector2 MouseScreenPosition { get; }
        Vector3 MouseWorldPosition { get; }
    }
    public class InputManagerEvents
    {
        public delegate void SimpleEvent(int i_PointerID, Vector2 i_ScreenPosition);
    }
}