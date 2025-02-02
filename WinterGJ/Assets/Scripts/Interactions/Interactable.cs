using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string interactText = "Interact";
    public abstract void Interact();
}