using UnityEngine;

namespace MultimTubes
{
    public class PlayerJump : MonoBehaviour
    {
        [Header("Jump Settings")]
        [SerializeField] private float _jumpHeight;

        [Header("Jump Detection")]
        [SerializeField] private Transform _detectPoint;
        [SerializeField] private float _detectRange;
        [SerializeField] private LayerMask _groundLayerMask;

        private Rigidbody _rigidbody;
        private Collider[] _overlapResult;

        private bool _canJump;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _overlapResult = new Collider[10];
        }

        private void FixedUpdate()
        {
            int hitCount = Physics.OverlapSphereNonAlloc(_detectPoint.position, _detectRange, _overlapResult, _groundLayerMask);

            if (hitCount > 0)
            {
                _canJump = true;
            }
            else
            {
                _canJump = false;
            }
        }

        public void Jump()
        {
            if (!_canJump)
            {
                return;
            }

            float jumpForce = Mathf.Sqrt(_jumpHeight * -2f * (Physics.gravity.y * _rigidbody.mass));
            Vector2 jumpDirection = new Vector2(0f, jumpForce);
            _rigidbody.AddForce(jumpDirection, ForceMode.Impulse);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_detectPoint.position, _detectRange);
        }
    }
}
