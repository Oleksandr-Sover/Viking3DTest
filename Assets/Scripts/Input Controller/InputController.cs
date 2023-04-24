using UnityEngine;
using UnityEngine.InputSystem;

namespace GameLogic
{
    public class InputController : MonoBehaviour, IInputController
    {
        ILocalPlayerData LocalPlayerData;

        PlayerInput playerInput;

        public Vector2 Move { get; private set; }
        public Vector2 Look { get; private set; }
        public float InputMagnitude { get => LocalPlayerData.PlayerData.AnalogMovement ? Move.magnitude : 1f; }
        public float DeltaTimeMultiplier { get => IsCurrentDeviceMouse ? 1.0f : Time.deltaTime; }
        public bool Sprint { get; private set; }
        public bool Attack { get => playerInput.actions[attackAction].ReadValue<float>() > 0; }
        public bool IsCurrentDeviceMouse { get => isCurrentDeviceMouse; }

        readonly string keyboardMouseControl = "KeyboardMouse";
        readonly string attackAction = "Attack";

        bool isCurrentDeviceMouse;

        void Awake()
        {
            LocalPlayerData = GetComponent<ILocalPlayerData>();
            playerInput = GetComponent<PlayerInput>();
        }

        void Start()
        {
            isCurrentDeviceMouse = playerInput.currentControlScheme == keyboardMouseControl;
        }

        public void OnMove(InputValue value) => Move = value.Get<Vector2>();

        public void OnSprint(InputValue value) => Sprint = value.isPressed;

        public void OnLook(InputValue value)
        {
            if (LocalPlayerData.PlayerData.CursorInputForLook) 
                Look = value.Get<Vector2>();
        }

        void OnApplicationFocus(bool hasFocus) => Cursor.lockState = LocalPlayerData.PlayerData.CursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }
}