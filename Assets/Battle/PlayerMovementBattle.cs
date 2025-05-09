using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementBattle : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private float speed = 5f;

    public bool IsCanMove { get; private set; } = true;

    private Vector2 input;
    private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();

        inputActions.Player.Move.performed += ctx =>
        {
            input = ctx.ReadValue<Vector2>();
            OnMove();
        };

        inputActions.Player.Move.canceled += ctx =>
        {
            input = Vector2.zero;
            OnMove();
        };
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= ctx => { input = ctx.ReadValue<Vector2>(); OnMove(); };
        inputActions.Player.Move.canceled -= ctx => { input = Vector2.zero; OnMove(); };
        inputActions.Player.Disable();
    }

    private void OnMove()
    {
        if (IsCanMove)
        {
            rigidbody2D.linearVelocity = input * speed;
        }
        else
        {
            rigidbody2D.linearVelocity = Vector2.zero;
        }
    }

    public Vector2 GetPlayerVelocity()
    {
        return rigidbody2D.linearVelocity;
    }

    public void SetPlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    public void EnablePlayerMovement()
    {
        IsCanMove = true;
    }

    public void DisablePlayerMovement()
    {
        input = Vector2.zero;
        rigidbody2D.linearVelocity = Vector2.zero;
        IsCanMove = false;
    }
}
