using System;
using UnityEngine;
using Zenject;

namespace Game.Input
{
    public class MovableInputHandler: ITickable, IMovableInputHandler
    {
        private readonly InputActions _inputActions;

        public Action StartMove { get; set; }
        public Action StopMove { get; set; }
        public Action<Vector2> Move { get; set; }
        
        private bool _isMoved;
        private Vector2 _direction;
        
        public MovableInputHandler
        (
            InputActions inputActions
        )
        {
            _inputActions = inputActions;
        }

        public void Tick()
        {
            _direction = _inputActions.Main.Move.ReadValue<Vector2>();
            
            if (_direction.magnitude > 0.01)
            {
                if (!_isMoved)
                {
                    _isMoved = true;
                    StartMove?.Invoke();
                }
                
                Move?.Invoke(_direction);
            }
            else
            {
                if (!_isMoved) 
                    return;
                
                _isMoved = false;
                StopMove?.Invoke();
            }
        }
    }
}