using UnityEngine;

public class CameraLock : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isLocked = false;

    // Property to check if the camera is locked
    public bool IsCameraLocked()
    {
        return isLocked;
    }

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        if (isLocked)
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }
    }

    public void LockCamera(bool lockState)
    {
        if (lockState)
        {
            initialPosition = transform.position;
            initialRotation = transform.rotation;
        }
        isLocked = lockState;
    }
}
