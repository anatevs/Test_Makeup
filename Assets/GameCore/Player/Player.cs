using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class Player : MonoBehaviour
    {
        private PlayerInputController _input;

        private int _eyeShadowId;

        private int _lipstickId;

        private int _blushId;

        private int _skinId;


        private void Start()
        {
            _input = new();
        }
    }
}