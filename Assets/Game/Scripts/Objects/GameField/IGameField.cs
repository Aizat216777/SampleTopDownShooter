using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public interface IGameField 
    {
        Vector2 Size { get; }
        float Left { get; }
        float Right { get; }
        float Top { get; }
        float Bottom { get; }
    }
}