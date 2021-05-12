using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public GameObject BuildingPanel; //<- set in inspector
    public GameObject PausePanel; //<- set in inspector
    public GameObject CraftingPanel; //<- set in inspector

    public GameObject PopupPrefab;

    private void Awake()
    {
        //this little trick activates the panels, and in their awake they automatically go back unactive
        BuildingPanel.SetActive(true);
        PausePanel.SetActive(true);
        CraftingPanel.SetActive(true);
        //so we can get the references at start without having to keep panels open in edit mode.

        GameEventSystem.TogglePauseUIEvent += TogglePausePanel;
        GameEventSystem.ToggleBuildingUIEvent += ToggleBuildingPanel;
        GameEventSystem.ToggleCraftingUIEvent += ToggleCraftingPanel;

        GameEventSystem.ShowFastPopupEvent += ShowPopup;
        GameEventSystem.ShowDialogPopupEvent += ShowPopup;
    }

    private void OnDestroy()
    {
        GameEventSystem.TogglePauseUIEvent -= TogglePausePanel;
        GameEventSystem.ToggleBuildingUIEvent -= ToggleBuildingPanel;
        GameEventSystem.ToggleCraftingUIEvent -= ToggleCraftingPanel;

        GameEventSystem.ShowFastPopupEvent -= ShowPopup;
        GameEventSystem.ShowDialogPopupEvent -= ShowPopup;
    }

    private void ToggleBuildingPanel(bool activeStatus, Building building)
    {
        BuildingPanel.GetComponent<BuildingPanelBehaviour>().CurrentBuilding = building;
        BuildingPanel.SetActive(activeStatus);
    }

    private void ToggleCraftingPanel(bool activeStatus)
    {
        CraftingPanel.SetActive(activeStatus);
    }

    private void TogglePausePanel(bool activeStatus)
    {
        PausePanel.SetActive(activeStatus);
    }

    private void ShowPopup(string message, float time)
    {
        GameObject go = Instantiate(PopupPrefab, transform);
        PopupBehaviour script = go.GetComponent<PopupBehaviour>();
        script.Init(message, time);
    }

    private void ShowPopup(List<string> messages, string buttonText)
    {
        GameObject go = Instantiate(PopupPrefab, transform);
        PopupBehaviour script = go.GetComponent<PopupBehaviour>();
        script.Init(messages, buttonText);
    }
}