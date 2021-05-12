using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineXZ : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 initialPosition;
    void Start()
    {
       initialPosition =  transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, initialPosition.z + 5*Mathf.Sin(3*Time.time)); 
    }
}
