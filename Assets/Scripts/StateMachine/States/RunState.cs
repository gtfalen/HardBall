using UnityEngine;

namespace StateMachine.States
{
    public class RunState: BaseState
    {
        [SerializeField] private Animator _animator;

        public override void OnEnterState()
        {
            _animator.speed = 1.5f;
            _animator.Play("Walking");
        }
    }
}