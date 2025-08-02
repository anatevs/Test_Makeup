using System.Collections;
using UnityEngine;

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
        private MakeupView _view;

        private void OnEnable()
        {
            _eyeshadow.OnReady += _player.SetCurrentHanded;

            _eyeshadow.OnFaceIntersected += _player.SetEyeShadow;

            _eyeshadow.OnMakeupStarted += _view.MakeEyeshadow;



            _lipstick.OnReady += _player.SetCurrentHanded;

            _lipstick.OnFaceIntersected += _player.SetEyeShadow;

            _lipstick.OnMakeupStarted += _view.ApplyLipstick;
        }

        private void OnDisable()
        {
            _eyeshadow.OnReady -= _player.SetCurrentHanded;

            _eyeshadow.OnFaceIntersected -= _player.SetEyeShadow;

            _eyeshadow.OnMakeupStarted -= _view.MakeEyeshadow;


            _lipstick.OnReady -= _player.SetCurrentHanded;

            _lipstick.OnFaceIntersected -= _player.SetEyeShadow;

            _lipstick.OnMakeupStarted -= _view.ApplyLipstick;
        }
    }
}