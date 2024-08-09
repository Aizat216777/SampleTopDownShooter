using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class MovementStateStop : MovementStateBase
    {
        public override int Index => (int)MovementStateMachine.eState.Stop;
    }

}