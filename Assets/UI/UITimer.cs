using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public float totalTime; // The total time for the timer
    private float currentTime; // The current time left
    public Image fillImage; // Reference to the UI image representing the timer

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            fillImage.fillAmount = currentTime / totalTime;
        }
        else
        {
            currentTime = 0;
        }
    }

    // You can add a method to reset the timer if needed
    public void ResetTimer()
    {
        currentTime = totalTime;
    }
}