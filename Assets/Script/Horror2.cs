using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Horror2 : MonoBehaviour
{
    public GameObject glass1;
    public GameObject glass2;
    public GameObject glass3;
    public GameObject woman;

    public AudioClip scream;

    void Start()
    {
        GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = scream;
    }


    void OnTriggerEnter(Collider other)
    {
        
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            breakGlass();
            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }
            if (scream != null)
            {
                Invoke("StartScream", 2f);
                

            }
            else
            {
                // If the explosion sound or audioSource is missing, destroy immediately
                Destroy(gameObject);
            }

            
        }
    }
    void StartScream()
    {
        woman.SetActive(true);
        GetComponent<AudioSource> ().Play ();
        // Delay the destruction by the length of the sound clip
        Destroy(woman,scream.length+1f);
    }

    // void Start(){
    //     breakGlass();
    // }

    public void breakGlass()
    {
        // Check if the glass GameObject already has a Rigidbody component
        if (glass1.GetComponent<Rigidbody>() == null)
        {
            // Add a Rigidbody component to the glass GameObject
        Rigidbody rb1 = glass1.AddComponent<Rigidbody>();
        // Set the mass of the Rigidbody
        rb1.mass = 200;
        }
        else
        {
            // If a Rigidbody already exists, set its mass
            glass1.GetComponent<Rigidbody>().mass = 200;
        }
        // Check if the glass GameObject already has a Rigidbody component
        if (glass2.GetComponent<Rigidbody>() == null)
        {
            // Add a Rigidbody component to the glass GameObject
        Rigidbody rb2 = glass2.AddComponent<Rigidbody>();
        // Set the mass of the Rigidbody
        rb2.mass = 200;
        }
        else
        {
            // If a Rigidbody already exists, set its mass
            glass2.GetComponent<Rigidbody>().mass = 200;
        }
        // Check if the glass GameObject already has a Rigidbody component
        if (glass3.GetComponent<Rigidbody>() == null)
        {
            // Add a Rigidbody component to the glass GameObject
        Rigidbody rb3 = glass3.AddComponent<Rigidbody>();
        // Set the mass of the Rigidbody
        rb3.mass = 200;
        }
        else
        {
            // If a Rigidbody already exists, set its mass
            glass3.GetComponent<Rigidbody>().mass = 200;
        }

    }
}
