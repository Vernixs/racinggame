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
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""7298fa84-0ba3-4e66-b487-0289b16190b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""e90d2139-1202-4e19-b30e-e3c83828c88b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftTurn"",
                    ""type"": ""Button"",
                    ""id"": ""79dcc2dd-5cd6-43c8-9be7-51c235922fe7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightTurn"",
                    ""type"": ""Button"",
                    ""id"": ""ba6c5cce-c2f3-49aa-ad25-28bc1a89fd5e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d9a24a3c-6afd-489b-bc72-d25726c69821"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcff0a5e-7d87-4ded-bf43-ba6ebd5f3cf8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""042c28b7-af32-41f5-b044-b9687a3420d7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTurn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""680da389-32bb-4691-b0a1-f586bb1f144b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTurn"",
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
        m_Movement_Accelerate = m_Movement.FindAction("Accelerate", throwIfNotFound: true);
        m_Movement_Brake = m_Movement.FindAction("Brake", throwIfNotFound: true);
        m_Movement_LeftTurn = m_Movement.FindAction("LeftTurn", throwIfNotFound: true);
        m_Movement_RightTurn = m_Movement.FindAction("RightTurn", throwIfNotFound: true);
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
    private readonly InputAction m_Movement_Accelerate;
    private readonly InputAction m_Movement_Brake;
    private readonly InputAction m_Movement_LeftTurn;
    private readonly InputAction m_Movement_RightTurn;
    public struct MovementActions
    {
        private @MovementControls m_Wrapper;
        public MovementActions(@MovementControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_Movement_Accelerate;
        public InputAction @Brake => m_Wrapper.m_Movement_Brake;
        public InputAction @LeftTurn => m_Wrapper.m_Movement_LeftTurn;
        public InputAction @RightTurn => m_Wrapper.m_Movement_RightTurn;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Accelerate.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAccelerate;
                @Brake.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnBrake;
                @LeftTurn.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeftTurn;
                @LeftTurn.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeftTurn;
                @LeftTurn.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeftTurn;
                @RightTurn.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRightTurn;
                @RightTurn.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRightTurn;
                @RightTurn.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRightTurn;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @LeftTurn.started += instance.OnLeftTurn;
                @LeftTurn.performed += instance.OnLeftTurn;
                @LeftTurn.canceled += instance.OnLeftTurn;
                @RightTurn.started += instance.OnRightTurn;
                @RightTurn.performed += instance.OnRightTurn;
                @RightTurn.canceled += instance.OnRightTurn;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnLeftTurn(InputAction.CallbackContext context);
        void OnRightTurn(InputAction.CallbackContext context);
    }
}
