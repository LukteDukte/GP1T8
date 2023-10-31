using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string gameScene;
    PlayerInputActions playerInputActions;
    public IEnumerator LoadGame()
    {
        Debug.Log("Loading");

        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(gameScene);
    }

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }
    private void Update()
    {
        if (playerInputActions.Player.dpadDownLeft.IsPressed()  || 
            playerInputActions.Player.dpadUpLeft.IsPressed()    || 
            playerInputActions.Player.dpadDownRight.IsPressed() ||
            playerInputActions.Player.dpadUpRight.IsPressed()   )
        {
            StartCoroutine( LoadGame() );
        }
    }
}
