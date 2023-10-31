using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotiferSpawner : MonoBehaviour
{
    public bool isForTesting = false;

    [Header("Bubble")] public float bubbleInterval = 2f;
    public ParticleSystem bubble;

    [Header("Whirlpool")] public GameObject whirlpoolPrefab;
    public Whirlpool whirlpool;

    public float stayInterval = 3f;
    public float disappearInterval = 2f;

    [Header("Rotifer")] public GameObject rotiferPrefab;
    public Rotifer rotifer;
    public Transform spawnPoint;

    public float spawnPointDepth = -5;
    public float jumpHeightEnd = 3f;
    public float appearInterval = 4f;
    public float attackInterval = 1;
    public float retreatInterval = 1;


    // Start is called before the first frame update

    private void OnDrawGizmos()
    {
        spawnPoint.localPosition = new Vector3(0, spawnPointDepth, 0);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(spawnPoint.position, transform.position + new Vector3(0, jumpHeightEnd, 0));
    }

    void Start()
    {
    }

    private void OnEnable()
    {
        if (isForTesting)
        {
            StartCoroutine(Staying());
        }
        else
        {
            StartCoroutine(Waiting());
        }
    }


    // Update is called once per frame
    void Update()
    {
        // whirlpoolPrefab.transform.position = PlayerManager.Instance.RandomPointWithinProjectedRange();
    }

    IEnumerator Staying()
    {
        // Debug.Log("Hello" + PlayerManager.Instance.RandomPointWithinProjectedRange());
        transform.position = PlayerManager.Instance.RandomPointWithinProjectedRange();
        whirlpool.play = true;
        whirlpool.isSucking = true;
        rotifer.ClearMouth();

        rotifer.rotiferAnimator.SetTrigger("Idle");
        float timePassed = 0;
        while (timePassed < stayInterval)
        {
            timePassed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            if (whirlpool.IsInDeadZone())
            {
                Debug.Log("ready to eat");
                StartCoroutine(Eating());
                yield break;
            }
        }

        whirlpool.isSucking = false;
        whirlpool.play = false;
        Debug.Log("Stop Playing");
        yield return new WaitForSeconds(disappearInterval);
        StartCoroutine(Staying());
    }

    IEnumerator Waiting()
    {
        bubble.Stop();
        whirlpool.play = false;
        whirlpool.isSucking = false;
        rotiferPrefab.SetActive(false);
        yield return new WaitForSeconds(disappearInterval);
        transform.position = PlayerManager.Instance.RandomPointWithinProjectedRange();
        bubble.Play();
        yield return new WaitForSeconds(bubbleInterval);
        whirlpool.play = true;
        whirlpool.isSucking = true;

        yield return new WaitForSeconds(appearInterval);
        RotiferAppear();

        yield return new WaitForSeconds(attackInterval);
        rotifer.rotiferAnimator.SetTrigger("Attack");
        float timePassed = 0;
        while (timePassed < attackInterval)
        {
            timePassed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            float currentHeight = Mathf.SmoothStep(0, jumpHeightEnd - spawnPointDepth, timePassed / attackInterval);
            rotiferPrefab.transform.localPosition = new Vector3(0, currentHeight, 0);
        }

        timePassed = 0;
        while (timePassed < retreatInterval)
        {
            timePassed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            float currentHeight = Mathf.SmoothStep(jumpHeightEnd - spawnPointDepth, 0, timePassed / retreatInterval);
            rotiferPrefab.transform.localPosition = new Vector3(0, currentHeight, 0);
        }

        yield return new WaitForSeconds(retreatInterval);
        RotiferDisappear();

        whirlpool.isSucking = false;
        whirlpool.play = false;
        bubble.Stop();
        StartCoroutine(Waiting());
    }

    IEnumerator Attacking()
    {
        rotifer.rotiferAnimator.SetTrigger("Attack");
        float timePassed = 0;
        while (timePassed < attackInterval)
        {
            timePassed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            float currentHeight = Mathf.SmoothStep(0, jumpHeightEnd - spawnPointDepth, timePassed / attackInterval);
            rotiferPrefab.transform.localPosition = new Vector3(0, currentHeight, 0);
        }

        timePassed = 0;
        while (timePassed < retreatInterval)
        {
            timePassed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            float currentHeight = Mathf.SmoothStep(jumpHeightEnd - spawnPointDepth, 0, timePassed / retreatInterval);
            rotiferPrefab.transform.localPosition = new Vector3(0, currentHeight, 0);
        }
    }

    IEnumerator Eating()
    {
        rotifer.rotiferAnimator.SetTrigger("Attack");
        float timePassed = 0;
        while (timePassed < attackInterval)
        {
            timePassed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            float currentHeight = Mathf.SmoothStep(0, jumpHeightEnd - spawnPointDepth, timePassed / attackInterval);
            rotiferPrefab.transform.localPosition = new Vector3(0, currentHeight, 0);
        }

        timePassed = 0;
        while (timePassed < retreatInterval)
        {
            timePassed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            float currentHeight = Mathf.SmoothStep(jumpHeightEnd - spawnPointDepth, 0, timePassed / retreatInterval);
            rotiferPrefab.transform.localPosition = new Vector3(0, currentHeight, 0);
        }

        whirlpool.isSucking = false;
        whirlpool.play = false;
        yield return new WaitForSeconds(disappearInterval);
        StartCoroutine(Staying());
    }


    void RotiferAppear()
    {
        rotiferPrefab.SetActive(true);
        rotifer.rotiferAnimator.SetTrigger("Idle");
        rotifer.ClearMouth();
    }

    void RotiferAttack()
    {
        rotifer.rotiferAnimator.SetTrigger("Attack");
    }

    void RotiferDisappear()
    {
        rotiferPrefab.SetActive(false);
        rotifer.rotiferAnimator.SetTrigger("Idle");
    }

    
}