using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MultimTubes
{
    public class InputManager : MMPersistentSingleton<InputManager>
    {
        [Header("Input Events")]
        [SerializeField] private UnityEvent OnJumpPerformEvent;
        [SerializeField] private UnityEvent OnAttackPerformEvent;

        private PlayerInputAction _playerInputAction;

        protected override void Awake()
        {
            base.Awake();

            _playerInputAction = new PlayerInputAction();
        }

        private void OnEnable()
        {
            EnableInput();
            SubscribeInputEvents();
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Keyboard.current.enterKey.isPressed)
            {
                GameManager.Instance.StartLevel();
            }
        }
#endif

        private void OnDisable()
        {
            DisableInput();
            UnsubscribeInputEvents();
        }

        public void EnableInput()
        {
            _playerInputAction.Enable();
        }

        public void DisableInput()
        {
            _playerInputAction.Disable();
        }

        private void SubscribeInputEvents()
        {
            _playerInputAction.Player.Jump.performed += OnPlayerJumpPerformed;
            _playerInputAction.Player.Attack.performed += OnPlayerAttackPerformed;
        }

        private void UnsubscribeInputEvents()
        {
            _playerInputAction.Player.Jump.performed -= OnPlayerJumpPerformed;
            _playerInputAction.Player.Attack.performed -= OnPlayerAttackPerformed;
        }

        private void OnPlayerJumpPerformed(InputAction.CallbackContext obj)
        {
            OnJumpPerformEvent.Invoke();
        }

        private void OnPlayerAttackPerformed(InputAction.CallbackContext obj)
        {
            OnAttackPerformEvent.Invoke();
        }
    }
}
