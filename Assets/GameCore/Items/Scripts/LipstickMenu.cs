using UnityEngine;

namespace GameCore
{
    public class LipstickMenu : MakeupItemMenu
    {
        private Lipstick _lipstick;

        private void Awake()
        {
            _lipstick = _tool as Lipstick;
        }

        public override void Select(int id, Vector2 pos)
        {
            base.Select(id, pos);

            _lipstick.SetViewSprite(_config.GetPalletSprite(id));
        }
    }
}