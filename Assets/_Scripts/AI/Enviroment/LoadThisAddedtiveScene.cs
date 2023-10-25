using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadThisAddedtiveScene : MonoBehaviour
{
    public SceneAsset sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
           SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
