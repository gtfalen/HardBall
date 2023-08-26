using UnityEngine;

namespace StateMachine.States
{
    public class IdleState: BaseState
    {
        [SerializeField] private Animator _animator;

        public override void OnEnterState()
        {
            _animator.Play("Idle");
        }
    }
}