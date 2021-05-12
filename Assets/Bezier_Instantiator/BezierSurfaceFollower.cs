using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierSurfaceFollower : MonoBehaviour
{
    [HideInInspector] public BezierSurfaceInstantiator script;
    [HideInInspector] public float MyU;
    [HideInInspector] public float MyV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = script.BezierSurface(MyU,MyV);
    }
}
