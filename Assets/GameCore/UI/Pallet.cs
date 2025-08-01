using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    public class Pallet : MonoBehaviour
    {
        public event Action<int, Vector2> OnButtonClicked;

        [SerializeField]
        private Button _palletButton;

        private readonly List<Button> _buttons = new();

        public void AddButton(Sprite sprite, int id)
        {
            var buttonInstance = Instantiate(_palletButton, transform);

            var button = buttonInstance.GetComponent<Button>();

            button.image.sprite = sprite;

            button.onClick.AddListener(() => Click(id, button.transform.position));

            _buttons.Add(button);
        }

        private void Click(int id, Vector2 pos)
        {
            OnButtonClicked?.Invoke(id, pos);
        }

        private void OnDisable()
        {
            foreach (var button in _buttons)
            {
                button.onClick.RemoveAllListeners();
            }
        }
    }
}