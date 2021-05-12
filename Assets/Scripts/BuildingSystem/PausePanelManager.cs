using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelManager : MonoBehaviour
{
    private Stack<GameObject> openedMenus;
    public GameObject PauseMainPanel; //<- set in inspector
    public GameObject PauseOptionsPanel; //<- set in inspector

    private void Awake()
    {
        openedMenus = new Stack<GameObject>();
        //register to events!
        //Pause or Interrupt buttons pressed -> previous screen / quit pause
        GameEventSystem.TryInterruptPauseEvent += Back;

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameEventSystem.TryInterruptPauseEvent -= Back;
    }

    private void OnEnable()
    {
        PauseMainPanel.SetActive(true);
        openedMenus.Push(PauseMainPanel);
    }

    private void OnDisable()
    {
        openedMenus.Clear();
    }

    public void Back()
    {
        //se lo stack dei menu aperti è 1, siamo nel pause menu principale, quindi fine pausa
        if (openedMenus.Count == 1)
        {
            GameEventSystem.TogglePauseUI(false);
            return;
        }

        //altrimenti andiamo indietro
        openedMenus.Pop().SetActive(false);
        openedMenus.Peek().SetActive(true);
    }

    public void OnResumeButtonClick()
    {
        GameEventSystem.TogglePauseUI(false);
    }

    public void OnQuitClick()
    {
        Application.Quit(); //così de botto senza senso
    }

    public void OnMainMenuClick()
    {
        //caricare scena main menu.
    }

    public void NavigateMenu(GameObject newPanel)
    {
        openedMenus.Peek().SetActive(false);
        newPanel.SetActive(true);
        openedMenus.Push(newPanel);
    }
}
