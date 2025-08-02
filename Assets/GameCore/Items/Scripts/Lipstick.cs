using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

namespace GameCore
{
    public class Lipstick : ColoredItem
    {
        [SerializeField]
        private Image _view;

        [SerializeField]
        private Image _hidePalletImage;

        private Vector3 _viewShift;

        public void SetViewSprite(Sprite sprite)
        {
            _view.sprite = sprite;
        }

        private void Awake()
        {
            _viewShift = transform.position - _view.transform.position;
        }

        protected override Sequence TakeItem(Vector3 colorPos)
        {
            gameObject.SetActive(true);
            transform.position = colorPos + _viewShift;
            _defaultPos = transform.position;

            _hidePalletImage.transform.position = colorPos;
            _hidePalletImage.gameObject.SetActive(true);

            return base.TakeItem(colorPos);
        }

        protected override Sequence ClearItem()
        {
            return base.ClearItem()
                .OnComplete(() => 
                {
                    gameObject.SetActive(false);
                    _hidePalletImage.gameObject.SetActive(false);
                });
        }
    }
}