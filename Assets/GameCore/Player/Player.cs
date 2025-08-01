using UnityEngine;

namespace GameCore
{
    public class Player : MonoBehaviour
    {
        private PlayerInputController _input;

        private int _eyeShadowId;

        private int _lipstickId;

        private int _blushId;

        private int _skinId;

        private Collider2D _currentHanded;

        private Vector3 _currentShift;

        private bool _isDragging;

        public void SetEyeShadow(int id)
        {
            _eyeShadowId = id;
        }

        public void SetCurrentHanded(Collider2D current)
        {
            _currentHanded = current;
        }

        private void Awake()
        {
            _input = new();
        }

        private void OnEnable()
        {
            _input.OnTapScreen += SetupShift;

            _input.OnDragScreen += DragCurrent;

            _input.OnDropScreen += DropCurrent;
        }


        private void OnDisable()
        {
            _input.OnTapScreen -= SetupShift;

            _input.OnDragScreen -= DragCurrent;

            _input.OnDropScreen -= DropCurrent;
        }

        private void SetupShift(Vector3 tapPos)
        {
            if (_currentHanded != null && _currentHanded.OverlapPoint(tapPos))
            {
                _currentShift = _currentHanded.transform.position - tapPos;

                _isDragging = true;
            }
        }

        private void DragCurrent(Vector3 dragPos)
        {
            if (_isDragging)
            {
                _currentHanded.transform.position = dragPos + _currentShift;
            }
        }

        private void DropCurrent(Vector3 dropPos)
        {
            if (_isDragging)
            {
                _isDragging = false;
            }
        }
    }
}