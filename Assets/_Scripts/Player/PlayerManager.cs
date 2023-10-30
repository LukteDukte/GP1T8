using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    #region Config
    [Header("Input Actions")]
    [SerializeField] private InputActionAsset actions;
    [Space(20)]
    // [SerializeField] private GameObject lightLeft;
    // [SerializeField] private GameObject lightRight;
    // [SerializeField] private GameObject movingObject;
    // [SerializeField] private Volvox _volvox;
    
    [Header("Player Settings")]
    [SerializeField] public LightSource lightSourceLeft;
    [SerializeField] public LightSource lightSourceRight;
    [SerializeField] private float speed;
    
    private InputAction _lightRight;
    private InputAction _lightLeft;
    #endregion
    PlayerInputManager _playerInputManager;
    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        
        _playerInputManager = GetComponent<PlayerInputManager>();
        _playerInputManager.onPlayerJoined += OnPlayerJoined;
        _playerInputManager.JoinPlayer();
        _playerInputManager.JoinPlayer();
        
        /*actions.FindAction("LightRight").performed += ctx => LightRight();
        actions.FindAction("LightLeft").performed += ctx => LightLeft();*/
    }

    // private void FixedUpdate()
    // {
    //     if (lightRight.activeSelf && lightLeft.activeSelf)
    //     {
    //         
    //     }
    //     else if (lightRight.activeSelf)
    //     {
    //         movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, lightRight.transform.position, speed*Time.fixedDeltaTime);
    //     }
    //     else if (lightLeft.activeSelf)
    //     {
    //         movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, lightLeft.transform.position, speed*Time.fixedDeltaTime);
    //     }
    // }

    /*private void LightRight()
    {
        // if (lightRight.activeSelf)
        // {
        //     lightRight.SetActive(false);
        // }
        // else
        // {
        //     lightRight.SetActive(true);
        // }
        
        lightSourceRight.Toggle();
        
    } // Checks if the object is active or not, and then sets it to the opposite.
    
    private void LightLeft()
    {
        // if (lightLeft.activeSelf)
        // {
        //     lightLeft.SetActive(false);
        // }
        // else
        // {
        //     lightLeft.SetActive(true);
        // }
        
        lightSourceLeft.Toggle();
        
    } // Checks if the object is active or not, and then sets it to the opposite.*/

    public Vector3 ScreenToProjectedPoint(float x, float y)
    {
        Camera cam = Camera.main;
        Vector3 screenPos = cam.ScreenToWorldPoint(new Vector3(x, y, cam.farClipPlane));
        Vector3 projectDir = (screenPos - cam.transform.position).normalized;
        float d = Vector3.Dot(screenPos, Vector3.up) / Vector3.Dot(- projectDir, Vector3.up);
        Vector3 projectedPos = screenPos + projectDir * d;
        return projectedPos;
    }

    public Vector3 RandomPointWithinProjectedRange()
    {
        float x = Random.Range(0f, Screen.width);
        float y = Random.Range(0f, Screen.height);
        return ScreenToProjectedPoint(x, y);
    }
    
    void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.gameObject.GetComponent<LightPositionSlider>().SetRightLeft(playerInput.playerIndex);
        playerInput.gameObject.transform.SetParent(gameObject.transform);
        
        Debug.Log("I have placed this to the left!"+playerInput.gameObject.GetComponent<LightPositionSlider>().placeItLeft);
        Debug.Log("I have placed this to the Right!"+playerInput.gameObject.GetComponent<LightPositionSlider>().placeItRight);
        
        if (playerInput.gameObject.GetComponent<LightPositionSlider>().placeItLeft)
        {
            lightSourceLeft = playerInput.gameObject.GetComponent<LightSource>();
            Debug.Log("Left");
        }
        else if (playerInput.gameObject.GetComponent<LightPositionSlider>().placeItRight)
        {
            lightSourceRight = playerInput.gameObject.GetComponent<LightSource>();
            Debug.Log("Right");
        }
        
        if (Gamepad.all.Count > 0 && playerInput.playerIndex < Gamepad.all.Count)
        {
            Debug.Log(Gamepad.all.Count);
            playerInput.SwitchCurrentControlScheme("Gamepad", Gamepad.all[playerInput.playerIndex]);
            return;
        }

        playerInput.SwitchCurrentControlScheme($"Keyboard", Keyboard.current);
        
        //GetBoolFromLight(playerInput);
    }

    void GetBoolFromLight(PlayerInput playerInput)
    {
        if (playerInput.playerIndex == 0)
        {
            playerInput.gameObject.GetComponent<LightSource>();
        }
        else if (playerInput.playerIndex == 1)
        {
            playerInput.gameObject.GetComponent<LightSource>();
        }
    }
    
}
