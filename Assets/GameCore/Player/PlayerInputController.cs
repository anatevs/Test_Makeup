using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCore
{
    public sealed class PlayerInputController :
        IDisposable
    {
        public event Action<Vector2> OnTap;

        public event Action<Vector2> OnDrag;

        public event Action<Vector2> OnDrop;

        private GameControls _controls;

        private Camera _camera;

        public PlayerInputController()
        {
            Init();
        }

        public void Init()
        {
            _camera = Camera.main;

            _controls = new GameControls();

            _controls.Enable();

            _controls.Gameplay.Tap.started += Tap;

            _controls.Gameplay.Drag.performed += Drag;

            _controls.Gameplay.Drag.canceled += Drop;
        }

        void IDisposable.Dispose()
        {
            _controls.Gameplay.Tap.started -= Tap;

            _controls.Gameplay.Drag.performed -= Drag;

            _controls.Gameplay.Drag.canceled -= Drop;

            _controls.Disable();
        }

        private void Tap(InputAction.CallbackContext context)
        {
            OnTap?.Invoke(GetPointerPosition(context));
        }

        private void Drag(InputAction.CallbackContext context)
        {
            OnDrag?.Invoke(GetPointerPosition(context));
        }

        private void Drop(InputAction.CallbackContext context)
        {
            OnDrop?.Invoke(GetPointerPosition(context));
        }

        private Vector2 GetPointerPosition(InputAction.CallbackContext context)
        {
            var clickPositionScreen = context.ReadValue<Vector2>();

            return _camera.ScreenToWorldPoint(clickPositionScreen);
        }
    }
}