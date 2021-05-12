using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatScript : MonoBehaviour
{
    public GameObject NextPivot;
    public GameObject MyPivot;

    // Update is called once per frame
    void Update()
    {
        transform.position = MyPivot.transform.position;
        transform.rotation = MyPivot.transform.rotation;
    }
}
