using System.Collections.Generic;
using UnityEngine;

namespace MultimTubes
{
    public class Inventory : MonoBehaviour
    {
        [Header("Items")]
        [SerializeField] protected List<ItemSO> InventoryItems;

        private void OnEnable()
        {
            GameEventManager.OnInventoryItemAddEvent += AddItem;
            GameEventManager.OnInventoryItemRemoveEvent += RemoveItem;
        }

        private void OnDisable()
        {
            GameEventManager.OnInventoryItemAddEvent -= AddItem;
            GameEventManager.OnInventoryItemRemoveEvent -= RemoveItem;
        }

        protected virtual void AddItem(ItemSO item, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                InventoryItems.Add(item);
            }

            GameEventManager.OnInventoryContentChangeEvent?.Invoke(InventoryItems);
        }

        protected virtual void RemoveItem(ItemSO item, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                InventoryItems.Add(item);
            }

            GameEventManager.OnInventoryContentChangeEvent?.Invoke(InventoryItems);
        }
    }
}
