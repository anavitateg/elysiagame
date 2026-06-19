using UnityEngine;
using UnityEngine.InputSystem;

namespace Elysia.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float            moveSpeed  = 5f;
        [SerializeField] float            jumpForce  = 6f;
        [SerializeField] float            gravity    = -20f;
        [SerializeField] InputActionAsset inputActions;

        CharacterController cc;
        InputAction         moveAction;
        InputAction         jumpAction;
        Vector3             velocity;

        void Awake()
        {
            cc = GetComponent<CharacterController>();

            var playerMap = inputActions.FindActionMap("Player", throwIfNotFound: true);
            moveAction    = playerMap.FindAction("Move", throwIfNotFound: true);
            jumpAction    = playerMap.FindAction("Jump", throwIfNotFound: true);
        }

        void OnEnable()
        {
            moveAction.Enable();
            jumpAction.Enable();
        }

        void OnDisable()
        {
            moveAction.Disable();
            jumpAction.Disable();
        }

        void Update()
        {
            Vector2 input = moveAction.ReadValue<Vector2>();
            Vector3 move  = new Vector3(input.x, 0f, input.y);
            cc.Move(move * moveSpeed * Time.deltaTime);

            // Gravity accumulation
            if (cc.isGrounded && velocity.y < 0f)
                velocity.y = -2f;

            if (jumpAction.WasPressedThisFrame() && cc.isGrounded)
                velocity.y = jumpForce;

            velocity.y += gravity * Time.deltaTime;
            cc.Move(velocity * Time.deltaTime);
        }
    }
}
