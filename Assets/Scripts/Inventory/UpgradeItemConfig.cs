using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", menuName = "Configs/UpgradeItemConfigDataSource", order = 0)]
public sealed class UpgradeItemConfigDataSource : ScriptableObject
{
    public UpgradeItemConfig[] ItemConfigs;
}
