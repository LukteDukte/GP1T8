using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowToggle : MonoBehaviour
{
    [SerializeField] private float animationDelay = 0f;

    [SerializeField] private Material standardMaterial;
    [SerializeField] private Material glowMaterial;
    [SerializeField] private SpriteRenderer[] renderers;
    [SerializeField] private bool isGlowing = false;

    private void OnEnable()
    {
        StartCoroutine(ToggleGlow());
    }


    public IEnumerator ToggleGlow()
    {
        yield return new WaitForSeconds(animationDelay);
        if (!isGlowing)
        {
            foreach (var renderer in renderers)
            {

                {
                    renderer.sharedMaterial = standardMaterial;
                }

            }
        }
        else
        {
            foreach (var renderer in renderers)
            {

                {
                    renderer.sharedMaterial = glowMaterial;
                }

            }

        }
    }
}
