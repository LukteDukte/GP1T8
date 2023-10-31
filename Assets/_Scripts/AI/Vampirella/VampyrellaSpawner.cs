using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampyrellaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject vampyrellaPrefab;
    [SerializeField] private float vampyrellaSpawnInterval = 3f;

    // Minimum and maximum angles for controlling the direction
    [SerializeField] private float minAngle = 1f;
    [SerializeField] private float maxAngle = 169f;

    void Start()
    {
        StartCoroutine(spawnVampyrella(vampyrellaSpawnInterval, vampyrellaPrefab));
    }

    private IEnumerator spawnVampyrella(float interval, GameObject vampyrella)
    {
        yield return new WaitForSeconds(interval);

        // Calculate a random angle within the specified range
        float randomAngle = UnityEngine.Random.Range(minAngle, maxAngle);

        // Get the current rotation of the spawner
        Quaternion spawnerRotation = transform.rotation;

        // Apply the random angle to the spawner's rotation
        Quaternion rotation = Quaternion.Euler(0, randomAngle, 0);

        // Combine the spawner's rotation with the random rotation
        Quaternion finalRotation = spawnerRotation * rotation;

        // Instantiate the object with the final rotation
        GameObject newVampyrella = Instantiate(vampyrella, transform.position, finalRotation);
        newVampyrella.transform.SetParent(transform);
        newVampyrella.name = "Vampyrella";

        StartCoroutine(spawnVampyrella(interval, newVampyrella));
    }
}





/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampyrellaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject vampyrellaPrefab;
    [SerializeField] private float vampyrellaSpawnInterval = 3f;
    
    void Start()
    {
        StartCoroutine(spawnVampyrella(vampyrellaSpawnInterval, vampyrellaPrefab));
    }

    private IEnumerator spawnVampyrella(float interval, GameObject vampyrella)
    {
        yield return new WaitForSeconds(interval);
        GameObject newVampyrella = Instantiate(vampyrella, transform.position, Quaternion.identity);
        newVampyrella.transform.SetParent(transform);
        newVampyrella.name = "Vampyrella";
        newVampyrella.transform.rotation = Quaternion.Euler(0, UnityEngine.Random.Range(1, 179), 0);        //This is where to change or duplicate for enemies from other side.
        StartCoroutine(spawnVampyrella(interval, newVampyrella));

        // Debug.Log(newVampyrella.transform.rotation);
        // Debug.Log("Vampyrella Spawned!");
    }
}
*/
