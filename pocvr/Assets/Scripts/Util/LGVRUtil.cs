﻿using UnityEngine;
using System.Collections;

public static class LGVRUtil {
    public static bool isDebugActive = true;

    public static void Log(string message)
    {
        if (isDebugActive)
        {
            Debug.Log(message);
        }
    }
}
