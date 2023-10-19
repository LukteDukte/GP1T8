//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Inputs/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""14bcc1f7-2168-42c2-aad7-92f530c0fbc3"",
            ""actions"": [
                {
                    ""name"": ""PlayerAction"",
                    ""type"": ""Value"",
                    ""id"": ""533acc78-e13d-451a-bc52-195ca760411d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LightLeft"",
                    ""type"": ""Button"",
                    ""id"": ""1d8a4b54-20e6-487c-9c8d-75e129a47ab6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LightRight"",
                    ""type"": ""Button"",
                    ""id"": ""695523ea-eef8-4053-9911-fdde4d4bb6fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SliderLeft"",
                    ""type"": ""Value"",
                    ""id"": ""9a7d9394-56e6-4645-8929-c92e5b1bddce"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SliderRight"",
                    ""type"": ""Value"",
                    ""id"": ""6bc3a032-25e0-401b-9c46-b2c014957d90"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c42d4237-00d4-49a5-ab73-845970f8d894"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerAction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d4505cf0-81d9-4faa-bdd2-fc107312d4e5"",
                    ""path"": ""<XInputController>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""42cb07e3-f05b-429b-8d4c-bebb0ee39d6f"",
                    ""path"": ""<XInputController>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8df2a134-3e0a-46bc-91a7-ea1698849496"",
                    ""path"": ""<XInputController>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""00c3ef4f-3e2a-4a88-b387-cf52e1661f77"",
                    ""path"": ""<XInputController>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector from keyboard"",
                    ""id"": ""d63ee582-e182-4086-8ed7-a89f92869276"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerAction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""01d45d93-5201-402c-9660-b260b1b07131"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""06fcd0c7-be5b-46de-97c7-eb7cefe28583"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6658296d-809a-45ac-b81a-a8d7d4906f77"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f91cd8e7-4065-4a04-aa25-e9f4efd00849"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8c64a922-a500-416b-b2cb-b823f527f91e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2206420-65a9-410c-be71-88f6c663aef6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bba1a5e-37ac-4e73-90c8-11fb33ae5816"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a81585e-1023-4891-bf29-67735dc7a527"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d67e7a0-4e69-477e-8ca2-d6ac0d76ac7b"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SliderLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""211d59fa-1772-4eff-9fc6-24de7aac886f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SliderRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_PlayerAction = m_Player.FindAction("PlayerAction", throwIfNotFound: true);
        m_Player_LightLeft = m_Player.FindAction("LightLeft", throwIfNotFound: true);
        m_Player_LightRight = m_Player.FindAction("LightRight", throwIfNotFound: true);
        m_Player_SliderLeft = m_Player.FindAction("SliderLeft", throwIfNotFound: true);
        m_Player_SliderRight = m_Player.FindAction("SliderRight", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_PlayerAction;
    private readonly InputAction m_Player_LightLeft;
    private readonly InputAction m_Player_LightRight;
    private readonly InputAction m_Player_SliderLeft;
    private readonly InputAction m_Player_SliderRight;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerAction => m_Wrapper.m_Player_PlayerAction;
        public InputAction @LightLeft => m_Wrapper.m_Player_LightLeft;
        public InputAction @LightRight => m_Wrapper.m_Player_LightRight;
        public InputAction @SliderLeft => m_Wrapper.m_Player_SliderLeft;
        public InputAction @SliderRight => m_Wrapper.m_Player_SliderRight;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @PlayerAction.started += instance.OnPlayerAction;
            @PlayerAction.performed += instance.OnPlayerAction;
            @PlayerAction.canceled += instance.OnPlayerAction;
            @LightLeft.started += instance.OnLightLeft;
            @LightLeft.performed += instance.OnLightLeft;
            @LightLeft.canceled += instance.OnLightLeft;
            @LightRight.started += instance.OnLightRight;
            @LightRight.performed += instance.OnLightRight;
            @LightRight.canceled += instance.OnLightRight;
            @SliderLeft.started += instance.OnSliderLeft;
            @SliderLeft.performed += instance.OnSliderLeft;
            @SliderLeft.canceled += instance.OnSliderLeft;
            @SliderRight.started += instance.OnSliderRight;
            @SliderRight.performed += instance.OnSliderRight;
            @SliderRight.canceled += instance.OnSliderRight;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @PlayerAction.started -= instance.OnPlayerAction;
            @PlayerAction.performed -= instance.OnPlayerAction;
            @PlayerAction.canceled -= instance.OnPlayerAction;
            @LightLeft.started -= instance.OnLightLeft;
            @LightLeft.performed -= instance.OnLightLeft;
            @LightLeft.canceled -= instance.OnLightLeft;
            @LightRight.started -= instance.OnLightRight;
            @LightRight.performed -= instance.OnLightRight;
            @LightRight.canceled -= instance.OnLightRight;
            @SliderLeft.started -= instance.OnSliderLeft;
            @SliderLeft.performed -= instance.OnSliderLeft;
            @SliderLeft.canceled -= instance.OnSliderLeft;
            @SliderRight.started -= instance.OnSliderRight;
            @SliderRight.performed -= instance.OnSliderRight;
            @SliderRight.canceled -= instance.OnSliderRight;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnPlayerAction(InputAction.CallbackContext context);
        void OnLightLeft(InputAction.CallbackContext context);
        void OnLightRight(InputAction.CallbackContext context);
        void OnSliderLeft(InputAction.CallbackContext context);
        void OnSliderRight(InputAction.CallbackContext context);
    }
}
