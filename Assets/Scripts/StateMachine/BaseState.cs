using UnityEngine;

namespace StateMachine
{
    public class BaseState : MonoBehaviour
    {
        public virtual void OnEnterState() { }
        public virtual void OnExitState() { }
        public virtual void OnUpdateState() { }
    }
}