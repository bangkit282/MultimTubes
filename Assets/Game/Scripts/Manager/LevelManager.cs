using HeneGames.DialogueSystem;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MultimTubes
{
    public class LevelManager : MMSingleton<LevelManager>
    {
        [Header("Level Data")]
        [SerializeField] private Transform _initialSpawnPoint;
        [SerializeField] private ItemSO _levelKeyItem;
        [SerializeField] private DialogueManager _onKeyItemCollectedDialogue;
        [SerializeField] private DialogueManager _onKeyItemNotCollectedDialogue;

        public ItemSO GetLevelKeyItem()
        {
            return _levelKeyItem;
        }

        public void TriggerOnKeyItemCollected()
        {
            _onKeyItemCollectedDialogue.TriggerDialogue();
        }

        public void TriggerOnKeyItemNotCollected()
        {
            _onKeyItemNotCollectedDialogue.TriggerDialogue();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
