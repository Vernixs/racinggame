// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Others/MovementControlsNew.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MovementControlsNew : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MovementControlsNew()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MovementControlsNew"",
    ""maps"": [
        {
            ""name"": ""NewMovement"",
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
        // NewMovement
        m_NewMovement = asset.FindActionMap("NewMovement", throwIfNotFound: true);
        m_NewMovement_Accelerate = m_NewMovement.FindAction("Accelerate", throwIfNotFound: true);
        m_NewMovement_Brake = m_NewMovement.FindAction("Brake", throwIfNotFound: true);
        m_NewMovement_LeftTurn = m_NewMovement.FindAction("LeftTurn", throwIfNotFound: true);
        m_NewMovement_RightTurn = m_NewMovement.FindAction("RightTurn", throwIfNotFound: true);
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

    // NewMovement
    private readonly InputActionMap m_NewMovement;
    private INewMovementActions m_NewMovementActionsCallbackInterface;
    private readonly InputAction m_NewMovement_Accelerate;
    private readonly InputAction m_NewMovement_Brake;
    private readonly InputAction m_NewMovement_LeftTurn;
    private readonly InputAction m_NewMovement_RightTurn;
    public struct NewMovementActions
    {
        private @MovementControlsNew m_Wrapper;
        public NewMovementActions(@MovementControlsNew wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_NewMovement_Accelerate;
        public InputAction @Brake => m_Wrapper.m_NewMovement_Brake;
        public InputAction @LeftTurn => m_Wrapper.m_NewMovement_LeftTurn;
        public InputAction @RightTurn => m_Wrapper.m_NewMovement_RightTurn;
        public InputActionMap Get() { return m_Wrapper.m_NewMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewMovementActions set) { return set.Get(); }
        public void SetCallbacks(INewMovementActions instance)
        {
            if (m_Wrapper.m_NewMovementActionsCallbackInterface != null)
            {
                @Accelerate.started -= m_Wrapper.m_NewMovementActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_NewMovementActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_NewMovementActionsCallbackInterface.OnAccelerate;
                @Brake.started -= m_Wrapper.m_NewMovementActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_NewMovementActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_NewMovementActionsCallbackInterface.OnBrake;
                @LeftTurn.started -= m_Wrapper.m_NewMovementActionsCallbackInterface.OnLeftTurn;
                @LeftTurn.performed -= m_Wrapper.m_NewMovementActionsCallbackInterface.OnLeftTurn;
                @LeftTurn.canceled -= m_Wrapper.m_NewMovementActionsCallbackInterface.OnLeftTurn;
                @RightTurn.started -= m_Wrapper.m_NewMovementActionsCallbackInterface.OnRightTurn;
                @RightTurn.performed -= m_Wrapper.m_NewMovementActionsCallbackInterface.OnRightTurn;
                @RightTurn.canceled -= m_Wrapper.m_NewMovementActionsCallbackInterface.OnRightTurn;
            }
            m_Wrapper.m_NewMovementActionsCallbackInterface = instance;
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
    public NewMovementActions @NewMovement => new NewMovementActions(this);
    public interface INewMovementActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnLeftTurn(InputAction.CallbackContext context);
        void OnRightTurn(InputAction.CallbackContext context);
    }
}
