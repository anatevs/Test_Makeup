using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    public class MakeupView : MonoBehaviour
    {
        public event Action OnMakeupDone;

        [SerializeField]
        private Image _eyeShadowImage;

        [SerializeField]
        private Image _lipsImage;

        [SerializeField]
        private Image _tempImage;

        private Color _tempImgColor;

        private void Start()
        {
            _tempImgColor = _tempImage.color;
        }

        public void MakeEyeshadow(float duration, Sprite newSprite)
        {
            SetMakeupSprite(_eyeShadowImage, newSprite, duration);
        }

        public void ApplyLipstick(float duration, Sprite newSprite)
        {
            SetMakeupSprite(_lipsImage, newSprite, duration);
        }

        private void SetMakeupSprite(Image image, Sprite newSprite, float duration)
        {
            if (image.sprite != null)
            {
                _tempImage.sprite = image.sprite;
                _tempImgColor.a = 1;
                _tempImage.color = image.color;
            }

            var color = image.color;
            color.a = 0;
            image.color = color;
            image.sprite = newSprite;

            _tempImage.DOFade(0, duration);
            image.DOFade(1, duration)
                .OnComplete(() => OnMakeupDone?.Invoke());
        }
    }
}