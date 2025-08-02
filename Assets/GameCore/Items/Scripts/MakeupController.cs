using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    public class MakeupController : MonoBehaviour
    {
        [SerializeField]
        private Player _player;

        [SerializeField]
        private EyeshadowMenu _eyeshadow;

        [SerializeField]
        private LipstickMenu _lipstick;

        [SerializeField]
        private CreamMenu _cream;

        [SerializeField]
        private Button _sponge;

        [SerializeField]
        private MakeupView _view;

        private void OnEnable()
        {
            _eyeshadow.OnReady += _player.SetCurrentHanded;

            _eyeshadow.OnFaceIntersected += _player.SetEyeShadow;

            _eyeshadow.OnMakeupStarted += _view.MakeEyeshadow;



            _lipstick.OnReady += _player.SetCurrentHanded;

            _lipstick.OnFaceIntersected += _player.SetLipstick;

            _lipstick.OnMakeupStarted += _view.ApplyLipstick;


            _cream.OnReady += _player.SetCurrentHanded;

            _cream.OnFaceIntersected += _player.SetSkin;

            _cream.OnMaskingStarted += _view.RemoveAkne;


            _sponge.onClick.AddListener(_view.ClearMakeup);
        }

        private void OnDisable()
        {
            _eyeshadow.OnReady -= _player.SetCurrentHanded;

            _eyeshadow.OnFaceIntersected -= _player.SetEyeShadow;

            _eyeshadow.OnMakeupStarted -= _view.MakeEyeshadow;


            _lipstick.OnReady -= _player.SetCurrentHanded;

            _lipstick.OnFaceIntersected -= _player.SetLipstick;

            _lipstick.OnMakeupStarted -= _view.ApplyLipstick;


            _cream.OnReady -= _player.SetCurrentHanded;

            _cream.OnFaceIntersected -= _player.SetSkin;

            _cream.OnMaskingStarted -= _view.RemoveAkne;


            _sponge.onClick.RemoveAllListeners();
        }
    }
}