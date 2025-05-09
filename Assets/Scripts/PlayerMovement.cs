using UnityEngine;
using UnityEngine.InputSystem;

namespace WorldExploring
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float movementSpeed = 2f;

        private Vector2 movementDirection;
        private Animator _animator;

        private const string _horizontal = "Horizontal";
        private const string _vertical = "Vertical";
        private const string _last_horizontal = "LastHorizontal";
        private const string _last_vertical = "LastVertical";

        private InputSystem_Actions inputActions;

        private void Awake()
        {
            inputActions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            inputActions.Player.Enable();
            inputActions.Player.Move.performed += ctx => {
                movementDirection = ctx.ReadValue<Vector2>();
                OnMove(); // викликаємо рух одразу
            };

            inputActions.Player.Move.canceled += ctx => {
                movementDirection = Vector2.zero;
                OnMove(); // скидаємо рух і оновлюємо анімацію
            };
        }

        private void OnDisable()
        {
            inputActions.Player.Move.performed -= ctx => { };
            inputActions.Player.Move.canceled -= ctx => { };
            inputActions.Player.Disable();
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void OnMove()
        {
            rb.linearVelocity = movementDirection * movementSpeed;

            _animator.SetFloat(_horizontal, movementDirection.x);
            _animator.SetFloat(_vertical, movementDirection.y);

            if (movementDirection != Vector2.zero)
            {
                _animator.SetFloat(_last_horizontal, movementDirection.x);
                _animator.SetFloat(_last_vertical, movementDirection.y);
            }
        }
    }
}
