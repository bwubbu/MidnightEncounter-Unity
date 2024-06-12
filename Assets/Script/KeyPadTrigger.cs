using UnityEngine;

public class KeyPadTrigger : MonoBehaviour
{
    public GameObject KeyPadKontrol;
    public GameObject Camera;
    private bool isPlayerInTrigger = false;
    private CameraLock cameraLock;
    public GameObject Interaction;

    void Start()
    {
        cameraLock = Camera.GetComponent<CameraLock>();
        Interaction.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Inside");
            isPlayerInTrigger = true;
            Interaction.SetActive(true); // Activate InteractText when player enters the trigger
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            Interaction.SetActive(false); // Deactivate InteractText when player exits the trigger
            
            if (cameraLock != null)
            {
                cameraLock.LockCamera(false); // Disable camera lock when player exits
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        // Update camera lock and cursor visibility based on player input
        if (isPlayerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Clicked door out");
                if (cameraLock != null)
                {
                    cameraLock.LockCamera(true); // Enable camera lock when 'E' is pressed
                }
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                KeyPadKontrol.SetActive(true);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (cameraLock != null)
            {
                cameraLock.LockCamera(false); // Disable camera lock when 'Escape' is pressed
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            KeyPadKontrol.SetActive(false);
        }
    }
}
