using System.Collections.Generic;

internal class ItemsRepository : BaseController, IItemsRepository
{
    private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

    public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;

    public ItemsRepository(List<ItemConfig> upgradeItemConfigs)
    {
        PopulateItems(ref _itemsMapById, upgradeItemConfigs);
    }

    protected override void OnDispose()
    {
        base.OnDispose();
        _itemsMapById.Clear();
        _itemsMapById = null;
    }

    private void PopulateItems(ref Dictionary<int, IItem> itemsMapById, List<ItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (itemsMapById.ContainsKey(config.Id))
            {
                continue;
            }

            itemsMapById.Add(config.Id, CreateItem(config));
        }
    }

    private IItem CreateItem(ItemConfig config)
    {
        return new Item()
        {
            Id = config.Id,
            Info = new ItemInfo { Title = config.Title }
        };
    }
}
