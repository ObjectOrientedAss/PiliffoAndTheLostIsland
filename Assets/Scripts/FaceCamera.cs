using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = Quaternion.LookRotation(cam.transform.forward, Vector3.up);
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, rot.eulerAngles.y, transform.rotation.eulerAngles.z));
    }
}
