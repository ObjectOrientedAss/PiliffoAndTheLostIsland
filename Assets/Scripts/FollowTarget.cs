using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform Target;
    Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Target.position.x, transform.position.y, Target.position.z);
    }
}
