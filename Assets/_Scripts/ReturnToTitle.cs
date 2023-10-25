using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnToTitle : MonoBehaviour
{
    public SceneAsset titleScene;

    public void LoadTitle()
    {
        SceneManager.LoadScene(titleScene.name);
    }
}
