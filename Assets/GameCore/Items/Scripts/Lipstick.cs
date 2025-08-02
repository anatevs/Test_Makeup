using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    public class Lipstick : ColoredItem
    {
        [SerializeField]
        private Image _view;

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
            transform.position = colorPos + _viewShift;
            gameObject.SetActive(true);

            return base.TakeItem(colorPos);
        }
    }
}