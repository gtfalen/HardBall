using System;
using UnityEngine;

namespace Game.Input
{
    public interface IMovableInputHandler
    {
        Action StartMove { get; }
        Action StopMove { get; }
        Action<Vector2> Move { get; }
    }
}