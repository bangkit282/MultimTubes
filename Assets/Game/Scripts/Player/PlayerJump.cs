using UnityEngine;

namespace MultimTubes
{
    public class PlayerJump : MonoBehaviour
    {
        [Header("Jump Settings")]
        [SerializeField] private float _jumpHeight;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Jump()
        {
            float jumpForce = Mathf.Sqrt(_jumpHeight * -2f * (Physics.gravity.y * _rigidbody.mass));
            Vector2 jumpDirection = new Vector2(0f, jumpForce);
            _rigidbody.AddForce(jumpDirection, ForceMode.Impulse);
        }
    }
}
