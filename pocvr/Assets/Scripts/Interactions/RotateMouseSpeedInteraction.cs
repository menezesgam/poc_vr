using UnityEngine;
using System.Collections;
using System;

public class RotateMouseSpeedInteraction : AbstractInteraction<Vector2> {

    protected override Vector2 GetInput()
    {
       return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    public override void Interact(Vector2 input)
    {
        if (!Vector2.zero.Equals(input))
        {
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                transform.Rotate(new Vector3(input.x, 0, 0));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, input.y));
            }
        }
    }

    protected override bool ToggleIsInteracting()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            return !isInteracting;
        }
        else
        {
            return isInteracting;
        }
    }
}
