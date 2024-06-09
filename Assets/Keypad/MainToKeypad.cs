using UnityEngine;

public class MainToKeypad : MonoBehaviour
{
    public Camera mainCamera;
    public Camera keypadCamera;

    private bool isZoomedIn = false;

    void Start()
    {
        mainCamera.enabled = true;
        keypadCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleCamera();
        }

    }

    void ToggleCamera()
    {
        isZoomedIn = !isZoomedIn;

        mainCamera.enabled = !isZoomedIn;
        keypadCamera.enabled = isZoomedIn;
    }
}