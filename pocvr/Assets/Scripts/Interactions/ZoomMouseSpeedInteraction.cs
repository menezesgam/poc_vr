using UnityEngine;
using System.Collections;
using System;

public class ZoomMouseSpeedInteraction : AbstractInteraction<float>
{

    public override void Interact(float input)
    {
        Vector3 nextScale = new Vector3(transform.localScale.x + input, transform.localScale.y + input, transform.localScale.z + input);
        transform.localScale = Vector3.Lerp(transform.localScale, nextScale, Time.deltaTime * 0.5f);
    }

    protected override float GetInput()
    {
        return Input.GetAxis("Mouse X");
    }

    protected override bool ToggleIsInteracting()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            return !isInteracting;
        }
        else
        {
            return isInteracting;
        }
    }
}
