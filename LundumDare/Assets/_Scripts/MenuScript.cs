using UnityEngine;

/// <summary>
/// Script de l'écran titre
/// </summary>
/// 

public class MenuScript : Utility
{

	public AudioSource audioSource;
    public Font font;
    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("button"));
        myStyle.fontSize = 32;
        myStyle.font = font;
        GUIStyle myStyle1 = new GUIStyle(GUI.skin.GetStyle("label"));
        myStyle1.fontSize = 40;
        myStyle1.font = font;
        GUI.Label(new Rect(Screen.width / 2 - (500 / 2), (2 * Screen.height / 3) - 500, 500, 100), "D A S H M A G E D D O N", myStyle1);
        if (GUI.Button(new Rect(Screen.width / 2 - (400 / 2), (2 * Screen.height / 3) - 300, 400, 100), "P l a y", myStyle))
            Application.LoadLevel("StdTerrain");
        if (GUI.Button(new Rect(Screen.width / 2 - (400 / 2), (2 * Screen.height / 3) - 150, 400, 100), "R u l e s", myStyle))
            Application.LoadLevel("SplashScreen-1");
        if (GUI.Button(new Rect(Screen.width / 2 - (400 / 2), (2 * Screen.height / 3) - 0, 400, 100), "Q u i t", myStyle))
            Application.Quit();
    }

	public void Start() {
		audioSource.volume = soundVolume;
	}
}