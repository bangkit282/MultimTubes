using UnityEngine;

namespace MultimTubes
{
    public class FinishPoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(ConstString.PLAYER_TAG))
            {
                GameManager.Instance.ReachFinishPoint();
            }
        }
    }
}
