using DG.Tweening;
using System;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

namespace GameCore
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class ColoredItem : MonoBehaviour
    {
        public event Action<Collider2D> OnReady;

        public event Action<Collider2D> OnTriggered;

        public event Action<float> OnMakeupStarted;

        [SerializeField]
        protected Vector3 _atHandRotation = new(0, 0, 10);

        [SerializeField]
        protected float _toHandDuration = 0.5f;

        [SerializeField]
        protected float _makeupWobbleWidth = 20;

        [SerializeField]
        protected float _makeupWobbleDuration = 2f;

        [SerializeField]
        protected int _wobbleCount = 3;

        [SerializeField]
        protected float _moveDuration = 0.5f;

        protected Vector3 _defaultPos;

        protected Vector3 _defaultRot = Vector3.zero;

        protected float _makeupHalfWidth;

        protected float _makeupHalfDuration;

        protected Collider2D _collider;

        protected float _makeupDuration;

        protected virtual void Start()
        {
            _defaultPos = transform.position;

            _collider = GetComponent<Collider2D>();

            _makeupDuration = _makeupWobbleDuration * _wobbleCount;

            _makeupHalfWidth = _makeupWobbleWidth / 2;
            _makeupHalfDuration = _makeupWobbleDuration / 2;
        }

        public void PrepareItem(Vector3 colorPos, Vector3 endPosition)
        {
            var sequence = DOTween.Sequence();

            TakeItem(colorPos, sequence);
            ColorItem(colorPos, sequence);

            sequence
                .Append(transform.DOMove(endPosition, _moveDuration))
                .OnComplete(() => OnReady?.Invoke(_collider));

            sequence.Play();
        }

        public void ApplyItem(Vector3 applyPoint)
        {
            var sequence = DOTween.Sequence().Pause();

            sequence
                .Append(transform.DOMove(applyPoint, _moveDuration))
                .AppendCallback(() => OnMakeupStarted?.Invoke(_makeupDuration));

            var wobble = Wobble(applyPoint.x,
                _makeupWobbleWidth, _makeupWobbleDuration,
                _makeupHalfWidth, _makeupHalfDuration);

            sequence
                .Append(wobble)
                .Append(transform.DOMove(_defaultPos, _moveDuration))
                .Join(transform.DORotate(_defaultRot, _moveDuration));

            sequence.Play();
        }

        protected virtual void TakeItem(Vector3 colorPos, Sequence sequence)
        {
            sequence
                .Append(transform.DORotate(_atHandRotation, _toHandDuration));
        }

        protected virtual void ColorItem(Vector3 colorPos, Sequence sequence)
        {
        }

        protected virtual Sequence ClearItem()
        {
            var sequence = DOTween.Sequence().Pause();
            
            return sequence;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTriggered?.Invoke(collision);
        }

        protected Sequence Wobble(float xCenter, float width, float duration, float halfWidth, float halfDuration)
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