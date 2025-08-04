using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCore
{
    public sealed class InputController :
        IDisposable
    {
        public event Action<Vector3> OnTapScreen;

        public event Action<Vector3> OnDragScreen;

        public event Action<Vector3> OnDropScreen;

        private GameControls _controls;

        public InputController()
        {
            Init();
        }

        public void Init()
        {
            _controls = new GameControls();

            _controls.Enable();

            _controls.Gameplay.Tap.performed += Tap;

            _controls.Gameplay.Drag.performed += Drag;

            _controls.Gameplay.Drag.canceled += Drop;
        }

        void IDisposable.Dispose()
        {
            _controls.Gameplay.Tap.performed -= Tap;

            _controls.Gameplay.Drag.performed -= Drag;

            _controls.Gameplay.Drag.canceled -= Drop;

            _controls.Disable();
        }

        private void Tap(InputAction.CallbackContext context)
        {
            OnTapScreen?.Invoke(GetPointerScreenPosition(context));
        }

        private void Drag(InputAction.CallbackContext context)
        {
            OnDragScreen?.Invoke(GetPointerScreenPosition(context));
        }

        private void Drop(InputAction.CallbackContext context)
        {
            OnDropScreen?.Invoke(GetPointerScreenPosition(context));
        }

        private Vector3 GetPointerScreenPosition(InputAction.CallbackContext context)
        {
            return context.ReadValue<Vector2>();
        }
    }
}