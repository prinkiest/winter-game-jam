using UnityEngine;

[RequireComponent(typeof(InputHandler), typeof(PlayerController))]
public class Player : MonoBehaviour
{
    InputHandler m_InputHandler;
    PlayerController m_PlayerController;

    private void Awake()
    {
        m_InputHandler = GetComponent<InputHandler>();
        m_PlayerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        m_PlayerController.Move(m_InputHandler.moveInput);
    }

    private void LateUpdate()
    {
        m_PlayerController.Look(m_InputHandler.lookInput);
    }
}
