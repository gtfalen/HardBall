using UnityEngine;
using UnityEngine.Events;

namespace Game.Others
{
    public class ActionTimer: MonoBehaviour
    {
        [Header("Timer delay")] 
        [Range(0.0f, 99.0f)] [SerializeField] private float _delay = 1f;

        [Header("Action to be performed")]
        [SerializeField] private UnityEvent _action;

        public void Stop() => CancelInvoke(nameof(CallAction));
        public void Play() => InvokeRepeating(nameof(CallAction), _delay, _delay);

        private void Start() => Play();
        private void CallAction() => _action.Invoke();
    }
}