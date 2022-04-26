using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Configs/Item", order = 0)]
public sealed class ItemConfig : ScriptableObject
{
    public int Id;
    public string Title;
}
