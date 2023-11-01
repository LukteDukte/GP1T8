using UnityEngine;

public class SFX_PlayItOnce : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [Range(0, 1)]
    [SerializeField] float volume;
    
    public void PlayItOnce()
    {
        audioSource.volume = volume;
        audioSource.PlayOneShot(audioClip);
    }
}
