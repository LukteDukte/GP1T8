using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIKeyFrame : MonoBehaviour
{

    [SerializeField] private float animationDelay = 0f;

    [SerializeField] private string actionToConnect;

    [SerializeField] private Sprite newSprite;

    [SerializeField] private int numberOfCycles = 3;
    [SerializeField] private float backDelay = 2f;
    private Sprite standardSprite;
    private SpriteRenderer renderer;
    private bool isPerformed = false;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        standardSprite = renderer.sprite;
    }
    private void OnEnable()
    {
        Work(true);
    }
    public void Work(bool canAnimate)
    {
        if (canAnimate)
        {
            StopCoroutine(ChangeSprite());
            StartCoroutine(ChangeSprite());
        } else
        {
            StopCoroutine(ChangeSprite());
            renderer.sprite = standardSprite;

        }
    }
    public IEnumerator ChangeSprite()
    {
       for (int i = 0; i < numberOfCycles; i++)
        {
            yield return new WaitForSeconds(animationDelay);
            renderer.sprite = newSprite;
            yield return new WaitForSeconds(backDelay);
            renderer.sprite = standardSprite;
        }
        
    }
}
