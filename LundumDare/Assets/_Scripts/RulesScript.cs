using UnityEngine;

/// <summary>
/// Script de l'écran titre
/// </summary>
/// 

public class RulesScript : MonoBehaviour
{
    public Font font;
    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("button"));
        myStyle.fontSize = 32;
        myStyle.font = font;
        if (
          GUI.Button(
            // Centré en x, 2/3 en y
            new Rect(
              (Screen.width) - 400,
              (2 * Screen.height / 3) - -180,
              250,
              100
            ),
            "s k i p",
            myStyle
          )
        )
            // Sur le clic, on démarre le premier niveau
            // "Stage1" est le nom de la première scène que nous avons créés.
            Application.LoadLevel("menu");

        if (
            GUI.Button(
                // Centré en x, 2/3 en y
                new Rect(
                100,
                (2 * Screen.height / 3) - -180,
                250,
                100
              ),
              "d e v    b y",
              myStyle
            )
          )
            // Sur le clic, on démarre le premier niveau
            // "Stage1" est le nom de la première scène que nous avons créés.
            Application.LoadLevel("SplashScreen-0");
    }
}