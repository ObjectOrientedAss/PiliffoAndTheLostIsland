using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour
{
    public bool Cosine;
    public float Amplitude;
    public float Frequency;
    public bool OnlyPositive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float delta =0;
        if(Cosine){
            delta = Amplitude*Mathf.Cos(Frequency*Time.time);
        }
        else
        {
            delta = Amplitude*Mathf.Sin(Frequency*Time.time);
        }

        if(OnlyPositive){
            delta = Mathf.Abs(delta);
        }
        transform.position =new Vector3(transform.position.x,delta,transform.position.z);
    }
}
