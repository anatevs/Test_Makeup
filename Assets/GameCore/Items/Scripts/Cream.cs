using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    public class Cream : MakeupTool
    {
        public event Action<int, Vector2> OnButtonClicked;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(MakeOnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void MakeOnClick()
        {
            OnButtonClicked?.Invoke(0, transform.position);
        }
    }
}