using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.InputSystem.UI;

namespace Input
{
    public class InputJoystick: MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private GameObject _joystick;
        [SerializeField] private OnScreenStick _stick;

        private Vector3 _startPos;
        
        public void Awake()
        {
            _startPos = _joystick.transform.position;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            SetPosJoystick(eventData.position);
            _stick.OnPointerDown(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _stick.OnPointerUp(eventData);
            SetPosJoystick(_startPos);
        }

        public void Reset() => OnPointerUp(new PointerEventData(new MultiplayerEventSystem()));

        public void OnDrag(PointerEventData eventData) => _stick.OnDrag(eventData);

        private void SetPosJoystick(Vector3 position) => _joystick.transform.position = position;
    }
}