using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpotHint : MonoBehaviour
{
    public Camera Camera;

    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void Update()
    {
        transform.forward = -Camera.transform.forward;
    }
}
