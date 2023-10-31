using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class SFX_AudioClips
{
    public AudioClip Clip;
    [Range(0, 1)]
    public float Volume;
}



public class SFX_Light : MonoBehaviour
{
    [SerializeField] AudioSource lightActivates;
    [SerializeField] AudioSource lightHums;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] SFX_AudioClips[] audioClips2;
    
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
        //lightActivates.PlayOneShot(_isRight ? audioClips[5] : audioClips[2]); // Play the sound of the light turning on
        lightActivates.PlayOneShot(_isRight ? audioClips2[5].Clip : audioClips2[2].Clip);
        //lightHums.clip = _isRight ? audioClips[3] : audioClips[0];
        lightHums.clip = _isRight ? audioClips2[3].Clip : audioClips2[0].Clip;
        lightHums.Play();
    }

    private void OnDisable()
    {
        //lightActivates.PlayOneShot(_isRight ? audioClips[4] : audioClips[1]);
        lightActivates.PlayOneShot(_isRight ? audioClips2[4].Clip : audioClips2[1].Clip);
        lightHums.Stop();
    }

}
