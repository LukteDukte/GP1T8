using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSetter : MonoBehaviour
{
    [SerializeField] private float waitTime = 1.5f;
    [SerializeField] private float overallAnimationTime = 45f;

    private GlowToggle[] glows;
    private UIEmerge[] emerges;
    private bool shouldEnable = true;
    private void Awake()
    {
        glows = GetComponentsInChildren<GlowToggle>();
        emerges = GetComponentsInChildren<UIEmerge>();
        DisableObjects();
    }
    private void Update()
    {
        if (gameObject.activeSelf && shouldEnable)
        {
            StartCoroutine(EnableDisable());
        }
    }
    private IEnumerator EnableDisable()
    {
        yield return new WaitForSeconds(waitTime);
        EnableObjects();
        yield return new WaitForSeconds(overallAnimationTime);
        DisableObjects();
    }
    private void EnableObjects()
    {
        foreach (var g in glows)
        {
            g.gameObject.SetActive(true);
        }
        foreach (var e in emerges)
        {
            e.gameObject.SetActive(true);
        }
        shouldEnable = false;
    }

    private void DisableObjects()
    {
        foreach (var g in glows)
        {
            g.gameObject.SetActive(false);
        }
        foreach (var e in emerges)
        {
            e.gameObject.SetActive(false);
        }
        shouldEnable = true;
    }
}
