using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Item/Create New Item")]
public class Item : ScriptableObject
{
    public int ID;
    public string itemName;
    [TextArea]public string itemDescription;
    public Sprite itemIcon;
}
