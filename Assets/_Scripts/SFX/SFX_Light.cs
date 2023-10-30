using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SFX_Light : MonoBehaviour
{
    [SerializeField] AudioSource lightActivates;
    [SerializeField] AudioSource lightHums;
    [SerializeField] AudioClip[] audioClips;
    
    [SerializeField] LightPositionSlider lightPositionSlider;
    
    
    bool _isOn, _isRight;
    
    // Start is called before the first frame update
    void Start()
    {
        _isRight = lightPositionSlider.placeItRight;
    }

    // Update is called once per frame

    private void OnEnable()
    {
        lightActivates.PlayOneShot(_isRight ? audioClips[5] : audioClips[2]); // Play the sound of the light turning on
        lightHums.clip = _isRight ? audioClips[3] : audioClips[0];
        lightHums.Play();
    }

    private void OnDisable()
    {
        lightActivates.PlayOneShot(_isRight ? audioClips[4] : audioClips[1]);
        lightHums.Stop();
    }

}
