using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MultimTubes
{
    public class InventoryUI : MonoBehaviour
    {
        [Header("Slots")]
        [SerializeField] private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

        private void OnEnable()
        {
            GameEventManager.OnInventoryContentChangeEvent += OnInventoryContentChange;
        }

        private void Start()
        {
            foreach (InventorySlot slot in _inventorySlots)
            {
                if (slot == null)
                {
                    continue;
                }

                if (slot.IsItemDataEmpty())
                {
                    slot.gameObject.SetActive(false);
                }
            }
        }

        private void OnDisable()
        {
            GameEventManager.OnInventoryContentChangeEvent -= OnInventoryContentChange;
        }

        private void OnInventoryContentChange(List<ItemSO> inventoryItems)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (!_inventorySlots[i].IsItemDataEmpty() && _inventorySlots[i].IsItemDataSame(inventoryItems[i]))
                {
                    foreach (var group in inventoryItems.GroupBy(item => item))
                    {
                        _inventorySlots[i].UpdateItemQuantity(group.Count());
                    }

                    break;
                }

                _inventorySlots[i].UpdateSlotUI(inventoryItems[i]);
                _inventorySlots[i].gameObject.SetActive(true);
            }
        }
    }
}
