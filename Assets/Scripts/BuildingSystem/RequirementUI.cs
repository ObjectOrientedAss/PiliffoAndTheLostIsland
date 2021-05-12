using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequirementUI : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Needed;
    public TextMeshProUGUI Given;
    public TMP_InputField Quantity;
    public Button ButtonAdd;
    [HideInInspector] public Building OwnerBuilding;

    private void Start()
    {
        int needed = int.Parse(Needed.text);
        int given = int.Parse(Given.text);
        int remaining = needed - given;

        if (remaining <= 0)
            Destroy(ButtonAdd.gameObject);
    }

    public void AddClick()
    {
        if(Quantity.text == "")
            return;

        int quantity = int.Parse(Quantity.text);

        if (quantity < 0)
        {
            Quantity.text = "0";
            return;
        }

        int needed = int.Parse(Needed.text);
        int given = int.Parse(Given.text);
        int remaining = needed - given;

        if (quantity > remaining)
            quantity = remaining;

        GameEventSystem.GiveMaterialEvent += GiveMaterialEvent; //register here to get response
        GameEventSystem.TryGiveMaterialToBuild(Name.text, quantity); //<- give material triggered here
        Quantity.text = "";
        GameEventSystem.GiveMaterialEvent -= GiveMaterialEvent; //unregister here after response
    }

    private void GiveMaterialEvent(int quantity)
    {
        int needed = int.Parse(Needed.text);
        int given = int.Parse(Given.text);
        int remaining = needed - given;

        given += quantity;
        Given.text = given.ToString();

        if (remaining <= 0)
            Destroy(ButtonAdd.gameObject);

        OwnerBuilding.RefreshStep(transform.GetSiblingIndex(), given);
    }
}
