using System.Collections;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;
    public float flickerSpeed = 1f;

    private Light pointLight;

    void Start()
    {
        pointLight = GetComponent<Light>();
        // Start the flickering coroutine
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            // Randomize intensity within the specified range
            float intensity = Random.Range(minIntensity, maxIntensity);
            // Apply the intensity to the light
            pointLight.intensity = intensity;
            // Wait for a short duration before changing intensity again
            yield return new WaitForSeconds(1 / flickerSpeed);
        }
    }
}

