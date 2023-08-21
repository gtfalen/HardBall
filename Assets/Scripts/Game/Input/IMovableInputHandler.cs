using System;
using UnityEngine;

namespace Game.Input
{
    public interface IMovableInputHandler
    {
        Action StartMove { get; set; }
        Action StopMove { get; set; }
        Action<Vector2> Move { get; set; }
    }
}