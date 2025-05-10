using MoreMountains.Tools;
using UnityEngine;

namespace MultimTubes
{
    public class GameManager : MMPersistentSingleton<GameManager>
    {
        [Header("Game Loop")]
        [SerializeField, MMReadOnly] private bool _isLevelStarted;
        [SerializeField, MMReadOnly] private bool _hasReachFinishPoint;

        private InputManager _inputManager;

        private void Start()
        {
            _inputManager = InputManager.Instance;
        }

        public bool IsLevelHasStarted()
        {
            return _isLevelStarted;
        }

        public void StartLevel()
        {
            _isLevelStarted = true;
        }

        public bool IsPlayerHasReachFinishPoint()
        {
            return _hasReachFinishPoint;
        }

        public void ReachFinishPoint()
        {
            _isLevelStarted = false;
            _hasReachFinishPoint = true;
            _inputManager.DisableInput();
        }
    }
}
