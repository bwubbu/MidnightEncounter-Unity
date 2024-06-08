using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlashLight : MonoBehaviour
{
    public GameObject canvas; // Reference to the canvas GameObject
    public GameObject flashLight; // Array to hold references to heart GameObjects
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))

            if (Input.GetKeyDown(KeyCode.F))
            {
                flashLight.SetActive(true);
            }
        }
    }

