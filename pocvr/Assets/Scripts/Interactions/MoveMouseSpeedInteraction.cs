using UnityEngine;
using System.Collections;
using System;

public class MoveMouseSpeedInteraction : AbstractInteraction<Vector2> {

    public float moveSpeed = 0.01f;

    public override void Interact(Vector2 input)
    {
        Vector3 test = Vector3.right * moveSpeed * input.x + Vector3.up * moveSpeed * input.y;
        transform.Translate(test, Space.World);
    }

    protected override Vector2 GetInput()
    {
        //Maybe change to Vector3 and use mousewheel to control distance to camera
        return X360ControllerConstants.GetLeftStickAsVector2();
    }

    protected override bool ToggleIsInteracting()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            return !isInteracting;
        }
        else
        {
            return isInteracting;
        }
    }

}
