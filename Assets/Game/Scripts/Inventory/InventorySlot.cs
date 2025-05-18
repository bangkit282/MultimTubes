using MoreMountains.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MultimTubes
{
    public class InventorySlot : MonoBehaviour
    {
        [Header("Item Data")]
        [SerializeField, MMReadOnly] private ItemSO _itemData;

        [Header("UI References")]
        [SerializeField] private Image _itemIconImage;
        [SerializeField] private TextMeshProUGUI _itemQuantityText;

        public void UpdateSlotUI(ItemSO itemData)
        {
            _itemData = itemData;
            _itemIconImage.sprite = _itemData.GetItemSprite();
            _itemQuantityText.text = $"1";
        }

        public void UpdateItemQuantity(int quantity)
        {
            _itemQuantityText.text = $"{quantity}";
        }

        public bool IsItemDataSame(ItemSO itemData)
        {
            return _itemData.GetItemId().Equals(itemData.GetItemId(), System.StringComparison.OrdinalIgnoreCase);
        }

        public bool IsItemDataEmpty()
        {
            return _itemData == null;
        }
    }
}
