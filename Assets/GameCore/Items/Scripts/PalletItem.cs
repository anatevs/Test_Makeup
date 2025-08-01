using UnityEngine;

namespace GameCore
{
    public abstract class PalletItem : MonoBehaviour
    {
        [SerializeField]
        protected ItemConfig _config;

        [SerializeField]
        protected Pallet _pallet;

        protected int _currentSelected;

        public abstract void Select(int id, Vector2 pos);
        public abstract void Apply(int id);

        protected virtual void InitPallet()
        {
            _pallet.OnButtonClicked += Select;

            for (int i = 0; i < _config.MaxId; i++)
            {
                _pallet.AddButton(_config.GetPalletSprite(i), i);
            }
        }

        private void Start()
        {
            InitPallet();
        }

        private void OnDisable()
        {
            _pallet.OnButtonClicked -= Select;
        }
    }
}