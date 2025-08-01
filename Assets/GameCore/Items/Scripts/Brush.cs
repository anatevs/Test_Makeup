using UnityEngine;
using DG.Tweening;
using System;

namespace GameCore
{
    [RequireComponent(typeof(Collider2D))]
    public class Brush : MonoBehaviour
    {
        public event Action<Collider2D> OnReady;

        public event Action<Collider2D> OnTriggered;

        [SerializeField]
        private Vector3 _atHandRotation = new(0, 0, 10);

        [SerializeField]
        private float _toHandDuration = 0.5f;

        [SerializeField]
        private float _colorWobbleWidth = 20;

        [SerializeField]
        private float _colorWobbleDuration = 2f;

        [SerializeField]
        private float _makeupWobbleWidth = 20;

        [SerializeField]
        private float _makeupWobbleDuration = 2f;

        [SerializeField]
        private int _wobbleCount = 3;

        [SerializeField]
        private float _moveDuration = 0.5f;

        private float _colorHalfWidth;

        private float _colorHalfDuration;

        private float _makeupHalfWidth;

        private float _makeupHalfDuration;

        private Collider2D _collider;

        private void Start()
        {
            _collider = GetComponent<Collider2D>();

            _colorHalfWidth = _colorWobbleWidth / 2;
            _colorHalfDuration = _colorWobbleDuration / 2;

            _makeupHalfWidth = _makeupWobbleWidth / 2;
            _makeupHalfDuration = _makeupWobbleDuration / 2;
        }

        public void ColorBrush(Vector3 colorPos, Vector3 endPosition)
        {
            var sequence = DOTween.Sequence();

            sequence
                .Append(transform.DORotate(_atHandRotation, _toHandDuration))
                .Join(transform.DOMove(colorPos, _moveDuration));

            var wobble = Wobble(colorPos.x, _colorWobbleWidth, _colorWobbleDuration, _colorHalfWidth, _colorHalfDuration);

            sequence
                .Append(wobble)
                .Append(transform.DOMove(endPosition, _moveDuration))
                .OnComplete(() => OnReady?.Invoke(_collider));

            sequence.Play();
        }

        public void MakeEyeshadow(Vector3 eyePoint)
        {
            var sequence = DOTween.Sequence().Pause();

            sequence
                .Append(transform.DOMove(eyePoint, _moveDuration));


            var wobble = Wobble(eyePoint.x, _makeupWobbleWidth, _makeupWobbleDuration, _makeupHalfWidth, _makeupHalfDuration);

            sequence
                .Append(wobble);

            sequence.Play();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTriggered?.Invoke(collision);
        }

        private Sequence Wobble(float xCenter, float width, float duration, float halfWidth, float halfDuration)
        {
            var wobble = DOTween.Sequence().Pause();

            wobble.Append(transform.DOMoveX(xCenter + halfWidth, halfDuration));

            for (int i = 0; i < _wobbleCount - 1; i++)
            {
                wobble.Append(transform.DOMoveX(xCenter - width, duration));
                wobble.Append(transform.DOMoveX(xCenter + width, duration));
            }

            wobble.Append(transform.DOMoveX(xCenter, halfDuration));

            return wobble;
        }
    }
}