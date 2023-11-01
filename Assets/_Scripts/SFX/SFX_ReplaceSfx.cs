using UnityEngine;

public class SFX_ReplaceSfx : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [Range(0, 1)]
    [SerializeField] float volume;
    
    public void ReplaceSfx()
    {
        audioSource.volume = volume;
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
