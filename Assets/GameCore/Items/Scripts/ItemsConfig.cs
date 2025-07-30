using System;
using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "ItemsConfig",
        menuName = "Configs/Items")]
    public class ItemsConfig : ScriptableObject
    {
        public int Count => _itemsData.Length;

        [SerializeField]
        private Sprite _baseItemImage;

        [SerializeField]
        private ItemData[] _itemsData;

        public Sprite GetSprite(int id)
        {
            return _itemsData[id].ItemImage;
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

        public Sprite ItemImage;

        public Sprite PalleteImage;

        public Sprite FaceImage;
    }
}