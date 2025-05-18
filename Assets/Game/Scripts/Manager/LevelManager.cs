using HeneGames.DialogueSystem;
using MoreMountains.Tools;
using UnityEngine;

namespace MultimTubes
{
    public class LevelManager : MMSingleton<LevelManager>
    {
        [Header("Level Data")]
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
    }
}
