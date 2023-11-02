using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIEmerge : MonoBehaviour
{
    private SpriteRenderer renderer;
    private UIKeyFrame frameAnimation;
    [SerializeField] private bool canKeyFrame = false;
    [SerializeField] private float animationDelay = 0f;
    [SerializeField] private Vector3 yPos;
    [SerializeField] private float opaqueValue = 1f;
    [SerializeField] private float moveDuration;
    [SerializeField] private float colorDuration;
    [SerializeField] private Ease moveEase;
    [SerializeField] private Ease colorEase;
    [SerializeField] private float easeDuration;
    private void OnEnable()
    {
        renderer = GetComponent<SpriteRenderer>();
        frameAnimation = GetComponent<UIKeyFrame>();
        StartCoroutine(MoveUpwards());

    }
    public IEnumerator MoveUpwards()
    {
        yield return new WaitForSeconds(animationDelay);
        Color opaque = new Color(renderer.color.r, renderer.color.g, renderer.color.b, opaqueValue);
        transform.DOLocalMove(yPos, moveDuration).SetEase(moveEase, easeDuration);

        renderer.DOColor(opaque, colorDuration).SetEase(colorEase, easeDuration);

        //if (frameAnimation == null)
        //{

        //} else
        //{
        //    renderer.DOColor(opaque, colorDuration).SetEase(colorEase, easeDuration).OnComplete(() => frameAnimation.Work(canKeyFrame));
        //}
    }
}
