using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSceneChanger : MonoBehaviour
{
    [SerializeField] string gameScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameScene);
    }
}
