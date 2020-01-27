using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSettings {

    private static float lookSensitivity = 2f;

    private static string lungeButton = "space";
    private static string showAimButton = "f";

    static void Start () {
		
	}
	
	static void Update () {
		
	}


    public static float getLookSensitivity()
    {
        return lookSensitivity;
    }

    public static void setLookSensitivity(float newValue)
    {
        lookSensitivity = newValue;
    }


    public static string getLungeButton()
    {
        return lungeButton;
    }

    public static void setLungeButton(string newValue)
    {
        lungeButton = newValue;
    }


    public static string getShowAimButton()
    {
        return showAimButton;
    }

    public static void setShowAimButton(string newValue)
    {
        showAimButton = newValue;
    }
}
