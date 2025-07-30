using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class Player : MonoBehaviour
    {
        private PlayerInputController _input;

        private void Start()
        {
            _input = new();
        }
    }
}