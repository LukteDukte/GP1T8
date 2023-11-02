using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;
    [SerializeField] GameObject deathCamera;
    [SerializeField] TMP_Text UIScoreText;
    [SerializeField] TMP_Text UIHighscoreText;
    [SerializeField] HighscoreData highscoreData;
    [SerializeField] public TMP_Text title;
    private UnityEvent noNewHighscore;
    private UnityEvent NewHighscore;

    public GameObject timer;

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
        UpdateUIScore();

        //Adds noNew & New Highscore as a listener to onTimerEnd
        noNewHighscore = Highscore.Instance.noNewHighscore;
        NewHighscore = Highscore.Instance.newHighscore;

        noNewHighscore.AddListener(DisplayNoNewHighscore);
        NewHighscore.AddListener(DisplayNewHighscore);
    }

    private void Update()
    {
        UpdateUIScore();
    }

    public void UpdateUIScore()
    {
        UIScoreText.text = "Score:" + Volvox.Instance.colonyCenter.childCount.ToString();
    }

    private void DisplayNoNewHighscore()
    {
        deathCamera.SetActive(true);

        UIHighscoreText.text = "YOUR SCORE: " + highscoreData.highscore.ToString();

        //print(GameObject.FindFirstObjectByType<Button>().gameObject.name);

        //GameObject.FindFirstObjectByType<Button>().gameObject.SetActive(true);

        StartCoroutine(ReturnToTitle(10));
    }
    private void DisplayNewHighscore()
    {
        deathCamera.SetActive(true);

        UIHighscoreText.text = "NEW HIGH SCORE: " + highscoreData.highscore.ToString();

        //GameObject.FindFirstObjectByType<Button>().gameObject.SetActive(true);
        StartCoroutine(ReturnToTitle(10));
    }

    private IEnumerator ReturnToTitle(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        
        GetComponent<ReturnToTitle>().LoadTitle();
    }
    
    public void startUITimer()
    {
        timer.SetActive(true);
    }
}
