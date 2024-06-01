using UnityEngine;

public class Flashlight : MonoBehaviour, IPickable
{
    public GameObject FlashLightOnPlayer;

    public void OnPickUp(PlayerInventory playerInventory)
    {
        FlashLightOnPlayer.SetActive(true);
        gameObject.SetActive(false);
    }
}
