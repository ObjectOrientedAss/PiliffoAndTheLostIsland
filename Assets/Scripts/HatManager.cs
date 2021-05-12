using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentHatPivot;
    public List<GameObject> HatPrefabs;
    public static HatManager Instance;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        currentHatPivot = gameObject;   
    }

    public void AddHat()
    {
        GameObject go = Instantiate(HatPrefabs[Random.Range(0,HatPrefabs.Count)]);
        go.GetComponent<HatScript>().MyPivot = currentHatPivot;
        currentHatPivot = go.GetComponent<HatScript>().NextPivot;
    }
 
}
