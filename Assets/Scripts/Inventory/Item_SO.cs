using UnityEngine;

[CreateAssetMenu(menuName = "Item/New Item")]
public class Item_SO : ScriptableObject
{
    public string Name; //the item name
    public string Description; //the item description in the UI
    public bool CanStack; //can this item stack in the inventory, or can keep only one?
    public int MaxStack; //if can stack, how many items of this type can you have?
    public int MinSpawnQuantity; //when this item is spawned, which is the min quantity spawned?
    public int MaxSpawnQuantity; //when this item is spawned, which is the max quantity spawned?
    public bool IsEquippable;
    public GameObject Prefab; //<- the 3d object representing the item in the real shop and when equipped
    public Sprite UIRepresentation; //<- the 2d sprite representing the item in both shop's and player's UI
}