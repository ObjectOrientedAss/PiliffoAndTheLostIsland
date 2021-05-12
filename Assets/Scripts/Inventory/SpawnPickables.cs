using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickables : MonoBehaviour
{
    public GameObject[] PickablesPrefabs;

    public void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "Spawn Pickable"))
            SpawnPickable();
    }

    public void SpawnPickable()
    {
        int randomPickable = Random.Range(0, PickablesPrefabs.Length);
        GameObject pickable = Instantiate(PickablesPrefabs[randomPickable]);
        pickable.transform.position = transform.position;
        pickable.GetComponent<Pickable>().CreateItem();

        //ESEMPIO DI COME MOSTRARE UNA SERIE DI MESSAGGI POPUP A CATENA\\
        //CAMBIANO CLICCANDO SUL BOTTONE\\
        //List<string> messages = new List<string>();
        //messages.Add("mex 1");
        //messages.Add("mex 2");
        //messages.Add("mex 3");
        //GameEventSystem.ShowDialogPopup(messages, "Got it!");

        //ESEMPIO DI COME MOSTRARE UN MESSAGGIO POPUP A TEMPO\\
        //SI LEVA DA SOLO ALLO SCADERE\\
        //GameEventSystem.ShowFastPopup("Hai spawnato dei pickables!", 2f);
    }
}
