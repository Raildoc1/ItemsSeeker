using ItemsSeeker.Core;
using System;
using System.Collections.Generic;

namespace ItemsSeeker.Levels
{
    class RequiredItemList : SceneComponent
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

        public RequiredItemList(
            CompositionRoot root,
            RequiredItemListSettings settings
        )
            : base(root)
        {
            _settings = settings;
            _requiredItems = new List<Item>();
        }

        public override void OnSceneLoaded()
        {
            foreach (var itemName in _settings.RequiredItems)
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

        public override void OnSceneWillUnload()
        {
            _requiredItems.Clear();
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
