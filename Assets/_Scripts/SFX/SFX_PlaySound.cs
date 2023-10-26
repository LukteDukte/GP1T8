using UnityEngine;

public class SFX_PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClips;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(audioClips);
    }
}
