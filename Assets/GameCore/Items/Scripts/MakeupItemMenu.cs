using System;
using UnityEngine;

namespace GameCore
{
    public abstract class MakeupItemMenu : MonoBehaviour
    {
        public event Action<Collider2D> OnReady;

        public event Action<int> OnFaceIntersected;

        public event Action<float, Sprite> OnMakeupStarted;

        [SerializeField]
        protected MakeupTool _tool;

        [SerializeField]
        protected MakeupItemConfig _config;

        [SerializeField]
        protected Pallet _pallet;

        [SerializeField]
        protected Transform _readyPoint;

        [SerializeField]
        protected Transform _makeupPoint;

        [SerializeField]
        protected BoxCollider2D _faceCollider;

        protected int _currentSelected;

        public virtual void Apply(int id)
        {
            OnFaceIntersected?.Invoke(id);

            _tool.ApplyItem(_makeupPoint.position);
        }

        public virtual void Select(int id, Vector2 pos)
        {
            _currentSelected = id;

            _tool.PrepareItem(pos, _readyPoint.position);
        }

        protected virtual void InitPallet()
        {
            _pallet.OnButtonClicked += Select;

            for (int i = 0; i < _config.MaxId; i++)
            {
                _pallet.AddButton(_config.GetPalletSprite(i), i);
            }
        }

        protected void MakeOnReady(Collider2D item)
        {
            OnReady?.Invoke(item);
        }

        protected void CheckCollision(Collider2D collider)
        {
            if (collider == _faceCollider)
            {
                Apply(_currentSelected);
            }
        }

        protected virtual void DoMakeup(float duration)
        {
            var sprite = _config.GetFaceSprite(_currentSelected);

            OnMakeupStarted?.Invoke(duration, sprite);
        }

        private void Start()
        {
            InitPallet();
        }

        private void OnEnable()
        {
            _tool.OnReady += MakeOnReady;

            _tool.OnTriggered += CheckCollision;

            _tool.OnMakeupStarted += DoMakeup;
        }

        protected virtual void OnDisable()
        {
            _tool.OnReady -= MakeOnReady;

            _tool.OnTriggered -= CheckCollision;

            _tool.OnMakeupStarted -= DoMakeup;

            if (_pallet != null)
            {
                _pallet.OnButtonClicked -= Select;
            }
        }
    }
}