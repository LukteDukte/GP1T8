using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoFloat : MonoBehaviour
{
    [Header("Floating Parameters")]
    public float floatAmplitude = 0.5f; // Adjust this to control the amplitude of the floating motion.
    public float floatFrequency = 1.0f; // Adjust this to control the frequency of the floating motion.

    private Vector3 initialPosition;
    private float timeOffset;

    void Start()
    {
        initialPosition = transform.position;
        timeOffset = Random.Range(0f, 360f); // Randomize the starting phase of the floating motion.
    }

    void Update()
    {
        // Calculate the new Y position based on time and the floating parameters.
        float newY = initialPosition.y + floatAmplitude * Mathf.Sin(floatFrequency * (Time.time + timeOffset));

        // Update the object's position.
        Vector3 newPosition = new Vector3(initialPosition.x, newY, initialPosition.z);
        transform.position = newPosition;
    }
}