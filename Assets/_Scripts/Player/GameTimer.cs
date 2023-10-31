using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;
    #region Config
    [Header("GameTime Settings")] public float lifeTimer;
    [SerializeField] Color targetColor;
    [SerializeField] Color targetEmissionColor;
    [SerializeField] Renderer materialToChange;

    [Header("Event")] public UnityEvent onTimerEnd;

    Renderer _materialToChange;
    public float maxLifeTimer;
    Color _initialColor;
    Color _initialEmissionColor;

    #endregion

    private void Awake()
    {
        _initialEmissionColor = materialToChange.material.GetColor("_EmissionColor");
        _initialColor = materialToChange.material.color;
        maxLifeTimer = lifeTimer;
        
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        if (LoadThisAddedtiveScene.Instance.isCountingDown)
        {
            lifeTimer -= Time.fixedDeltaTime;
        }

        LifeChecker();
        ColorTransition();
    }

    void LifeChecker()
    {
        if (lifeTimer <= 0)
        {
            Debug.Log("Volvox lifespan ended. Aka Game Over");
            onTimerEnd.Invoke();
            enabled = false;
        }
    }

    void ColorTransition()
    {
        float lerpValue = 1 - (lifeTimer / maxLifeTimer);
        Color newEmissionColor = Color.Lerp(_initialEmissionColor, targetEmissionColor, lerpValue);
        materialToChange.material.color = Color.Lerp(_initialColor, targetColor, lerpValue);
        // Debug.Log("Lerp value: " + lerpValue);
        materialToChange.material.SetColor("_EmissionColor", newEmissionColor);
    }

    
}