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
    public const string LEFT_TRIGGER = "LeftTrigger";

    //RIGHT
    public const string RIGHT_STICK_X = "HorizontalRight";
    public const string RIGHT_STICK_Y = "VerticalRight";
    public const string RIGHT_TRIGGER = "RightTrigger";
    /* BUTTONS */




    //LEFT---------------------------------------------------------------------------------------------------------//

    /*
        Get Left stick horizontal value
    */
    public static float GetLeftStickX()
    {
        float value = Input.GetAxis(LEFT_STICK_X);
        LGVRUtil.Log("GetLeftStickX :: " + value);
        return value;
    }

    /*
        Get Left stick vertical value
    */
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

    /*
        Get Left Trigger value
    */
    public static float GetLeftTrigger()
    {
        float value = Input.GetAxis(LEFT_TRIGGER);
        LGVRUtil.Log("GetLeftTrigger :: " + value);
        return value;
    }

    //RIGHT---------------------------------------------------------------------------------------------------------//

    /*
        Get Right stick horizontal value
    */
    public static float GetRightStickX()
    {
        return Input.GetAxis(RIGHT_STICK_X);
    }

    /*
        Get Right stick vertical value
    */
    public static float GetRightStickY()
    {
        return Input.GetAxis(RIGHT_STICK_Y);
    }

    /*
        Get Right stick value [horizontal, vertical]
    */
    public static Vector2 GetRightStickAsVector2()
    {
        return new Vector2(GetRightStickX(), GetRightStickY());
    }




}
