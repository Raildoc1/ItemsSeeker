using ItemsSeeker.Core;
using ItemsSeeker.Levels.View;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsSeeker.Levels
{
    class RequiredItemListView : ViewMono
    {
        [SerializeField] private Transform _itemViewsContainer;
        [SerializeField] private ItemNameView _itemNameViewPrefab;

        RequiredItemList _requiredItemList;
        Dictionary<string, ItemNameView> _viewsMap;

        public void Construct(CompositionRoot root, RequiredItemList requiredItemList)
        {
            root.RegisterView(this);

            _viewsMap = new Dictionary<string, ItemNameView>();
            _requiredItemList = requiredItemList;
        }

        public override void Init()
        {
            foreach (var item in _requiredItemList.RequiredItems)
            {
                var itemNameView = Instantiate(_itemNameViewPrefab, _itemViewsContainer);
                itemNameView.SetItemName(item.Name);
                _viewsMap[item.Name] = itemNameView;
            }

            _requiredItemList.OnItemPickedUp += OnItemPickedUp;
        }

        public override void Deinit()
        {
            _requiredItemList.OnItemPickedUp -= OnItemPickedUp;
        }

        void OnItemPickedUp(string itemName)
        {
            _viewsMap[itemName].Strikethrough();
        }
    }
}
