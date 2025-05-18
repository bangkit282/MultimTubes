using UnityEngine;

namespace MultimTubes
{
    public class Coin : MonoBehaviour
    {
        [Header("Coin Settings")]
        [SerializeField] private int _coinValue;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(ConstString.PLAYER_TAG))
            {
                GameManager.Instance.AddCoin(_coinValue);
                Destroy(gameObject);
            }
        }
    }
}
