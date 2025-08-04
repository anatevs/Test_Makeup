using UnityEngine;

namespace GameCore
{
    public class Player : MonoBehaviour
    {
        private InputController _input;

        private MakeupData _makeupData;

        private Collider2D _currentHanded;

        private Vector3 _currentShift;

        private bool _isDragging;

        public void SetEyeShadow(int id)
        {
            _makeupData.EyeShadowId = id;

            ClearCurrentHanded();
        }

        public void SetLipstick(int id)
        {
            _makeupData.LipstickId = id;

            ClearCurrentHanded();
        }

        public void SetBlush(int id)
        {
            _makeupData.BlushId = id;

            ClearCurrentHanded();
        }

        public void SetSkin(int id)
        {
            _makeupData.SkinId = id;

            ClearCurrentHanded();
        }

        public void SetCurrentHanded(Collider2D current)
        {
            _currentHanded = current;
        }

        public void ClearCurrentHanded()
        {
            _isDragging = false;

            SetCurrentHanded(null);
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

    public struct MakeupData
    {
        public int EyeShadowId;

        public int LipstickId;

        public int BlushId;

        public int SkinId;
    }
}