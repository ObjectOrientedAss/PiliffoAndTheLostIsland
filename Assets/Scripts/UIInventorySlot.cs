using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventorySlot : MonoBehaviour
{
    public Image Image;
    public TextMeshProUGUI Name, Quantity;

    [HideInInspector]
    public string SlotName { get { return Name.text; } }
    [HideInInspector]
    public bool IsEmpty;
    public Button EquipButton;
    [HideInInspector]
    public int quantity { get { return int.Parse(Quantity.text); } }

    private bool isEquippable;

    //details
    public GameObject DetailsPanel;
    public TextMeshProUGUI Description;
    public TMP_InputField NumOfSelectionItemText;

    private void Awake()
    {
        IsEmpty = true;
    }

    public void PopulateSlot(Item item)
    {
        Image.enabled = true;
        Image.sprite = item.UIRepresentation;
        Name.text = item.Name;
        Quantity.text = item.Quantity.ToString();
        Description.text = item.Description;
        NumOfSelectionItemText.Select();
        isEquippable = item.IsEquippable;
        IsEmpty = false;
    }

    public void Unequip()
    {
        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(EquipItem);
        EquipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip Item";
        GameEventSystem.UnequipItem();
    }

    public void ClearSlot()
    {
        Image.sprite = null;
        Image.enabled = false;
        Name.text = "";
        Quantity.text = "";
        Description.text = "";
        NumOfSelectionItemText.Select();
        DetailsPanel.SetActive(false);
        IsEmpty = true;
    }

    public void SetQuantity(int quantity)
    {
        Quantity.text = quantity.ToString();
    }

    public void ChangeQuantity(int quantity)
    {
        int numOfItem = this.quantity + quantity;
        Quantity.text = numOfItem.ToString();
    }

    public void OpenSlotDetails()
    {
        if (isEquippable)
            EquipButton.gameObject.SetActive(true);
        else
            EquipButton.gameObject.SetActive(false);

        if (!IsEmpty)
            DetailsPanel.SetActive(!DetailsPanel.activeSelf);

        NumOfSelectionItemText.text = "";
        NumOfSelectionItemText.Select();
    }

    public void DropItemButton()
    {
        GameEventSystem.DropInventoryItem(SlotName, int.Parse(NumOfSelectionItemText.text));
        OpenSlotDetails();
    }

    public void EquipItem()
    {
        if (InventoryUIManager.CurrentEquippedItem != null)
            InventoryUIManager.CurrentEquippedItem.Unequip();

        EquipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unequip Item";
        EquipButton.onClick.RemoveAllListeners();
        EquipButton.onClick.AddListener(Unequip);
        GameEventSystem.EquipItem(SlotName);
        InventoryUIManager.CurrentEquippedItem = this;
    }
}
