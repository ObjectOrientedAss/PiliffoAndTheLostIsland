using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMessagePopup : MonoBehaviour
{
    bool canShow;
    private void Start()
    {
        canShow = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && canShow)
        {
            Debug.Log("sono in");
            canShow = false;
            List<string> messages = new List<string>();
            messages.Add("Collect the rock item with 'E'! Press 'C' to open the crafting menu, upgrade it and improve your stakeout! ");

            GameEventSystem.ShowDialogPopup(messages, "Got it");
        }
    }
}
