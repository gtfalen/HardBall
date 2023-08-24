using System;
using Game.Entity;
using StateMachine;
using UnityEngine;

namespace Game.Player
{
    public class PlayerView: BaseEntity
    {
        public CharacterController CharacterController;
        public StateMachineController stateMachineController;
        public Transform SkinTransform;
        
        public Action OnMoneyCollect;
    }
}