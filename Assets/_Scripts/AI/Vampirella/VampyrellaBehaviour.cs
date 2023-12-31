using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class VampyrellaBehaviour : MonoBehaviour
{
    #region Config

    [Header("Vampyrella Settings")] [SerializeField]
    float movementSpeed;

    [SerializeField] float giveUpChaseTimer;
    [SerializeField] float attachedToPlayerTimer;
    [SerializeField] float attachDistance;
    [Header("Audio")] [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    [Space(15)] [SerializeField] private Transform mouth;
    [SerializeField] GameObject player;
    [SerializeField] Volvox volvoxScript;
    [SerializeField] private Animator animator;
    private EnemyState privoState;
    Vector3 _offset;
    float _timer;
    private bool hasAttached = false; // Add this boolean variable to track attachment status

    #endregion

    #region AI_States

    enum EnemyState
    {
        IdleForwards,
        Chasing,
        Attached,
        GoesAway
    }

    EnemyState _enemyState;

    #endregion

    void FixedUpdate()
    {
        AIVampyrella();
    }

    private void Update()
    {
        UpdateAnimationState();
    }

    void AIVampyrella()
    {
        #region AI_Logic

        switch (_enemyState)
        {
            case EnemyState.IdleForwards:
                gameObject.transform.Translate(Vector3.forward * (Time.fixedDeltaTime * movementSpeed));
                break; // Moves in a straight line.
            case EnemyState.Chasing:
                if (Volvox.Instance.isAttacked)
                {
                    _enemyState = EnemyState.Attached;
                }
                else
                {
                    gameObject.transform.LookAt(player.transform);
                    gameObject.transform.Translate(Vector3.forward * (Time.fixedDeltaTime * movementSpeed));
                    TimerCountdown();
                    if (giveUpChaseTimer < _timer)
                    {
                        TimerReset();
                        gameObject.transform.LookAt(player.transform.position * -1);
                        _enemyState = EnemyState.GoesAway;
                    }
                    else if (Vector3.Distance(gameObject.transform.position, player.transform.position) <
                             attachDistance)
                    {
                        audioSource.PlayOneShot(audioClips[0]);
                        TimerReset();
                        _offset = transform.position - player.transform.position;
                        _enemyState = EnemyState.Attached;
                    }
                }

                break; // Moves towards the player. It will give up after a certain amount of time, based on [giveUpTimer]. It also sets the enemy state to [Attached] if it gets close enough to the player.
            case EnemyState.Attached:
                if (!hasAttached)
                {
                    hasAttached = true;
                    // Only run this code block once when transitioning to the Attached state
                    Volvox.Instance.isAttacked = true;
                    // ...
                }

                TimerCountdown();
                KeepCurrentPositionWithObject(player.transform.position);
                if (attachedToPlayerTimer < _timer)
                {
                    volvoxScript.RemoveColony();
                    audioSource.PlayOneShot(audioClips[1]);
                    TimerReset();
                    gameObject.transform.LookAt(player.transform.position * -1);
                    _enemyState = EnemyState.GoesAway;
                    Volvox.Instance.isAttacked = false;
                }

                break; // Sticks to the player and deals 1 damage, aka takes 1 colony.
            case EnemyState.GoesAway:
                gameObject.transform.Translate(Vector3.forward * (Time.fixedDeltaTime * movementSpeed));
                break; // Moves in a straight line and fades away.
            default:
                throw new ArgumentOutOfRangeException();
        }

        #endregion
    }

    void TimerCountdown()
    {
        _timer += Time.fixedDeltaTime;
    }

    void TimerReset()
    {
        _timer = 0f;
    }

    void KeepCurrentPositionWithObject(Vector3 objectPosition)
    {
        transform.position = objectPosition + _offset;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<VolvoxHealth>() && !hasAttached)
        {
            volvoxScript = collision.GetComponent<Volvox>();
            if(volvoxScript.isAttacked) return;
            
            _enemyState = EnemyState.Chasing;
            player = collision.GetComponent<Volvox>().gameObject;
            // Add some additional force towards volvox transform
            // then add force and disappearing movementspeed in the other direction, or just destroy?
        }
    }

    private void UpdateAnimationState()
    {
        if (privoState == _enemyState) return;

        switch (_enemyState)
        {
            case EnemyState.IdleForwards:
                animator.SetTrigger("Swim");
                break;
            case EnemyState.Chasing:
                animator.SetTrigger("React");
                break;
            case EnemyState.Attached:
                animator.SetTrigger("Attack");
                break;
            case EnemyState.GoesAway:
                animator.SetTrigger("Detach");
                break;
        }
        privoState = _enemyState;
    }
}


