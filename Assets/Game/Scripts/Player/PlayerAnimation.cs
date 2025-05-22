using UnityEngine;

namespace MultimTubes
{
    public class PlayerAnimation : MonoBehaviour
    {
        [Header("Animation Controller")]
        [SerializeField] private Animator _animator;

        private void OnEnable()
        {
            GameEventManager.OnLevelStartEvent += OnLevelStart;
            GameEventManager.OnLevelEndEvent += OnLevelEnd;
        }

        private void OnDisable()
        {
            GameEventManager.OnLevelStartEvent -= OnLevelStart;
            GameEventManager.OnLevelEndEvent -= OnLevelEnd;
        }

        public void PlayJumpAnimation()
        {
            _animator.SetTrigger("Jump");
        }

        public void PlayAttackAnimation()
        {
            _animator.SetTrigger("Attack");
        }

        private void PlayRunAnimation()
        {
            _animator.SetBool("Running", true);
        }

        private void StopRunAnimation()
        {
            _animator.SetBool("Running", false);
        }

        private void OnLevelStart()
        {
            PlayRunAnimation();
        }

        private void OnLevelEnd()
        {
            StopRunAnimation();
        }
    }
}
