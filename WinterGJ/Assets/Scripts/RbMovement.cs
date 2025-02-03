using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class RbMovement : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerInput.PlayerActions playerActions;
    PlayerInput.UIActions uiActions;

    [SerializeField] bool canMove;
    [SerializeField] float speed;
    Vector2 playerDir;
    GameObject playerObj;
    Rigidbody rb;

    Vector3 inputVector;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerActions = playerInput.Player;
        uiActions = playerInput.UI;

        playerObj = this.gameObject;
        rb = playerObj.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerActions.Enable();
        playerActions.Move.performed += ctx => OnMoveButton(ctx.ReadValue<Vector2>());

    }

    private void OnDisable()
    {
        playerActions.Move.performed -= ctx => OnMoveButton(ctx.ReadValue<Vector2>());
        playerActions.Disable();
    }

    private void Update()
    {
        inputVector = new Vector3(playerDir.x, 0, playerDir.y);

        // rotate the player to the direction the camera's forward
        playerObj.transform.eulerAngles = new Vector3(playerObj.transform.eulerAngles.x,
        Camera.main.transform.eulerAngles.y, playerObj.transform.eulerAngles.z);

        // "translate" the input vector to player coordinates
        inputVector = playerObj.transform.TransformDirection(inputVector);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = inputVector * speed;
    }

    private void OnMoveButton(Vector2 direction)
    {
        if (canMove)
        {
            playerDir = direction;
        }

    }

}
