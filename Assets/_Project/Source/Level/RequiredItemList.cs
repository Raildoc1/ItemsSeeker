using System.Collections.Generic;

namespace ItemsSeeker.Levels
{
    class RequiredItemList
    {
        readonly RequiredItemListSettings _settings;
        readonly List<string> _requiredItems;

        public bool HasItems => _requiredItems.Count > 0;

        public RequiredItemList(RequiredItemListSettings settings)
        {
            _settings = settings;
            _requiredItems = new List<string>(settings.RequiredItems);
        }

        public bool TryRemoveItem(string itemName)
        {
            return _requiredItems.Remove(itemName);
        }
    }
}
