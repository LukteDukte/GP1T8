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
    // Sorry Elliott! I had to change this to a string. Otherwise we couldn't create a build of the game.
}
