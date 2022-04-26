using System;
using System.Collections.Generic;

internal class UpgradeHandlersRepository : BaseController
{
    private Dictionary<int, IUpgradeCarHandler> _upgradeItemsMapById = new Dictionary<int, IUpgradeCarHandler>();

    public IReadOnlyDictionary<int, IUpgradeCarHandler> UpgradeItems => _upgradeItemsMapById;

    public UpgradeHandlersRepository(List<UpgradeItemConfig> itemConfigs)
    {
        PopulateItems(ref _upgradeItemsMapById, itemConfigs);
    }

    protected override void OnDispose()
    {
        _upgradeItemsMapById.Clear();
        _upgradeItemsMapById = null;
    }

    private void PopulateItems(ref Dictionary<int, IUpgradeCarHandler> upgradeItemsMapByType, List<UpgradeItemConfig> configs)
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

    private IUpgradeCarHandler CreateHandlerByType(UpgradeItemConfig config)
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