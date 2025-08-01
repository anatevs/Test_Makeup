using System.Collections;
using UnityEngine;

namespace GameCore
{
    public class MakeupController : MonoBehaviour
    {
        [SerializeField]
        private Player _player;

        [SerializeField]
        private EyeshadowItem _eyeshadow;

        private void Start()
        {
            
        }

        private void OnEnable()
        {
            _eyeshadow.OnReady += _player.SetCurrentHanded;

            _eyeshadow.OnFaceIntersected += _player.SetEyeShadow;
        }

        private void OnDisable()
        {
            _eyeshadow.OnReady -= _player.SetCurrentHanded;

            _eyeshadow.OnFaceIntersected -= _player.SetEyeShadow;
        }
    }
}