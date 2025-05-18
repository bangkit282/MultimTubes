using MoreMountains.Tools;
using UnityEngine;

namespace MultimTubes
{
    public class LevelManager : MMSingleton<LevelManager>
    {
        [Header("Level Info")]
        [SerializeField] private ItemSO _levelKeyItem;

        public ItemSO GetLevelKeyItem()
        {
            return _levelKeyItem;
        }
    }
}
