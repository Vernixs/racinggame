// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Others/MovementControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MovementControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MovementControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MovementControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""aed5c460-83d4-427c-bf8e-35e232a42cc3"",
            ""actions"": [
                {
                    ""name"": ""Acceleration"",
                    ""type"": ""Button"",
                    ""id"": ""7298fa84-0ba3-4e66-b487-0289b16190b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steeringangle"",
                    ""type"": ""Button"",
                    ""id"": ""de1c71d5-7298-4a76-95b4-dbfb4999a6cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyaccel"",
                    ""id"": ""2b791ca9-992c-4489-9892-d05a3caa58cb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""138729dc-6bb7-4ec0-b05e-2e905aea3e59"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a35775d8-60ea-40ee-87d4-eb14195bd8b8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3f6d3ec5-41b0-49e8-a82f-b280e1c1e7ca"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b6c3efd-b182-4391-a6b0-cd6c1e1fa1fd"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steeringangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""b3abfe9f-3afe-45ed-93f3-07e2c38eb5da"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steeringangle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2e60c7b1-61c8-4e17-82be-34cf88b870da"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steeringangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ea2705ed-dfbb-4fae-a065-4d4ef80a546e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steeringangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""64c4dbd5-e481-4721-94aa-da5abed5bfe9"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steeringangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Acceleration = m_Movement.FindAction("Acceleration", throwIfNotFound: true);
        m_Movement_Steeringangle = m_Movement.FindAction("Steeringangle", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Acceleration;
    private readonly InputAction m_Movement_Steeringangle;
    public struct MovementActions
    {
        private @MovementControls m_Wrapper;
        public MovementActions(@MovementControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Acceleration => m_Wrapper.m_Movement_Acceleration;
        public InputAction @Steeringangle => m_Wrapper.m_Movement_Steeringangle;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Acceleration.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAcceleration;
                @Acceleration.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAcceleration;
                @Acceleration.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAcceleration;
                @Steeringangle.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnSteeringangle;
                @Steeringangle.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnSteeringangle;
                @Steeringangle.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnSteeringangle;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Acceleration.started += instance.OnAcceleration;
                @Acceleration.performed += instance.OnAcceleration;
                @Acceleration.canceled += instance.OnAcceleration;
                @Steeringangle.started += instance.OnSteeringangle;
                @Steeringangle.performed += instance.OnSteeringangle;
                @Steeringangle.canceled += instance.OnSteeringangle;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnAcceleration(InputAction.CallbackContext context);
        void OnSteeringangle(InputAction.CallbackContext context);
    }
}