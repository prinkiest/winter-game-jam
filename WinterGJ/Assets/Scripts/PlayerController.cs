using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(InputHandler))]
public class PlayerController : MonoBehaviour
{
    #region Gravity

    public Vector3 gravityVector = new Vector3(0, -9.81f, 0);
    Vector3 gravityVelocity = Vector3.zero;

    bool isGrounded => characterController.isGrounded;

    #endregion

    [Header("Physic Variables")]
    public float walkSpeed = 4f;
    public float runSpeed = 6.5f;
    public float crouchSpeed = 2.2f;
    public float laySpeed = 1.7f;

    public float jumpHeight = 2.5f;

    [Header("Mouse Options")]
    public float mouseSensitivity = 20f;
    public Camera cam;

    [Header("Components")]
    private CharacterController characterController;
    private InputHandler inputHandler;

    #region Awake, Start
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        inputHandler = GetComponent<InputHandler>();


        // Subscribe methods
        inputHandler.jumpAction += Jump;
    }

    #endregion

    #region Move Methods
    public void Move(Vector2 input)
    {
        Walk(input);
        Fall();
    }

    void Walk(Vector2 input)
    {
        characterController.Move(transform.TransformDirection(InputDirection(input)) * Time.fixedDeltaTime * walkSpeed);
    }

    void Fall()
    {
        characterController.Move(gravityVelocity * Time.fixedDeltaTime);

        if (!isGrounded)
        {
            gravityVelocity += gravityVector * Time.fixedDeltaTime;
        }
        if (isGrounded && gravityVelocity.magnitude > 5)
        {
            gravityVelocity = Vector3.zero;
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            gravityVelocity = -gravityVector.normalized * jumpHeight;
        }
    }

    #endregion

    #region Mouse


    private float xRotation;

    public void Look(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * mouseSensitivity);
    }

    #endregion

    #region Simplifying Methods
    Vector3 InputDirection(Vector2 input)
    {
        Vector3 dir = Vector3.zero;

        dir.x = input.x;
        dir.z = input.y;

        return dir;
    }

    #endregion
}
