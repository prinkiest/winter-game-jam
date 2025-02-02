using UnityEngine;

public class Lift : ButtonChangeState
{
    public Transform floor0;
    public Transform floor1;

    public bool isGroundFloor;

    // TODO плавная анимация лифта
    public override void ChangeState()
    {
        if (isGroundFloor)
        {
            gameObject.transform.position = floor1.position;
        }
        else
        {
            gameObject.transform.position = floor0.position;
        }
        isGroundFloor = !isGroundFloor;
    }
}
