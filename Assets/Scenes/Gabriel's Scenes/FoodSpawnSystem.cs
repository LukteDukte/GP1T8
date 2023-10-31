using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class FoodSpawnSystem : MonoBehaviour
{
    public GameObject[] foodPrefabs; // Array to store the food prefabs
    public List<Transform> spawnPoints = new List<Transform>();
    public int maxFoodInstances = 2;
    public int minFoodInstances = 1; // Minimum number of food instances
    public string foodTag = "Food"; // Tag assigned to food items
    public float spawnRadius = 1.0f; // Adjust this value as needed

    private List<GameObject> activeFoodInstances = new List<GameObject>();
    private List<Transform> shuffledSpawnPoints = new List<Transform>();
    private int currentSpawnPointIndex = 0;

    private void Awake()
    {
        // Find all predefined spawn points in the scene
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("SpawnPoint");
        foreach (GameObject spawnPoint in spawnPointObjects)
        {
            spawnPoints.Add(spawnPoint.transform);
        }

        // Shuffle the spawn points to randomize their order
        shuffledSpawnPoints = spawnPoints.OrderBy(x => Random.value).ToList();

        // Spawn initial food instances up to the minimum
        for (int i = 0; i < minFoodInstances; i++)
        {
            TrySpawnFood();
        }
    }

    private void Update()
    {
        // Spawn food to reach the minimum if needed
        while (activeFoodInstances.Count < minFoodInstances)
        {
            TrySpawnFood();
        }
    }

    private void TrySpawnFood()
    {
        if (activeFoodInstances.Count < maxFoodInstances)
        {
            if (currentSpawnPointIndex >= shuffledSpawnPoints.Count)
            {
                // If we've used all spawn points, shuffle again
                shuffledSpawnPoints = spawnPoints.OrderBy(x => Random.value).ToList();
                currentSpawnPointIndex = 0;
            }

            Transform spawnPoint = shuffledSpawnPoints[currentSpawnPointIndex];

            // Check for overlapping food items in the vicinity
            Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, spawnRadius);
            bool canSpawn = true;

            foreach (Collider col in colliders)
            {
                if (col.CompareTag(foodTag))
                {
                    canSpawn = false;
                    break;
                }
            }

            if (canSpawn)
            {
                // Generate a random index to select a prefab
                int randomPrefabIndex = Random.Range(0, foodPrefabs.Length);

                // Instantiate the selected prefab
                GameObject foodInstance = Instantiate(foodPrefabs[randomPrefabIndex], spawnPoint.position, Quaternion.identity);
                foodInstance.tag = foodTag; // Assign the foodTag to the new instance
                activeFoodInstances.Add(foodInstance);
            }

            currentSpawnPointIndex++;
        }

        //To set all food into the loaded scene.
        {
            // Find all GameObjects with the specified tag in all loaded scenes.
            GameObject[] objectsToMove = GameObject.FindGameObjectsWithTag("Food");

            // Get the current scene of the GameObject with this script.
            Scene currentScene = gameObject.scene;

            foreach (GameObject obj in objectsToMove)
            {
                // Get the scene of the object with the tag.
                Scene targetScene = obj.scene;

                // Check if the object is not in the same scene as the one with this script.
                if (targetScene != currentScene)
                {
                    // Move the object to the current scene.
                    SceneManager.MoveGameObjectToScene(obj, currentScene);
                }
            }
        }
    }

    public void FoodDestroyed(GameObject foodInstance)
    {
        activeFoodInstances.Remove(foodInstance);
        TrySpawnFood(); // Spawn a new food item when one is destroyed
        Debug.Log("fooddestroy triggered");
    }

    void OnDestroy()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Food");

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class FoodSpawnSystem : MonoBehaviour
{
    public GameObject foodPrefab;
    public List<Transform> spawnPoints = new List<Transform>();
    public int maxFoodInstances = 2;
    public int minFoodInstances = 1; // Minimum number of food instances
    public string foodTag = "Food"; // Tag assigned to food items
    public float spawnRadius = 1.0f; // Adjust this value as needed

    private List<GameObject> activeFoodInstances = new List<GameObject>();
    private List<Transform> shuffledSpawnPoints = new List<Transform>();
    private int currentSpawnPointIndex = 0;

    private void Awake()
    {
        // Find all predefined spawn points in the scene
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("SpawnPoint");
        foreach (GameObject spawnPoint in spawnPointObjects)
        {
            spawnPoints.Add(spawnPoint.transform);
        }

        // Shuffle the spawn points to randomize their order
        shuffledSpawnPoints = spawnPoints.OrderBy(x => Random.value).ToList();

        // Spawn initial food instances up to the minimum
        for (int i = 0; i < minFoodInstances; i++)
        {
            TrySpawnFood();
        }
    }

    private void Update()
    {
        // Spawn food to reach the minimum if needed
        while (activeFoodInstances.Count < minFoodInstances)
        {
            TrySpawnFood();
        }
    }

    private void TrySpawnFood()
    {
        if (activeFoodInstances.Count < maxFoodInstances)
        {
            if (currentSpawnPointIndex >= shuffledSpawnPoints.Count)
            {
                // If we've used all spawn points, shuffle again
                shuffledSpawnPoints = spawnPoints.OrderBy(x => Random.value).ToList();
                currentSpawnPointIndex = 0;
            }

            Transform spawnPoint = shuffledSpawnPoints[currentSpawnPointIndex];

            // Check for overlapping food items in the vicinity
            Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, spawnRadius);
            bool canSpawn = true;

            foreach (Collider col in colliders)
            {
                if (col.CompareTag(foodTag))
                {
                    canSpawn = false;
                    break;
                }
            }

            if (canSpawn)
            {
                GameObject foodInstance = Instantiate(foodPrefab, spawnPoint.position, Quaternion.identity);
                foodInstance.tag = foodTag; // Assign the foodTag to the new instance
                activeFoodInstances.Add(foodInstance);
            }

            currentSpawnPointIndex++;
        }



        //To set all food into the loaded scene.
        {
            // Find all GameObjects with the specified tag in all loaded scenes.
            GameObject[] objectsToMove = GameObject.FindGameObjectsWithTag("Food");

            // Get the current scene of the GameObject with this script.
            Scene currentScene = gameObject.scene;

            foreach (GameObject obj in objectsToMove)
            {
                // Get the scene of the object with the tag.
                Scene targetScene = obj.scene;

                // Check if the object is not in the same scene as the one with this script.
                if (targetScene != currentScene)
                {
                    // Move the object to the current scene.
                    SceneManager.MoveGameObjectToScene(obj, currentScene);
                }
            }
        }

   


    }




    public void FoodDestroyed(GameObject foodInstance)
    {
        activeFoodInstances.Remove(foodInstance);
        TrySpawnFood(); // Spawn a new food item when one is destroyed
        Debug.Log("fooddestroy triggered");
    }


    void OnDestroy()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Food");

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }

}

*/