using UnityEngine;

namespace MultimTubes
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float _movementSpeed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            Vector3 direction = transform.position + transform.forward * Time.fixedDeltaTime * _movementSpeed;
            _rigidbody.MovePosition(direction);
        }
    }
}
