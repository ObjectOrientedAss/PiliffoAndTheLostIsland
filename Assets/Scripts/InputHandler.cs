using UnityEngine;
using UnityEngine.InputSystem;

public enum ControlScheme { KeyboardAndMouse, GamePad }

public class InputHandler : MonoBehaviour
{
    private PlayerControls playerControls;
    private PlayerInput playerInput;

    public float movementHorizontal { get; private set; }
    public float movementVertical { get; private set; }
    public float rotationDirection { get; private set; }

    public float cameraHorizontal { get; private set; }
    public float cameraVertical { get; private set; }

    public bool cameraLockButtonPressed { get; private set; }
    public bool normalInteractButtonPressed { get { return playerControls.GamePlay.NormalInteraction.triggered; } }
    public bool specialInteractButtonPressed { get { return playerControls.GamePlay.SpecialInteraction.triggered; } }
    public bool interruptButtonPressed { get { return playerControls.GamePlay.Interrupt.triggered; } }
    public bool pauseButtonPressed { get { return playerControls.GamePlay.Pause.triggered; } }
    public bool craftButtonPressed { get { return playerControls.GamePlay.Craft.triggered; } }
    public ControlScheme currentControlScheme { get; private set; }
    public bool attackButtonPressed { get { return playerControls.GamePlay.Attack.triggered; } }

    public Vector2 mousePosition { get { return playerControls.GamePlay.MousePosition.ReadValue<Vector2>(); } }

    //public bool coverButtonPressed { get; private set; }
    //public bool dodgeButtonPressed { get { return playerControls.GamePlay.Dodge.triggered; } }
    //public bool jumpButtonPressed { get { return playerControls.GamePlay.Jump.triggered; } }
    //public bool leanButtonPressed { get { return playerControls.GamePlay.Lean.triggered; } }
    //public bool interactButtonPressed { get { return playerControls.GamePlay.Interact.triggered; } }

    public PlayerControls GetPlayerControls()
    {
        return playerControls;
    }

  
    private void SetPlayerControls()
    {
        playerControls.GamePlay.Enable();
        SetGamePlayCallbacks();
    }

    public void Init()
    {
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
        SetPlayerControls();
    }

    private void SetGamePlayCallbacks()
    {
        playerInput.onControlsChanged += OnControlsChanged;

        //MOVEMENT
        playerControls.GamePlay.Movement.performed += ctx =>
        {
            movementHorizontal = playerControls.GamePlay.Movement.ReadValue<Vector2>().x;
            movementVertical = playerControls.GamePlay.Movement.ReadValue<Vector2>().y;
        };
        playerControls.GamePlay.Movement.canceled += ctx => { movementHorizontal = 0; movementVertical = 0; };

        //CAMERA
        playerControls.GamePlay.Look.performed += ctx =>
        {
            cameraHorizontal = Mathf.Clamp(playerControls.GamePlay.Look.ReadValue<Vector2>().x, -1, 1);//camera horizontal value
            cameraVertical = Mathf.Clamp(playerControls.GamePlay.Look.ReadValue<Vector2>().y, -1, 1);//camera vertical input
        };
        playerControls.GamePlay.Look.canceled += ctx => { cameraHorizontal = 0; cameraVertical = 0; };

        playerControls.GamePlay.CameraLock.started += ctx => cameraLockButtonPressed = true;
        playerControls.GamePlay.CameraLock.canceled += ctx => cameraLockButtonPressed = false;
    }

    private void OnControlsChanged(PlayerInput obj)
    {
        if (obj.currentControlScheme.Equals("KeyboardAndMouse"))
            currentControlScheme = ControlScheme.KeyboardAndMouse;
        else
            currentControlScheme = ControlScheme.GamePad;
    }

    private void EnableAllInputs()
    {
        playerControls.GamePlay.Enable();
    }

    private void DisableAllInputs()
    {
        playerControls.GamePlay.Disable();
    }
}