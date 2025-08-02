using UnityEngine;

namespace GameCore
{
    public class LipstickMenu : ColorableCosmetic
    {
        [SerializeField]
        private Lipstick _lipstick;

        public override void Apply(int id)
        {
            base.Apply(id);

            _lipstick.ApplyItem(_makeupPoint.position);
        }

        public override void Select(int id, Vector2 pos)
        {
            base.Select(id, pos);

            _lipstick.SetViewSprite(_config.GetPalletSprite(id));

            _lipstick.PrepareItem(pos, _readyPoint.position);
        }

        private void OnEnable()
        {
            _lipstick.OnReady += MakeOnReady;

            _lipstick.OnTriggered += CheckCollision;

            _lipstick.OnMakeupStarted += DoMakeup;
        }

        private void OnDisable()
        {
            _lipstick.OnReady -= MakeOnReady;

            _lipstick.OnTriggered -= CheckCollision;

            _lipstick.OnMakeupStarted -= DoMakeup;
        }
    }
}