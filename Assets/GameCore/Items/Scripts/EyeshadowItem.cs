using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace GameCore
{
    public class EyeshadowItem : PalletItem
    {
        [SerializeField]
        private Brush _brush;

        public override void Apply(int id)
        {
        }

        public override void Select(int id, Vector2 pos)
        {
            _brush.ColorBrush(pos);
        }
    }
}