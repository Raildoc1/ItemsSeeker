using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace ItemsSeeker.Levels
{
    class RequiredItemList
    {
        public class Item
        {
            public string Name;
            public bool PickedUp;
        }

        readonly RequiredItemListSettings _settings;
        readonly List<Item> _requiredItems;

        public event Action<string> OnItemPickedUp;

        public bool HasItems => _requiredItems.Count > 0;
        public IReadOnlyCollection<Item> RequiredItems => _requiredItems;

        public RequiredItemList(RequiredItemListSettings settings)
        {
            _settings = settings;

            _requiredItems = new List<Item>();
            foreach (var itemName in settings.RequiredItems)
            {
                _requiredItems.Add(
                    new Item
                    {
                        Name = itemName,
                        PickedUp = false
                    }
                );
            }
        }

        public bool TryRemoveItem(string itemName)
        {
            foreach (var item in _requiredItems)
            {
                if (item.Name != itemName)
                    continue;

                item.PickedUp = true;
                OnItemPickedUp?.Invoke(item.Name);
                return true;
            }

            return false;
        }
    }
}
