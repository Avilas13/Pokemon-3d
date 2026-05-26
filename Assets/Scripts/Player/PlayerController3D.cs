using UnityEngine;

namespace Pokemon3D.Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerController3D : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float sprintMultiplier = 1.65f;
        [SerializeField] private float jumpForce = 6f;
        [SerializeField] private float gravity = -20f;

        private CharacterController _controller = default!;
        private float _verticalVelocity;

        private void Awake() => _controller = GetComponent<CharacterController>();

        private void Update()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            var speed = Input.GetKey(KeyCode.LeftShift) ? moveSpeed * sprintMultiplier : moveSpeed;

            if (_controller.isGrounded && _verticalVelocity < 0f)
            {
                _verticalVelocity = -1f;
            }

            if (Input.GetButtonDown("Jump") && _controller.isGrounded)
            {
                _verticalVelocity = jumpForce;
            }

            _verticalVelocity += gravity * Time.deltaTime;
            move.y = _verticalVelocity;

            // Climbing/swimming can override this through state handlers.
            _controller.Move(transform.TransformDirection(move) * speed * Time.deltaTime);
        }
    }
}
