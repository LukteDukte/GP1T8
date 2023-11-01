using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0.2f; // Speed of rotation
    [SerializeField] private float movementSpeed = 1.1f; // Speed of vertical movement
    [SerializeField] private float maxRotationSpeed = 17.0f; // Maximum rotation speed
    [SerializeField] private float maxMovementSpeed = 0.1f; // Maximum vertical movement speed

    private Vector3 initialPosition;
    private float timeOffset;

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;

        // Set a random initial time offset to make each object's behavior unique
        timeOffset = Random.Range(0f, 360f);
    }

    void Update()
    {
        // Calculate the rotation angles for continuous rotation along two axes
        float rotationX = Mathf.Sin(Time.time * rotationSpeed + timeOffset) * maxRotationSpeed;
        float rotationY = Mathf.Cos(Time.time * rotationSpeed + timeOffset) * maxRotationSpeed;

        // Apply the rotations
        transform.Rotate(Vector3.right, rotationX * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationY * Time.deltaTime);

        // Move the object up and down
        float verticalMovement = Mathf.Sin(Time.time * movementSpeed + timeOffset) * maxMovementSpeed;
        transform.position = initialPosition + new Vector3(0, verticalMovement, 0);
    }
}
