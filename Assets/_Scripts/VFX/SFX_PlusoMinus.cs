using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_PlusoMinus : MonoBehaviour
{
    [SerializeField] private float timerDuration;
    
    private bool _timer;

    // Update is called once per frame
    void Update()
    {
        if (_timer)
        {
            timerDuration -= Time.deltaTime;
            if (timerDuration <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnEnable()
    {
        _timer = true;
    }
}
