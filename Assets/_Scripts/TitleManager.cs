using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] string gameScene;

    public void LoadGame()
    {
        SceneManager.LoadScene(gameScene);
    }
}
