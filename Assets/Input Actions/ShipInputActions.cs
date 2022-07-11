// GENERATED AUTOMATICALLY FROM 'Assets/Input Actions/ShipInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ShipInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ShipInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ShipInputActions"",
    ""maps"": [
        {
            ""name"": ""Ship"",
            ""id"": ""109a13cc-db82-4890-ae8e-c3e5998b6d53"",
            ""actions"": [
                {
                    ""name"": ""Left_Click"",
                    ""type"": ""Button"",
                    ""id"": ""82ea17c5-eeae-4eb1-a9c6-8dfd91ea50fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right_Click"",
                    ""type"": ""Button"",
                    ""id"": ""614c20b0-c1d4-4e83-9411-3cc5f3168671"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b8f5e61a-69d4-4a5e-88a1-efcde6f4d833"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left_Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""915286b9-49c3-41b0-8339-2bf21a734167"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right_Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ship
        m_Ship = asset.FindActionMap("Ship", throwIfNotFound: true);
        m_Ship_Left_Click = m_Ship.FindAction("Left_Click", throwIfNotFound: true);
        m_Ship_Right_Click = m_Ship.FindAction("Right_Click", throwIfNotFound: true);
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

    // Ship
    private readonly InputActionMap m_Ship;
    private IShipActions m_ShipActionsCallbackInterface;
    private readonly InputAction m_Ship_Left_Click;
    private readonly InputAction m_Ship_Right_Click;
    public struct ShipActions
    {
        private @ShipInputActions m_Wrapper;
        public ShipActions(@ShipInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left_Click => m_Wrapper.m_Ship_Left_Click;
        public InputAction @Right_Click => m_Wrapper.m_Ship_Right_Click;
        public InputActionMap Get() { return m_Wrapper.m_Ship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
        public void SetCallbacks(IShipActions instance)
        {
            if (m_Wrapper.m_ShipActionsCallbackInterface != null)
            {
                @Left_Click.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnLeft_Click;
                @Left_Click.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnLeft_Click;
                @Left_Click.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnLeft_Click;
                @Right_Click.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnRight_Click;
                @Right_Click.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnRight_Click;
                @Right_Click.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnRight_Click;
            }
            m_Wrapper.m_ShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Left_Click.started += instance.OnLeft_Click;
                @Left_Click.performed += instance.OnLeft_Click;
                @Left_Click.canceled += instance.OnLeft_Click;
                @Right_Click.started += instance.OnRight_Click;
                @Right_Click.performed += instance.OnRight_Click;
                @Right_Click.canceled += instance.OnRight_Click;
            }
        }
    }
    public ShipActions @Ship => new ShipActions(this);
    public interface IShipActions
    {
        void OnLeft_Click(InputAction.CallbackContext context);
        void OnRight_Click(InputAction.CallbackContext context);
    }
}
