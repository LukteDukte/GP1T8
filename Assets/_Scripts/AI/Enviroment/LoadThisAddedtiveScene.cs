using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LoadThisAddedtiveScene : MonoBehaviour
{
    // public string sceneToLoad;

    public static LoadThisAddedtiveScene Instance;

    public GameObject[] stages;

    public int[] colonyRequiredToTheNextLevel;
    
    private int currentLevel = 1;
    public int indexOfSceneToLoad;
    public int maxLevel = 5;
    public bool isCountingDown = false;

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    } // Start is called before the first frame update

    void Start()
    {
        // SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
        StartCoroutine(WaitToSelectSceneToAdd(indexOfSceneToLoad));
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel == 2)
        {
            isCountingDown = true;
            GameUIManager.Instance.startUITimer();
        }
    }

    IEnumerator WaitToSelectSceneToAdd(int i)
    {
        yield return new WaitForSeconds(2);
        GameUIManager.Instance.title.enabled = false;
        yield return new WaitForSeconds(1);
        LoadLevel(i);
    }

    public void LoadNextLevel()
    {
        print(currentLevel + "level  is unloaded");
        if (currentLevel == maxLevel) return;

        UnloadLevel(currentLevel);


        currentLevel++;
        print(currentLevel + "level  is loaded");
        LoadLevel(currentLevel);
    }

    void LoadLevel(int index)
    {
        foreach (GameObject stage in stages)
        {
            stage.SetActive(false);
        }
        stages[index].SetActive(true);
        string nextSceneName = "Level" + index;
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
    }
    
    void UnloadLevel(int index)
    {
        stages[index].SetActive(false);
        string currentSceneName = "Level" + index;
        SceneManager.UnloadSceneAsync(currentSceneName);
    }
    
    public bool IfReachRequiredAmount(int amount)
    {
        int RequiredAmount = colonyRequiredToTheNextLevel[currentLevel];
        return amount >= RequiredAmount;
    }
}