using System;
using System.Collections.Generic;

namespace MultimTubes
{
    public static class GameEventManager
    {
        public static Action OnLevelStartEvent;
        public static Action OnLevelEndEvent;

        public static Action OnGameOverEvent;

        public static Action<ItemSO, int> OnInventoryItemAddEvent;
        public static Action<ItemSO, int> OnInventoryItemRemoveEvent;
        public static Action<List<ItemSO>> OnInventoryContentChangeEvent;

        public static Action<int> OnCoinAddEvent;
    }
}
