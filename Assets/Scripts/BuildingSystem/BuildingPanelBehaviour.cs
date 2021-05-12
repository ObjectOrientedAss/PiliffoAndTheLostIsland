using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingPanelBehaviour : MonoBehaviour
{
    public Building CurrentBuilding;
    public GameObject RequirementItemPrefab;
    public Transform RequirementsPanel;
    public TextMeshProUGUI BuildingName;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CurrentBuilding = null;
        for (int i = RequirementsPanel.childCount - 1; i >= 0; i--)
        {
            Destroy(RequirementsPanel.GetChild(i).gameObject);
        }
    }

    private void OnEnable()
    {
        if (CurrentBuilding.CurrentBuildingStep >= 0)
            BuildingName.text = CurrentBuilding.BuildingSO.Name + " Level " + (CurrentBuilding.CurrentBuildingStep + 2).ToString();

        for (int i = 0; i < CurrentBuilding.BuildingStep.Requirements.Length; i++)
        {
            GameObject go = Instantiate(RequirementItemPrefab, RequirementsPanel);
            RequirementUI requirementUI = go.GetComponent<RequirementUI>();
            requirementUI.Name.text = CurrentBuilding.BuildingStep.Requirements[i].ItemType.ToString();
            requirementUI.Needed.text = CurrentBuilding.BuildingStep.Requirements[i].Quantity.ToString();
            requirementUI.Given.text = CurrentBuilding.BuildingStep.Requirements[i].GivenQuantity.ToString();
            requirementUI.OwnerBuilding = CurrentBuilding;
        }
    }

    public void CloseButtonClick()
    {
        CurrentBuilding.InterruptInteraction();
    }
}
