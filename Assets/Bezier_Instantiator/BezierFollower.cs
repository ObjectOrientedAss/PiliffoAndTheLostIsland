using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollower : MonoBehaviour
{
    [HideInInspector] public BezierInstantiator script;
    [HideInInspector] public float MyT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = script.BezierCurve(MyT);
    }
}
