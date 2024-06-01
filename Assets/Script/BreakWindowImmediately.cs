using UnityEngine;

public class BreakWindowImmediately : MonoBehaviour
{
    // Method to break the window immediately
    public void breaking()
    {
        // Check if the GameObject has a Rigidbody component
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply torque to the Rigidbody
            rb.AddTorque(Vector3.up * 100f, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("No Rigidbody attached to the object!");
        }
    }
}
