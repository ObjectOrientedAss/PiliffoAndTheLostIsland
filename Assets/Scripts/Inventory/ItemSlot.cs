using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot
{
    public string ItemName;
    public int Quantity;
    public bool CanStack;
    public int MaxStack;
    public GameObject Prefab;

    public ItemSlot(string itemName, int quantity, bool canStack, int maxStack, GameObject prefab)
    {
        ItemName = itemName;
        Quantity = quantity;
        CanStack = canStack;
        MaxStack = maxStack;
        Prefab = prefab;
    }

    /// <summary>
    /// Adds the given quantity to the stack, if this slot can stack.
    /// </summary>
    /// <param name="quantity"></param>
    public bool Add(int quantity)
    {
        if(CanStack && Quantity < MaxStack)
        {
            Quantity += quantity;
            if (Quantity > MaxStack)
                Quantity = MaxStack;

            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns the REAL quantity removed. If you ask to remove 20 but you have 2, 2 will be returned.
    /// </summary>
    /// <param name="quantity"></param>
    /// <returns></returns>
    public int Remove(int quantity)
    {
        int remaining = Quantity - quantity;
        if(remaining >= 0)
        {
            Quantity -= quantity;
            return quantity;
        }
        else
        {
            quantity -= Mathf.Abs(remaining);
            Quantity -= quantity;
            return quantity;
        }
    }

    public void Clear()
    {
        ItemName = "";
        Quantity = 0;
        CanStack = false;
        MaxStack = 0;
        Prefab = null;
    }
}