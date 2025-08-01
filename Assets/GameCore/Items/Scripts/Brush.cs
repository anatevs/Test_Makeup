using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace GameCore
{
    public class Brush : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _atHandRotation = new(0, 0, 10);

        [SerializeField]
        private float _toHandDuration = 0.5f;

        [SerializeField]
        private float _wobbleWidth = 20;

        [SerializeField]
        private float _wobbleDuration = 2f;

        [SerializeField]
        private int _wobbleCount = 3;

        private bool _isInteractable = false;

        private float _wobbleHalfWidth;

        private float _wobbleHalfDuration;

        private void Start()
        {
            _wobbleHalfWidth = _wobbleWidth / 2;
            _wobbleHalfDuration = _wobbleDuration / 2;
        }

        public void ColorBrush(Vector3 pos)
        {
            Sequence wobble = DOTween.Sequence().Pause();

            wobble.Append(transform.DOMoveX(transform.position.x + _wobbleHalfWidth, _wobbleHalfDuration));

            for (int i = 0; i < _wobbleCount - 1; i++)
            {
                wobble.Append(transform.DOMoveX(transform.position.x - _wobbleWidth, _wobbleDuration));
                wobble.Append(transform.DOMoveX(transform.position.x + _wobbleWidth, _wobbleDuration));
            }

            wobble.Append(transform.DOMoveX(transform.position.x - _wobbleHalfWidth, _wobbleHalfDuration));

            Sequence sequence = DOTween.Sequence().Pause();

            sequence
                .Append(transform.DORotate(_atHandRotation, _toHandDuration))
                .Append(wobble)
                ;

            sequence.Play();
        }

        private void SetInteractable(bool isInteractable)
        {
            _isInteractable = isInteractable;
        }
    }
}