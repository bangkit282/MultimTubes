using UnityEngine;

namespace MultimTubes
{
    public class DeadZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(ConstString.PLAYER_TAG))
            {
                Destroy(other.gameObject);
                GameEventManager.OnGameOverEvent?.Invoke();
            }
        }
    }
}
