using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    [HideInInspector] public string Name;
    [HideInInspector] public string Description;
    [HideInInspector] public bool CanStack;
    [HideInInspector] public int MaxQuantity;
    [HideInInspector] public int Quantity;
    [HideInInspector] public bool IsEquippable;
    [HideInInspector] public GameObject Prefab; //<- the 3d object representing the item in 3d world
    [HideInInspector] public Sprite UIRepresentation; //<- the 2d sprite representing the item in UI

    public Item(Item_SO itemSO)
    {
        Name = itemSO.Name;
        Description = itemSO.Description;
        Prefab = itemSO.Prefab;
        UIRepresentation = itemSO.UIRepresentation;
        CanStack = itemSO.CanStack;
        MaxQuantity = itemSO.MaxStack;
        IsEquippable = itemSO.IsEquippable;
        Quantity = Random.Range(itemSO.MinSpawnQuantity, itemSO.MaxSpawnQuantity);
    }
}