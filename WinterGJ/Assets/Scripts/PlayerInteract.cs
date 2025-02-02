using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerInteract : MonoBehaviour
{
    public float reachDistance = 5f;
    Camera cam;

    InputHandler inputHandler;

    RaycastHit hit;

    // UIController UI;

    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        // UI = GetComponent<UIController>();

        inputHandler.interactAction += TryInteract;
        cam = GetComponent<PlayerController>().cam;
    }
    private void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, reachDistance))
        {
            // UI.UpdateTooltip(hit.collider.gameObject.name);
        }
        else
        {
            // UI.ResetTooltip();
        }
    }

    public void TryInteract()
    {
        if (hit.collider == null)
        {
            return;
        }

        Interactable interactable;
        Debug.Log("Trying to interact...");

        interactable = hit.collider.gameObject.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactable.Interact();
            return;
        }
        Debug.Log("Can't Interact... Missing Interactable Component");
    }
}
