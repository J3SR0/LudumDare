﻿using UnityEngine;
using System.Collections;

public class rulesscript : MonoBehaviour {
    public Font font;
    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("label"));
        myStyle.fontSize = 24;
        myStyle.font = font;
        GUIStyle myStyle1 = new GUIStyle(GUI.skin.GetStyle("label"));
        myStyle1.fontSize = 32;
        myStyle1.font = font;
        GUIStyle myStyle2 = new GUIStyle(GUI.skin.GetStyle("label"));
        myStyle2.fontSize = 16;
        GUI.Label(new Rect(Screen.width / 2 - 150, 20, 500, 50), "r u l e s   g a m e s", myStyle1);
        GUI.Label(new Rect(Screen.width / 2 - 30, 100, 500, 30), "G O A L", myStyle);
        GUI.Label(new Rect(Screen.width / 2 - 200, 140, 500, 20), "Stay Small", myStyle2);
        GUI.Label(new Rect(Screen.width / 2 - 200, 170, 500, 20), "Stay Away from the laser", myStyle2);
        GUI.Label(new Rect(Screen.width / 2 - 200, 200, 500, 20), "Stay alive - You have 3 life", myStyle2);
        GUI.Label(new Rect(Screen.width / 2 - 70, 240, 500, 30), "G E T   S E E D", myStyle);
        GUI.Label(new Rect(Screen.width / 2 - 200, 290, 500, 20), "Take GREY seed to stay small", myStyle2);
        GUI.Label(new Rect(Screen.width / 2 - 200, 320, 500, 20), "Take GREEN seed to get a bonus", myStyle2);
        GUI.Label(new Rect(Screen.width / 2 - 200, 350, 500, 20), "Care RED seed give you malus", myStyle2);
        GUI.Label(new Rect(Screen.width / 2 - 50, 390, 500, 30), "C O N T R O L", myStyle);
        GUI.Label(new Rect(Screen.width / 2 - 200, 440, 700, 20), "Press X for left or double X to dash on the left", myStyle2);
        GUI.Label(new Rect(Screen.width / 2 - 200, 470, 700, 20), "Press C for right or double C for dash on the right", myStyle2);
        GUI.Label(new Rect(Screen.width / 2 - 200, 500, 500, 20), "Press ESCAPE to pause", myStyle2);
        GUIStyle myStyle3 = new GUIStyle(GUI.skin.GetStyle("button"));
        myStyle3.fontSize = 24;
        myStyle3.font = font;
        if (GUI.Button( new Rect((Screen.width) - 400, 530, 200, 50),"s k i p", myStyle3))
            Application.LoadLevel("menu");
        if (GUI.Button(new Rect(150, 530, 200, 50), "d e v   b y", myStyle3))
            Application.LoadLevel("SplashScreen-0");
    }
}