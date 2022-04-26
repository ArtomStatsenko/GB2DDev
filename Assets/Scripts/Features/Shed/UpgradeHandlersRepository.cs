using System;
using System.Collections.Generic;

internal class UpgradeHandlersRepository : BaseController, IRepository<int, IUpgradeHandler>
{
    private Dictionary<int, IUpgradeHandler> _upgradeItemsMapById = new Dictionary<int, IUpgradeHandler>();

    public IReadOnlyDictionary<int, IUpgradeHandler> Collection => _upgradeItemsMapById;

    public UpgradeHandlersRepository(List<UpgradeItemConfig> itemConfigs)
    {
        PopulateItems(ref _upgradeItemsMapById, itemConfigs);
    }

    protected override void OnDispose()
    {
        _upgradeItemsMapById.Clear();
        _upgradeItemsMapById = null;
    }

    private void PopulateItems(ref Dictionary<int, IUpgradeHandler> upgradeItemsMapByType, List<UpgradeItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (upgradeItemsMapByType.ContainsKey(config.Id))
            {
                continue;
            }

            upgradeItemsMapByType.Add(config.Id, CreateHandlerByType(config));
        }
    }

    private IUpgradeHandler CreateHandlerByType(UpgradeItemConfig config)
    {
        switch (config.Type)
        {
            case UpgradeType.Speed:
                return new SpeedUpgradeCarHandler(config.Value);
            default:
                return StubUpgradeCarHandler.Default;
        }
    }
}