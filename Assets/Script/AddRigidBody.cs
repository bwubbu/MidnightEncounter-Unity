using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AddRigidBody : MonoBehaviour
{
    public GameObject glass;

    public void addRB()
    {
        // Check if the glass GameObject already has a Rigidbody component
        if (glass.GetComponent<Rigidbody>() == null)
        {
            // Add a Rigidbody component to the glass GameObject
            Rigidbody rb = glass.AddComponent<Rigidbody>();
            // Set the mass of the Rigidbody
            rb.mass = 200;
        }
        else
        {
            // If a Rigidbody already exists, set its mass
            glass.GetComponent<Rigidbody>().mass = 200;
        }
    }
}
