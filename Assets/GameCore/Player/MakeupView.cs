using DG.Tweening;
using System;
using System.Collections.Generic;
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
        private Image _blushImage;

        [SerializeField]
        private Image _akneImage;

        [SerializeField]
        private Image _tempImage;

        private Color _tempImgColor;

        private readonly List<Image> _makeupImages = new();
        private Sprite[] _defaultSprites;

        private void Start()
        {
            _tempImgColor = _tempImage.color;

            _makeupImages.Add(_eyeShadowImage);
            _makeupImages.Add(_lipsImage);
            _makeupImages.Add(_blushImage);
            //_makeupImages.Add(_akneImage);


            _defaultSprites = new Sprite[_makeupImages.Count];

            for (int i = 0; i < _makeupImages.Count; i++)
            {
                _defaultSprites[i] = _makeupImages[i].sprite;
            }
        }

        public void MakeEyeshadow(float duration, Sprite newSprite)
        {
            SetMakeupSprite(_eyeShadowImage, newSprite, duration);
        }

        public void ApplyLipstick(float duration, Sprite newSprite)
        {
            SetMakeupSprite(_lipsImage, newSprite, duration);
        }

        public void RemoveAkne(float duration)
        {
            _akneImage.DOFade(0, duration)
                .OnComplete(() => OnMakeupDone?.Invoke());
        }

        public void ClearMakeup()
        {
            for (int i = 0; i < _makeupImages.Count; i++)
            {
                if (_makeupImages[i].sprite != null)
                {
                    _makeupImages[i].sprite = _defaultSprites[i];

                    var color = _makeupImages[i].color;
                    color.a = 0;
                    _makeupImages[i].color = color;
                }
            }

            var aknColor = _akneImage.color;
            aknColor.a = 1;
            _akneImage.color = aknColor;
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