/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VampyrellaBehaviour : MonoBehaviour
{
    #region Config
    [Header("Vampyrella Settings")]
    [SerializeField] float movementSpeed;
    [SerializeField] float giveUpChaseTimer;
    [SerializeField] float attachedToPlayerTimer;
    [SerializeField] float attachDistance;
    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    [Space(15)]

    [SerializeField] private Transform mouth;
    [SerializeField] GameObject player;
    [SerializeField] Volvox volvoxScript;
    Vector3 _offset;
    float _timer;
    #endregion

    #region AI_States
    enum EnemyState
    {
        IdleForwards,
        Chasing,
        Attached,
        GoesAway
    }
    EnemyState _enemyState;
    #endregion
    void FixedUpdate()
    {
        AIVampyrella();
    }

    void AIVampyrella()
    {
        #region AI_Logic
        switch (_enemyState)
        {
            case EnemyState.IdleForwards:
                gameObject.transform.Translate(Vector3.forward * (Time.fixedDeltaTime * movementSpeed));
                break; // Moves in a straight line.
            case EnemyState.Chasing:
                gameObject.transform.LookAt(player.transform);
                gameObject.transform.Translate(Vector3.forward * (Time.fixedDeltaTime * movementSpeed));
                TimerCountdown();
                if (giveUpChaseTimer < _timer)
                {
                    TimerReset();
                    gameObject.transform.LookAt(player.transform.position * -1);
                    _enemyState = EnemyState.GoesAway;
                }
                else if (Vector3.Distance(gameObject.transform.position, player.transform.position) < attachDistance)
                {
                    audioSource.PlayOneShot(audioClips[0]);
                    TimerReset();
                    _offset = transform.position - player.transform.position;
                    _enemyState = EnemyState.Attached;
                }
                break; // Moves towards the player. It will give up after a certain amount of time, based on [giveUpTimer]. It also sets the enemy state to [Attached] if it gets close enough to the player.
            case EnemyState.Attached:
                TimerCountdown();
                KeepCurrentPositionWithObject(player.transform.position);
                if (attachedToPlayerTimer < _timer)
                {
                    volvoxScript.RemoveColony();
                    audioSource.PlayOneShot(audioClips[1]);
                    TimerReset();
                    gameObject.transform.LookAt(player.transform.position * -1);
                    _enemyState = EnemyState.GoesAway;
                }
                break; // Sticks to the player and deals 1 damage, aka takes 1 colony.
            case EnemyState.GoesAway:
                gameObject.transform.Translate(Vector3.forward * (Time.fixedDeltaTime * movementSpeed));
                break; // Moves in a straight line and fades away.
            default:
                throw new ArgumentOutOfRangeException();
        }
        #endregion
    }

    void TimerCountdown()
    {
        _timer += Time.fixedDeltaTime;
    }
    void TimerReset()
    {
        _timer = 0f;
    }
    void KeepCurrentPositionWithObject(Vector3 objectPosition)
    {
        transform.position = objectPosition + _offset;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<VolvoxHealth>())
        {
            _enemyState = EnemyState.Chasing;
            player = collision.GetComponent<Volvox>().gameObject;
            volvoxScript = collision.GetComponent<Volvox>();
            //Add some additional force towards volvox transform
            //then add force and disappearing movementspeed in the other direction, or just destroy?
        }
    }

    private void OnDestroy()
    {
        //If out of sight of camera -> destroy
        //if(transform.)
    }

}

*/