using UnityEngine;

namespace MultimTubes
{
    public class PlayerAttack : MonoBehaviour
    {
        private const int OVERLAP_RESULT_SIZE = 1;

        [Header("Attack Settings")]
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _attackRange;
        [SerializeField] private LayerMask _targetLayerMask;

        private Collider[] _overlapResult;

        private void Start()
        {
            _overlapResult = new Collider[OVERLAP_RESULT_SIZE];
        }

        public void Attack()
        {
            ClearOverlapResult();

            int hitCount = Physics.OverlapSphereNonAlloc(_attackPoint.position, _attackRange, _overlapResult, _targetLayerMask);

            if (hitCount > 0)
            {
                Debug.Log($"Player attack {_overlapResult[0].name}");
            }
            else
            {
                Debug.Log($"Player attack nothing");
            }
        }

        private void ClearOverlapResult()
        {
            for (int i = 0; i < _overlapResult.Length; i++)
            {
                _overlapResult[i] = null;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
        }
    }
}
