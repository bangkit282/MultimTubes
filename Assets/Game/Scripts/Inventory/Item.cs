using UnityEngine;

namespace MultimTubes
{
    public class Item : MonoBehaviour
    {
        [Header("Item Settings")]
        [SerializeField] private ItemSO _itemData;
        [SerializeField] private int _quantity;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(ConstString.PLAYER_TAG))
            {
                GameEventManager.OnInventoryItemAddEvent?.Invoke(_itemData, _quantity);
                Destroy(gameObject);
            }
        }
    }
}
