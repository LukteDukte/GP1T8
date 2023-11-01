using System;
using UnityEngine;

[Serializable]
class SFX_AudioClips
{
    public AudioClip Clip;
    [Range(0, 1)]
    public float Volume;
}

public class SFX_Light : MonoBehaviour
{
    [SerializeField] AudioSource lightActivates;
    [SerializeField] AudioSource lightHums;
    [SerializeField] SFX_AudioClips[] audioClips2;
    
    [SerializeField] LightPositionSlider _lightPositionSlider;
    bool _isOn, _isRight;
    
    // Start is called before the first frame update
    void Start()
    {
        _isRight = _lightPositionSlider.placeItRight;
    }

    // Update is called once per frame

    private void OnEnable()
    {
        lightActivates.volume = _isRight ? audioClips2[5].Volume : audioClips2[2].Volume;
        lightActivates.PlayOneShot(_isRight ? audioClips2[5].Clip : audioClips2[2].Clip);
        
        lightHums.volume = _isRight ? audioClips2[3].Volume : audioClips2[0].Volume;
        lightHums.clip = _isRight ? audioClips2[3].Clip : audioClips2[0].Clip;
        lightHums.Play();
    }

    private void OnDisable()
    {
        lightActivates.volume = _isRight ? audioClips2[4].Volume : audioClips2[1].Volume;
        lightActivates.PlayOneShot(_isRight ? audioClips2[4].Clip : audioClips2[1].Clip);
        lightHums.Stop();
    }

}
