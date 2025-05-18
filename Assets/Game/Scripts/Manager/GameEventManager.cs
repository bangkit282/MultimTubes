using System;
using System.Collections.Generic;

namespace MultimTubes
{
    public static class GameEventManager
    {
        public static Action<ItemSO, int> OnInventoryItemAddEvent;
        public static Action<ItemSO, int> OnInventoryItemRemoveEvent;
        public static Action<List<ItemSO>> OnInventoryContentChangeEvent;

        public static Action<int> OnCoinAddEvent;
    }
}
