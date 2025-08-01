using System.Collections;
using UnityEngine;

namespace GameCore
{
    public class MakeupController : MonoBehaviour
    {
        [SerializeField]
        private Player _player;

        [SerializeField]
        private Eyeshadow _eyeshadow;

        [SerializeField]
        private MakeupView _view;

        private void OnEnable()
        {
            _eyeshadow.OnReady += _player.SetCurrentHanded;

            _eyeshadow.OnFaceIntersected += _player.SetEyeShadow;

            _eyeshadow.OnMakeupStarted += _view.MakeEyeshadow;
        }

        private void OnDisable()
        {
            _eyeshadow.OnReady -= _player.SetCurrentHanded;

            _eyeshadow.OnFaceIntersected -= _player.SetEyeShadow;

            _eyeshadow.OnMakeupStarted -= _view.MakeEyeshadow;
        }
    }
}