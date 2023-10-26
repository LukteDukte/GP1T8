using UnityEngine;

public class SFX_Volvox : MonoBehaviour
{
    [SerializeField] AudioSource volvoxSound;
    [SerializeField] Rigidbody rb;
    [SerializeField] float velocityToVolumeRatio;
    void Update()
    {
        volvoxSound.volume = rb.velocity.magnitude / velocityToVolumeRatio;
    }
}
