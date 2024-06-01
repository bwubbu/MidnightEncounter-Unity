using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject FlashLightOnPlayer;
    public PlayerInventory playerInventory;

    void Start()
    {
        FlashLightOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickUpText.SetActive(false);
                this.gameObject.SetActive(false);

                if (playerInventory != null)
                {
                    playerInventory.AddItem(FlashLightOnPlayer);
                }
                else
                {
                    Debug.LogError("PlayerInventory is not assigned in the Inspector!");
                }
            }
        }
    }

    public bool PickedItem(string itemName)
    {
        if (FlashLightOnPlayer != null && FlashLightOnPlayer.name == itemName)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpText.SetActive(false);
        }
    }
}
