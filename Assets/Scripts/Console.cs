using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Console
{
    //Custom Colors
    public static string green = "#7fff7b";
    public static string magenta = "#ff4dfc";
    public static string red = "#ff2c2c";

    public static void Log(string message, string color = "grey") {
        Debug.Log($"<color={color}>{message}</color>");
    }
}
