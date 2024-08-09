using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKSDK
{
    public interface ILevel 
    {
        Transform Root { get; }
    }
}