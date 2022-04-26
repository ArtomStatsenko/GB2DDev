using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeItemConfig", menuName = "Configs/UpgradeItem", order = 0)]
public sealed class UpgradeItemConfig : ScriptableObject
{
    public ItemConfig ItemConfig;
    public UpgradeType Type;
    public float Value;

    public int Id => ItemConfig.Id;
}
