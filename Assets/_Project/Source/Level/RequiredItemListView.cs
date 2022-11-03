using ItemsSeeker.Levels.View;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsSeeker.Levels
{
    class RequiredItemListView : MonoBehaviour
    {
        [SerializeField] private Transform _itemViewsContainer;
        [SerializeField] private ItemNameView _itemNameViewPrefab;

        Dictionary<string, ItemNameView> _viewsMap;

        public void Init(RequiredItemList requiredItemList)
        {
            _viewsMap = new Dictionary<string, ItemNameView>();

            foreach (var item in requiredItemList.RequiredItems)
            {
                var itemNameView = Instantiate(_itemNameViewPrefab, _itemViewsContainer);
                itemNameView.Init(item.Name);
                _viewsMap[item.Name] = itemNameView;
            }

            requiredItemList.OnItemPickedUp += OnItemPickedUp;
        }

        void OnItemPickedUp(string itemName)
        {
            _viewsMap[itemName].Strikethrough();
        }
    }
}
