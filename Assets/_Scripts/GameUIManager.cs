using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    //[SerializeField] TMP_Text UIScoreText;
    [SerializeField] TMP_Text UIHighscoreText;
    [SerializeField] HighscoreData highscoreData;
    private UnityEvent noNewHighscore;
    private UnityEvent NewHighscore;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        //UpdateUIScore();

        //Adds noNew & New Highscore as a listener to onTimerEnd
        noNewHighscore = Highscore.Instance.noNewHighscore;
        NewHighscore = Highscore.Instance.newHighscore;

        noNewHighscore.AddListener(DisplayNoNewHighscore);
        NewHighscore.AddListener(DisplayNewHighscore);
    }

    public void UpdateUIScore()
    {
        //UIScoreText.text = Volvox.Instance.colonyCenter.childCount.ToString();
    }

    private void DisplayNoNewHighscore()
    {
        UIHighscoreText.text = "HIGH SCORE: " + highscoreData.highscore.ToString();

        //print(GameObject.FindFirstObjectByType<Button>().gameObject.name);

        //GameObject.FindFirstObjectByType<Button>().gameObject.SetActive(true);

        StartCoroutine(ReturnToTitle(6));
    }
    private void DisplayNewHighscore()
    {
        UIHighscoreText.text = "NEW HIGH SCORE: " + highscoreData.highscore.ToString();

        //GameObject.FindFirstObjectByType<Button>().gameObject.SetActive(true);
        StartCoroutine(ReturnToTitle(6));
    }

    private IEnumerator ReturnToTitle(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        
        GetComponent<ReturnToTitle>().LoadTitle();
    }
}
