using UnityEngine;

[CreateAssetMenu(fileName = "AbilityItem", menuName = "Configs/AbilityItem", order = 0)]
public class AbilityItemConfig : ScriptableObject
{
    public ItemConfig ItemConfig;
    public GameObject View;
    public AbilityType type;
    public float value;

    public int Id => ItemConfig.Id;
}
