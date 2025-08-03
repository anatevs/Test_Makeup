using System;
using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "MakeupItemConfig",
        menuName = "Configs/Makeup")]
    public class MakeupItemConfig : ScriptableObject
    {
        public int MaxId => _itemsData.Length;

        [SerializeField]
        private Sprite _baseItemImage;

        [SerializeField]
        private ItemData[] _itemsData;

        public Sprite GetColoredItemSprite(int id)
        {
            return _itemsData[id].ColoredItemImage;
        }

        public Sprite GetPalletSprite(int id)
        {
            return _itemsData[id].PalletImage;
        }

        public Sprite GetFaceSprite(int id)
        {
            return _itemsData[id].FaceImage;
        }

        public string GetName(int id)
        {
            return _itemsData[id].Name;
        }
    }


    [Serializable]
    public struct ItemData
    {
        public string Name;

        public Sprite ColoredItemImage;

        public Sprite PalletImage;

        public Sprite FaceImage;
    }
}