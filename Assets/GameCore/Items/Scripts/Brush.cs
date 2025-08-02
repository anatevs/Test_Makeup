using DG.Tweening;
using UnityEngine;

namespace GameCore
{
    public class Brush : ColoredItem
    {
        [SerializeField]
        private float _colorWobbleWidth = 20;

        [SerializeField]
        private float _colorWobbleDuration = 2f;

        private float _colorHalfWidth;

        private float _colorHalfDuration;


        protected override void Start()
        {
            base.Start();

            _colorHalfWidth = _colorWobbleWidth / 2;
            _colorHalfDuration = _colorWobbleDuration / 2;
        }

        protected override void ColorItem(Vector3 colorPos, Sequence sequence)
        {
            sequence
                .Join(transform.DOMove(colorPos, _moveDuration));

            var wobble = Wobble(colorPos.x,
                _colorWobbleWidth, _colorWobbleDuration,
                _colorHalfWidth, _colorHalfDuration);

            sequence
                .Append(wobble);
        }
    }
}