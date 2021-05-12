using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject SlotPrefab;
    public static UIInventorySlot CurrentEquippedItem;

    private List<UIInventorySlot> UIInventorySlots;

    private void Awake()
    {
        GameEventSystem.ChangeInventoryMaxSlotsEvent += ChangeMaxSlots;
        GameEventSystem.AddInventorySlotEvent += AddNewSlot;
        GameEventSystem.RemoveInventorySlotEvent += RemoveSlot;
        GameEventSystem.ChangeInventorySlotQuantityEvent += SetQuantity;
        GameEventSystem.CraftItemEvent += ChangeQuantity;
        GameEventSystem.CraftHatEvent += ChangeQuantity;

        UIInventorySlots = new List<UIInventorySlot>();
    }

    private void OnDestroy()
    {
        GameEventSystem.ChangeInventoryMaxSlotsEvent -= ChangeMaxSlots;
        GameEventSystem.AddInventorySlotEvent -= AddNewSlot;
        GameEventSystem.RemoveInventorySlotEvent -= RemoveSlot;
        GameEventSystem.ChangeInventorySlotQuantityEvent -= SetQuantity;
        GameEventSystem.CraftItemEvent -= ChangeQuantity;
        GameEventSystem.CraftHatEvent -= ChangeQuantity;
    }

    public void ChangeQuantity(string itemName, int quantity)
    {
        for (int i = 0; i < UIInventorySlots.Count; i++)
        {
            if (itemName.Equals(UIInventorySlots[i].SlotName))
            {
                UIInventorySlots[i].ChangeQuantity(-quantity);
            }
        }
    }

    public void ChangeMaxSlots(int slots)
    {
        int slotsToAdd = slots - transform.childCount;
        for (int i = 0; i < slotsToAdd; i++)
        {
            GameObject go = Instantiate(SlotPrefab, transform);
            UIInventorySlots.Add(go.GetComponent<UIInventorySlot>());
        }
    }

    public void AddNewSlot(Item item)
    {
        for (int i = 0; i < UIInventorySlots.Count; i++)
        {
            if (UIInventorySlots[i].IsEmpty)
            {
                UIInventorySlots[i].PopulateSlot(item);
                break;
            }
        }
    }

    public void SetQuantity(string itemName, int quantity)
    {
        for (int i = 0; i < UIInventorySlots.Count; i++)
        {
            if (itemName.Equals(UIInventorySlots[i].SlotName))
            {
                UIInventorySlots[i].SetQuantity(quantity);
            }
        }
    }

    public void RemoveSlot(string itemName)
    {
        for (int i = 0; i < UIInventorySlots.Count; i++)
        {
            if(itemName.Equals(UIInventorySlots[i].SlotName))
            {
                UIInventorySlots[i].ClearSlot();
                UIInventorySlots[i].transform.SetAsLastSibling();
                //honz cecio
                UIInventorySlot slot = UIInventorySlots[i];
                UIInventorySlots.RemoveAt(i);
                UIInventorySlots.Add(slot);
                break;
            }
        }
    }
}
