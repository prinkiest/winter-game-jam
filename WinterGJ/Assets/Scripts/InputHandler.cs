using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;
using UnityEngine.InputSystem.XR;

public class InputHandler : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerInput.PlayerActions playerActions;
    PlayerInput.UIActions uiActions;


    private void Awake()
    {
        playerInput = new PlayerInput();
        playerActions = playerInput.Player;
        uiActions = playerInput.UI;

    }

    public Vector2 moveInput { get; private set; }
    public Vector2 lookInput { get; private set; }
    public bool isShooting { get; private set; }
    private void Update()
    {
        #region Movement
        moveInput = playerActions.Move.ReadValue<Vector2>();
        lookInput = playerActions.Look.ReadValue<Vector2>();

        #endregion
        #region Shooting
        isShooting = playerActions.Attack.IsPressed();

        #endregion
    }

    private void OnEnable()
    {
        playerActions.Enable();

        playerActions.Jump.performed += ctx => OnJump();
        playerActions.WorldInteract.performed += ctx => OnInteract();
        //playerActions.Attack.performed += ctx => OnShoot();

        // UI

        uiActions.Enable();

    }

    private void OnDisable()
    {
        playerActions.Disable();

        playerActions.Jump.performed -= ctx => OnJump();
        playerActions.WorldInteract.performed -= ctx => OnInteract();
        //playerActions.Attack.performed -= ctx => OnShoot();

        // UI

        uiActions.Disable();

    }

    #region Movement Actions
    public Action jumpAction;

    public void OnJump()
    {
        Debug.Log("Jump");
        jumpAction.Invoke();
    }
    #endregion

    #region Interact Actions

    public Action interactAction;

    public void OnInteract()
    {
        Debug.Log("Invoking interact");
        interactAction.Invoke();
    }

    #endregion

    /*#region Shoot Actions

    public Action shootAction;

    public void OnShoot()
    {
        Debug.Log("Invoking shooting");
        shootAction.Invoke();
    }

    #endregion*/
}