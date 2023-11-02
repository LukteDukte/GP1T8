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
    private void OnDisable()
    {
        foreach (var renderer in renderers)
        {

            {
                renderer.sharedMaterial = standardMaterial;
            }

        }
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
            renderers[0].sharedMaterial = glowMaterial;
            renderers[1].sharedMaterial = glowMaterial;
            yield return new WaitForSeconds(.6f);

            for (int i = 2; i < renderers.Length; i++)
            {

                {
                    renderers[i].sharedMaterial = glowMaterial;
                }

            }

        }
    }
}
