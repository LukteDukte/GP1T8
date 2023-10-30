using UnityEngine;
using UnityEngine.InputSystem;

public class LightPositionSlider : MonoBehaviour
{
    #region Config
    private float _maxHight;
    private float _maxWidth;
    float _currentHight;
    Camera _mainCamera;
    private float _lightPlacementRight;
    private float _lightPlacementLeft;
    private bool isDpadUpPressedRight = false;
    private bool isDpadDownPressedRight = false;
    private bool isDpadUpPressedLeft = false;
    private bool isDpadDownPressedLeft = false;


    [Header("Pacement Settings")] 
    public bool placeItLeft;
    public bool placeItRight;
    [SerializeField] private int placementRangeFromCamera;
    [SerializeField] private float dpadSpeed;
    
    [Header("Input Actions")]
    [SerializeField] private InputActionAsset actions;
    #endregion
    
    private void Awake()
    {
        _mainCamera = Camera.main;
        _maxHight = Screen.height;
        _maxWidth = Screen.width;
        
        actions = GetComponent<PlayerInput>().actions;
        actions.FindAction("sliderRight").performed += MoveRightSlider;
        actions.FindAction("sliderLeft").performed += MoveLeftSlider;
        
        actions.FindAction("dpadUpRight").started += OnDpadUpPressedRight;
        actions.FindAction("dpadUpRight").canceled += OnDpadUpPressedRight;

        actions.FindAction("dpadDownRight").started += OnDpadDownPressedRight;
        actions.FindAction("dpadDownRight").canceled += OnDpadDownPressedRight;
        
        actions.FindAction("dpadUpLeft").started += OnDpadUpPressedLeft;
        actions.FindAction("dpadUpLeft").canceled += OnDpadUpPressedLeft;

        actions.FindAction("dpadDownLeft").started += OnDpadDownPressedLeft;
        actions.FindAction("dpadDownLeft").canceled += OnDpadDownPressedLeft;
        
        actions.FindAction("LightRight").performed += ctx => LightRight();
        actions.FindAction("LightLeft").performed += ctx => LightLeft();

    }

    public void SetRightLeft(int playerIndex)
    {
        if (playerIndex == 0)
        {
            placeItLeft = true;
        }
        else
        {
            placeItRight = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (placeItLeft)
        {
            _currentHight = Mathf.Lerp(0f, _maxHight, _lightPlacementLeft);
            LightPlacement(_currentHight, 0);
            
        }
        else if (placeItRight)
        {
            _currentHight = Mathf.Lerp(0f, _maxHight, _lightPlacementRight); // updates the float value of the current hight, based on how much you press the trigger.
            LightPlacement(_currentHight, _maxWidth); // using _currentHight and _maxWidth, to move the object in the world space.
        }
        
        if (isDpadUpPressedRight)
        {
            // Adjust position upwards
            _lightPlacementRight = Mathf.Clamp(_lightPlacementRight + dpadSpeed * Time.deltaTime, 0, 1);
        }
        else if (isDpadDownPressedRight)
        {
            // Adjust position downwards
            _lightPlacementRight = Mathf.Clamp(_lightPlacementRight - dpadSpeed * Time.deltaTime, 0, 1);
        }
        
        if (isDpadUpPressedLeft)
        {
            // Adjust position upwards
            _lightPlacementLeft = Mathf.Clamp(_lightPlacementLeft + dpadSpeed * Time.deltaTime, 0, 1);
        }
        else if (isDpadDownPressedLeft)
        {
            // Adjust position downwards
            _lightPlacementLeft = Mathf.Clamp(_lightPlacementLeft - dpadSpeed * Time.deltaTime, 0, 1);
        }
    }

    void LightPlacement(float hight, float width)
    {
        gameObject.transform.position = _mainCamera.ScreenToWorldPoint(new Vector3(width, hight, placementRangeFromCamera));
    } // Takes the hight and width and places the object in the world space BASED on the camera.
    
    void MoveRightSlider(InputAction.CallbackContext context)
    {
        _lightPlacementRight = context.ReadValue<float>();
    } // Gets input from the right controller trigger and gives a float value of 0-1.
    
    void MoveLeftSlider(InputAction.CallbackContext context)
    {
        _lightPlacementLeft = context.ReadValue<float>();
    } // Gets input from the left controller trigger and gives a float value of 0-1.
    void OnDpadUpPressedRight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            isDpadUpPressedRight = true;
        else if (context.phase == InputActionPhase.Canceled)
            isDpadUpPressedRight = false;
    }

    void OnDpadDownPressedRight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            isDpadDownPressedRight = true;
        else if (context.phase == InputActionPhase.Canceled)
            isDpadDownPressedRight = false;
    }
    
    void OnDpadUpPressedLeft(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            isDpadUpPressedLeft = true;
        else if (context.phase == InputActionPhase.Canceled)
            isDpadUpPressedLeft = false;
    }
    
    void OnDpadDownPressedLeft(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            isDpadDownPressedLeft = true;
        else if (context.phase == InputActionPhase.Canceled)
            isDpadDownPressedLeft = false;
    }
    
    private void LightRight()
    {
        if (placeItRight)
        {
            GetComponent<LightSource>().Toggle();
        }
        
    }
    void LightLeft()
    {
        if (placeItLeft)
        {
            GetComponent<LightSource>().Toggle();
        }
    }

}
