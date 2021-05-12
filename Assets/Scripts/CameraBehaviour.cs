using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [HideInInspector] public InputHandler InputHandler;
    private Transform target;
    public Transform Camera;
    public Vector3 CameraForward { get { return (new Vector3(Camera.position.x, 0, Camera.position.z) - new Vector3(target.position.x, 0, target.position.z)).normalized; } }

    public float OrbitalRotationSpeed;
    public float FollowMovementSpeed;

    public void Init(Transform target)
    {
        this.target = target;
        enabled = true;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, FollowMovementSpeed * Time.deltaTime);

        if (InputHandler.cameraHorizontal != 0)
        {
            if (InputHandler.currentControlScheme == ControlScheme.KeyboardAndMouse)
            {
                if (InputHandler.cameraLockButtonPressed)
                {
                    transform.rotation *= Quaternion.Euler(Vector3.up * InputHandler.cameraHorizontal * OrbitalRotationSpeed * Time.deltaTime);
                }
            }
            else
            {
                transform.rotation *= Quaternion.Euler(Vector3.up * InputHandler.cameraHorizontal * OrbitalRotationSpeed * Time.deltaTime);
            }
        }
    }
}
