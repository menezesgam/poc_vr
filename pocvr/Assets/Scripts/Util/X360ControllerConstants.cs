using UnityEngine;
using System.Collections;

/*
    Static class to store axises and buttons mapping constants to a xbox360 controller.
    For reference see: http://wiki.unity3d.com/index.php?title=Xbox360Controller [Link acessed on 10/20/2015]
    Use Edit > Project Settings > Input to define input 
*/
public static class X360ControllerConstants
{

    /* AXISES */
    //LEFT
    public const string LEFT_STICK_X = "Horizontal";
    public const string LEFT_STICK_Y = "Vertical";
    public const string LEFT_TRIGGER = "TriggerLeft";

    //RIGHT
    public const string RIGHT_STICK_X = "HorizontalRight";
    public const string RIGHT_STICK_Y = "VerticalRight";
    public const string RIGHT_TRIGGER = "TriggerRight";

    /* BUTTONS */
    //LEFT
    public const string LEFT_BUMPER = "BumperLeft";

    //RIGHT
    public const string RIGHT_BUMPER = "BumperRight";

    //Utility
    public const string BACK_BUTTON = "BackButton";
    public const string START_BUTTON = "StartButton";
    //LEFT---------------------------------------------------------------------------------------------------------//

    public static float GetLeftStickX()
    {
        float value = Input.GetAxis(LEFT_STICK_X);
        LGVRUtil.Log("GetLeftStickX :: " + value);
        return value;
    }

    public static float GetLeftStickY()
    {
        float value = Input.GetAxis(LEFT_STICK_Y);
        LGVRUtil.Log("GetLeftStickY :: " + value);
        return value;
    }

    /*
        Get Left stick value [horizontal, vertical]
    */
    public static Vector2 GetLeftStickAsVector2()
    {
        Vector2 value = new Vector2(GetLeftStickX(), GetLeftStickY());
        LGVRUtil.Log("GetLeftStickAsVector2 :: " + value);
        return value;
    }

    public static float GetTriggerLeft()
    {
        float value = Input.GetAxis(LEFT_TRIGGER);
        LGVRUtil.Log("GetTriggerLeft :: " + value);
        return value;
    }

    public static bool GetBumperLeft()
    {
        bool value = Input.GetButton(LEFT_BUMPER);
        LGVRUtil.Log("GetBumperLeft :: " + value);
        return value;
    }


    //RIGHT---------------------------------------------------------------------------------------------------------//

    public static float GetRightStickX()
    {
        float value = Input.GetAxis(RIGHT_STICK_X);
        LGVRUtil.Log("GetRightStickX :: " + value);
        return value;
    }

    public static float GetRightStickY()
    {
        float value = Input.GetAxis(RIGHT_STICK_Y);
        LGVRUtil.Log("GetRightStickY :: " + value);
        return value;
    }

    /*
        Get Right stick value [horizontal, vertical]
    */
    public static Vector2 GetRightStickAsVector2()
    {
        Vector2 value = new Vector2(GetRightStickX(), GetRightStickY());
        LGVRUtil.Log("GetRightStickAsVector2 :: " + value);
        return value;
    }

    public static float GetTriggerRight()
    {
        float value = Input.GetAxis(RIGHT_TRIGGER);
        LGVRUtil.Log("GetTriggerRight :: " + value);
        return value;
    }

    public static bool GetBumperRight()
    {
        bool value = Input.GetButton(RIGHT_BUMPER);
        LGVRUtil.Log("GetBumperRight :: " + value);
        return value;
    }

    //Utility

    public static bool GetButtonStart()
    {
        bool value = Input.GetButton(START_BUTTON);
        LGVRUtil.Log("GetButtonStart :: " + value);
        return value;
    }

    public static bool GetButtonBack()
    {
        bool value = Input.GetButton(BACK_BUTTON);
        LGVRUtil.Log("GetBackButton :: " + value);
        return value;
    }

}
