using UnityEngine;

namespace MultimTubes
{
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
    public class ItemSO : ScriptableObject
    {
        [Header("ItemSO Details")]
        [SerializeField] private string _itemId;
        [SerializeField] private string _itemName;
        [SerializeField] private Sprite _itemSprite;

        public string GetItemId()
        {
            return _itemId;
        }

        public string GetItemName()
        {
            return _itemName;
        }

        public Sprite GetItemSprite()
        {
            return _itemSprite;
        }
    }
}
