using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

namespace GameCore
{
    public class EyeshadowMenu : ColorableCosmetic
    {
        [SerializeField]
        private Brush _brush;

        public override void Apply(int id)
        {
            base.Apply(id);

            _brush.MakeEyeshadow(_makeupPoint.position);
        }

        public override void Select(int id, Vector2 pos)
        {
            base.Select(id, pos);

            _brush.PrepareBrush(pos, _readyPoint.position);
        }

        private void OnEnable()
        {
            _brush.OnReady += MakeOnReady;

            _brush.OnTriggered += CheckCollision;

            _brush.OnMakeupStarted += DoMakeup;
        }

        private void OnDisable()
        {
            _brush.OnReady -= MakeOnReady;

            _brush.OnTriggered -= CheckCollision;

            _brush.OnMakeupStarted -= DoMakeup;
        }
    }
}