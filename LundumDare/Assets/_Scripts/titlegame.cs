using UnityEngine;

/// <summary>
/// Script de l'écran titre
/// </summary>
/// 

public class titlegame : MonoBehaviour
{
    public Font font;
    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("label"));
        myStyle.fontSize = 40;
        myStyle.font = font;
        GUIStyle myStyle1 = new GUIStyle(GUI.skin.GetStyle("label"));
        myStyle1.fontSize = 20;
        myStyle1.font = font;
        GUI.Label(new Rect(Screen.width / 2 - (300 / 2), (2 * Screen.height / 3) - 500, 600, 200), "D E V   B Y", myStyle);
        GUI.Label(new Rect(Screen.width / 2 - (150 / 2), (2 * Screen.height / 3) - 300, 300, 100), "H E U S E   G", myStyle1);
        GUI.Label(new Rect(Screen.width / 2 - (150 / 2), (2 * Screen.height / 3) - 200, 300, 100), "M A G N E   W", myStyle1);
        GUI.Label(new Rect(Screen.width / 2 - (150 / 2), (2 * Screen.height / 3) - 100, 300, 100), "P A C C A R D   C", myStyle1);
    }
}