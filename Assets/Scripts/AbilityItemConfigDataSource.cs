using UnityEngine;

[CreateAssetMenu(fileName = "AbilityItemConfigDataSource", menuName = "Configs/AbilityItemConfigDataSource", order = 0)]
public class AbilityItemConfigDataSource : ScriptableObject
{
    public AbilityItemConfig[] ItemConfigs;
}