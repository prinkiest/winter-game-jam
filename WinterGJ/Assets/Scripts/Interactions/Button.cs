using UnityEngine;

public class Button : Interactable
{
    public ButtonChangeState obj;

    public override void Interact()
    {
        obj.ChangeState();
    }
}
