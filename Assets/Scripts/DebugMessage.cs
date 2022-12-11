using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugMessage
{
    //Custom Colors
    public static string green = "#7fff7b";
    public static string magenta = "#ff4dfc";

    public static void Print(string message, string color = "grey") {
        Debug.Log($"<color={color}>{message}</color>");
    }
}
