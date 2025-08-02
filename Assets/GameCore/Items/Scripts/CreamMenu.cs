using System;

namespace GameCore
{
    public class CreamMenu : ColorableCosmeticMenu
    {
        public event Action<float> OnMaskingStarted;

        private Cream _cream;

        private void Awake()
        {
            _cream = _item as Cream;
        }

        protected override void InitPallet()
        {
            _cream.OnButtonClicked += Select;
        }

        protected override void DoMakeup(float duration)
        {
            OnMaskingStarted?.Invoke(duration);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _cream.OnButtonClicked -= Select;
        }
    }
}