// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""eb40caa6-f35d-4b0f-b42d-8597af13926b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""0fc2dc98-0da4-4200-abae-20d299a9b53a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""7c493351-d973-4f00-a51e-0e2e1bdffa0b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraLock"",
                    ""type"": ""Button"",
                    ""id"": ""50b5854b-cc2e-403a-9476-df1a799dbc5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)""
                },
                {
                    ""name"": ""NormalInteraction"",
                    ""type"": ""Button"",
                    ""id"": ""da605d2d-b5c0-46e7-9b74-a5e1a0223413"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""SpecialInteraction"",
                    ""type"": ""Button"",
                    ""id"": ""9ca2a8c8-188e-4879-b946-669d365f8b59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""Interrupt"",
                    ""type"": ""Button"",
                    ""id"": ""08d31b66-d4c7-416e-966a-6cb44f0a9558"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""e41aa536-7a15-4aa5-819f-146865301763"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""23e4ef09-8b7b-4a6b-a9b9-63b7df1ac527"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold,Press(behavior=2)""
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""92eb3bbd-04f1-4ceb-8ac6-495c7d3ad0ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6f0a65f1-9ba4-49e7-9b4b-d32711b1073d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""Lean"",
                    ""type"": ""Button"",
                    ""id"": ""b67b00ad-ec74-4933-a0b0-a18804310c4c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""Cover"",
                    ""type"": ""Button"",
                    ""id"": ""5d4fd136-dcb6-4d1a-92fa-98e7cdb5ed50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)""
                },
                {
                    ""name"": ""Craft"",
                    ""type"": ""Button"",
                    ""id"": ""88a13207-8980-4218-8f89-182c5fa4b59a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)""
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""84636690-2368-4aa4-99b0-dab46c8735a6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""dfcc1671-b013-4326-b3e8-3e6346d94889"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e66f0e43-db18-44ff-8cb1-95998c427ba3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0a13d788-13b9-4613-aa3c-c7be3696638e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3d07499d-e13e-48c8-a1f7-0ba44cb7adf3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0a6df2ff-de77-4aee-8dd5-610102870a95"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2f215745-110e-4558-92a9-18e5bf9076c1"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb390a5f-1e68-43c2-9226-bd2c187841d5"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fd0976a-b563-43a1-a65d-52ff99c87c94"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3402fee3-f9dd-44c0-a7b8-cbebb04fd659"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""CameraLock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5bc100e-51cb-4507-9143-67f4fa612772"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb900a64-e4cd-489d-a910-352aa1d6e3be"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""457b5c68-d996-46d5-8d91-da0b5e6d52cf"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09aaec7a-fbd8-4f69-b56f-60e4b6f52227"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4514bd8-9ac9-4320-ad1c-45069574a172"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""120af7cc-27f6-4cfe-a4e4-4d6f2e7094ae"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04791122-c4c8-4339-b015-2be932da4715"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lean"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e80e5982-09c6-4b2e-8504-dcd1b48780ca"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lean"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ea1775e-57bd-49e7-b8a9-883bcfebddba"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05b2a426-b48c-45cf-affa-3c1764d8b214"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44e17d13-7ad7-4eb0-ba3d-db802f1bc720"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""NormalInteraction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b736f7cc-5696-4916-8591-70080c7a0f80"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""NormalInteraction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23f05b8f-6a88-49dd-aa1f-8def03f78beb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Interrupt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7f2dea7-8376-4b14-818e-64a92ee881a0"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interrupt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70c8ae7e-08fd-4172-a016-e019760689b4"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b73c341f-3438-4c4a-863f-af705caf6fa0"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5dd02402-ce93-42ad-b53c-b23951c6f460"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SpecialInteraction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3657e291-bc68-408f-a1e9-87990a545264"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SpecialInteraction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6aae09a-43f7-4b04-b062-ea8cae6e3368"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Craft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d83c379-c62a-425f-9392-b209bc69df3f"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Movement = m_GamePlay.FindAction("Movement", throwIfNotFound: true);
        m_GamePlay_Look = m_GamePlay.FindAction("Look", throwIfNotFound: true);
        m_GamePlay_CameraLock = m_GamePlay.FindAction("CameraLock", throwIfNotFound: true);
        m_GamePlay_NormalInteraction = m_GamePlay.FindAction("NormalInteraction", throwIfNotFound: true);
        m_GamePlay_SpecialInteraction = m_GamePlay.FindAction("SpecialInteraction", throwIfNotFound: true);
        m_GamePlay_Interrupt = m_GamePlay.FindAction("Interrupt", throwIfNotFound: true);
        m_GamePlay_Pause = m_GamePlay.FindAction("Pause", throwIfNotFound: true);
        m_GamePlay_Attack = m_GamePlay.FindAction("Attack", throwIfNotFound: true);
        m_GamePlay_Dodge = m_GamePlay.FindAction("Dodge", throwIfNotFound: true);
        m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
        m_GamePlay_Lean = m_GamePlay.FindAction("Lean", throwIfNotFound: true);
        m_GamePlay_Cover = m_GamePlay.FindAction("Cover", throwIfNotFound: true);
        m_GamePlay_Craft = m_GamePlay.FindAction("Craft", throwIfNotFound: true);
        m_GamePlay_MousePosition = m_GamePlay.FindAction("MousePosition", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Movement;
    private readonly InputAction m_GamePlay_Look;
    private readonly InputAction m_GamePlay_CameraLock;
    private readonly InputAction m_GamePlay_NormalInteraction;
    private readonly InputAction m_GamePlay_SpecialInteraction;
    private readonly InputAction m_GamePlay_Interrupt;
    private readonly InputAction m_GamePlay_Pause;
    private readonly InputAction m_GamePlay_Attack;
    private readonly InputAction m_GamePlay_Dodge;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_Lean;
    private readonly InputAction m_GamePlay_Cover;
    private readonly InputAction m_GamePlay_Craft;
    private readonly InputAction m_GamePlay_MousePosition;
    public struct GamePlayActions
    {
        private @PlayerControls m_Wrapper;
        public GamePlayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_GamePlay_Movement;
        public InputAction @Look => m_Wrapper.m_GamePlay_Look;
        public InputAction @CameraLock => m_Wrapper.m_GamePlay_CameraLock;
        public InputAction @NormalInteraction => m_Wrapper.m_GamePlay_NormalInteraction;
        public InputAction @SpecialInteraction => m_Wrapper.m_GamePlay_SpecialInteraction;
        public InputAction @Interrupt => m_Wrapper.m_GamePlay_Interrupt;
        public InputAction @Pause => m_Wrapper.m_GamePlay_Pause;
        public InputAction @Attack => m_Wrapper.m_GamePlay_Attack;
        public InputAction @Dodge => m_Wrapper.m_GamePlay_Dodge;
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @Lean => m_Wrapper.m_GamePlay_Lean;
        public InputAction @Cover => m_Wrapper.m_GamePlay_Cover;
        public InputAction @Craft => m_Wrapper.m_GamePlay_Craft;
        public InputAction @MousePosition => m_Wrapper.m_GamePlay_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMovement;
                @Look.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLook;
                @CameraLock.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCameraLock;
                @CameraLock.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCameraLock;
                @CameraLock.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCameraLock;
                @NormalInteraction.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNormalInteraction;
                @NormalInteraction.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNormalInteraction;
                @NormalInteraction.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNormalInteraction;
                @SpecialInteraction.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSpecialInteraction;
                @SpecialInteraction.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSpecialInteraction;
                @SpecialInteraction.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSpecialInteraction;
                @Interrupt.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnInterrupt;
                @Interrupt.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnInterrupt;
                @Interrupt.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnInterrupt;
                @Pause.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPause;
                @Attack.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAttack;
                @Dodge.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDodge;
                @Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Lean.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLean;
                @Lean.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLean;
                @Lean.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLean;
                @Cover.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCover;
                @Cover.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCover;
                @Cover.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCover;
                @Craft.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCraft;
                @Craft.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCraft;
                @Craft.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCraft;
                @MousePosition.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @CameraLock.started += instance.OnCameraLock;
                @CameraLock.performed += instance.OnCameraLock;
                @CameraLock.canceled += instance.OnCameraLock;
                @NormalInteraction.started += instance.OnNormalInteraction;
                @NormalInteraction.performed += instance.OnNormalInteraction;
                @NormalInteraction.canceled += instance.OnNormalInteraction;
                @SpecialInteraction.started += instance.OnSpecialInteraction;
                @SpecialInteraction.performed += instance.OnSpecialInteraction;
                @SpecialInteraction.canceled += instance.OnSpecialInteraction;
                @Interrupt.started += instance.OnInterrupt;
                @Interrupt.performed += instance.OnInterrupt;
                @Interrupt.canceled += instance.OnInterrupt;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Lean.started += instance.OnLean;
                @Lean.performed += instance.OnLean;
                @Lean.canceled += instance.OnLean;
                @Cover.started += instance.OnCover;
                @Cover.performed += instance.OnCover;
                @Cover.canceled += instance.OnCover;
                @Craft.started += instance.OnCraft;
                @Craft.performed += instance.OnCraft;
                @Craft.canceled += instance.OnCraft;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IGamePlayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnCameraLock(InputAction.CallbackContext context);
        void OnNormalInteraction(InputAction.CallbackContext context);
        void OnSpecialInteraction(InputAction.CallbackContext context);
        void OnInterrupt(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLean(InputAction.CallbackContext context);
        void OnCover(InputAction.CallbackContext context);
        void OnCraft(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
