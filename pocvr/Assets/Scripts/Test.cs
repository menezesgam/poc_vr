using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        X360ControllerConstants.GetTriggerRight();
        X360ControllerConstants.GetTriggerLeft();
        X360ControllerConstants.GetLeftStickAsVector2();
        X360ControllerConstants.GetRightStickAsVector2();
        X360ControllerConstants.GetBumperLeft();
        X360ControllerConstants.GetBumperRight();

    }
}
