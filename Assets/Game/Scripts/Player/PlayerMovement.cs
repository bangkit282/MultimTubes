using UnityEngine;

namespace MultimTubes
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _movementForce;
        [SerializeField] private float _maxMovementSpeed;

        private Rigidbody _rigidbody;
        private GameManager _gameManager;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _gameManager = GameManager.Instance;
        }

        private void FixedUpdate()
        {
            if (_gameManager.IsPlayerHasReachFinishPoint() || !_gameManager.IsLevelHasStarted())
            {
                return;
            }

            MovePlayer();
        }

        private void MovePlayer()
        {
            _rigidbody.AddForce(transform.forward * Time.fixedDeltaTime * _movementSpeed * _movementForce);

            Vector3 velocity = _rigidbody.velocity;
            velocity.z = Mathf.Clamp(velocity.z, 0f, _maxMovementSpeed);
            _rigidbody.velocity = velocity;
        }
    }
}
