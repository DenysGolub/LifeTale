using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

        private
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        private void FixedUpdate()
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
