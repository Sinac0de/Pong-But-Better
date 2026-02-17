using UnityEngine;

public class InputManager : MonoBehaviour {
    public static InputManager Instance { get; private set; }

    private GameInputActions inputActions;

    private float moveInput;
    private Vector2 touchPosition;

    public float MoveInput => moveInput;
    public Vector2 TouchPosition => touchPosition;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }

        inputActions = new GameInputActions();
    }


    private void OnEnable() {
        inputActions.Enable();


        inputActions.GamePlay.Move.performed += ctx => {
            moveInput = ctx.ReadValue<float>();
        };

        inputActions.GamePlay.Move.canceled += ctx => {
            moveInput = 0f;
        };

        inputActions.GamePlay.TouchPosition.performed += ctx => {
            touchPosition = ctx.ReadValue<Vector2>();
        };
    }


    private void OnDisable() {
        inputActions.Disable();
    }


}
