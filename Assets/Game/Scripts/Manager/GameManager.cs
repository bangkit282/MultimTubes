using MoreMountains.Tools;
using UnityEngine;

namespace MultimTubes
{
    public class GameManager : MMPersistentSingleton<GameManager>
    {
        [Header("Managers")]
        [SerializeField] private LevelManager _levelData;

        [Header("Game Loop")]
        [SerializeField, MMReadOnly] private bool _isLevelStarted;
        [SerializeField, MMReadOnly] private bool _hasReachFinishPoint;

        [Header("Currency")]
        [SerializeField] private int _coin;

        [Header("Inventory")]
        [SerializeField] private Inventory _inventory;

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
            _inputManager.DisablePlayerInput();

            if (_inventory.GetInventoryItems().Contains(_levelData.GetLevelKeyItem()))
            {
                LevelManager.Instance.TriggerOnKeyItemCollected();
                Debug.Log($"Key Item Acquired");
            }
            else
            {
                LevelManager.Instance.TriggerOnKeyItemNotCollected();
                Debug.Log($"Key Item Not Acquired");
            }
        }

        public void AddCoin(int coin)
        {
            _coin += coin;
            GameEventManager.OnCoinAddEvent?.Invoke(coin);
        }
    }
}
