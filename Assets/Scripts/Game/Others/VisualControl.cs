using UnityEngine;
using UnityEngine.Events;

namespace Game.Others
{
    public class VisualControl: MonoBehaviour
    {
        [Header("Fires when the game starts")]
        public UnityEvent _onStart;

        private void Start() => _onStart?.Invoke();
    }
}