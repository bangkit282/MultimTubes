using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MultimTubes
{
    public class InputManager : MMSingleton<InputManager>
    {
        [Header("Input Events")]
        [SerializeField] private UnityEvent OnJumpPerformEvent;
        [SerializeField] private UnityEvent OnAttackPerformEvent;
        [SerializeField] private UnityEvent OnConfirmPerformEvent;

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

        public void EnablePlayerInput()
        {
            _playerInputAction.Player.Jump.Enable();
            _playerInputAction.Player.Attack.Enable();
        }

        public void DisablePlayerInput()
        {
            _playerInputAction.Player.Jump.Disable();
            _playerInputAction.Player.Attack.Disable();
        }

        private void SubscribeInputEvents()
        {
            _playerInputAction.Player.Jump.performed += OnPlayerJumpPerformed;
            _playerInputAction.Player.Attack.performed += OnPlayerAttackPerformed;
            _playerInputAction.Player.Confirm.performed += OnPlayerConfirmPerformed;
        }

        private void UnsubscribeInputEvents()
        {
            _playerInputAction.Player.Jump.performed -= OnPlayerJumpPerformed;
            _playerInputAction.Player.Attack.performed -= OnPlayerAttackPerformed;
            _playerInputAction.Player.Confirm.performed -= OnPlayerConfirmPerformed;
        }

        private void OnPlayerJumpPerformed(InputAction.CallbackContext obj)
        {
            OnJumpPerformEvent.Invoke();
        }

        private void OnPlayerAttackPerformed(InputAction.CallbackContext obj)
        {
            OnAttackPerformEvent.Invoke();
        }

        private void OnPlayerConfirmPerformed(InputAction.CallbackContext obj)
        {
            OnConfirmPerformEvent.Invoke();
        }
    }
}
