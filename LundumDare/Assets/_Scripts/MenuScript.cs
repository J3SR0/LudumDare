using UnityEngine;

/// <summary>
/// Script de l'écran titre
/// </summary>
/// 

public class MenuScript : MonoBehaviour
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
              Screen.width / 2 - (400 / 2),
              (2 * Screen.height / 3) - 300,
              400,
              100
            ),
            "P l a y",
            myStyle
          )
        )
            // Sur le clic, on démarre le premier niveau
            // "Stage1" est le nom de la première scène que nous avons créés.
            Application.LoadLevel("Standard");

        if (
            GUI.Button(
            // Centré en x, 2/3 en y
            new Rect(
                Screen.width / 2 - (400 / 2),
                (2 * Screen.height / 3) - 150,
                400,
                100
                ),
        "R u l e s",
        myStyle
        )
       )
            // Sur le clic, on démarre le premier niveau
            // "Stage1" est le nom de la première scène que nous avons créés.
            Application.LoadLevel("SplashScreen-1");
        if (
             GUI.Button(
             // Centré en x, 2/3 en y
             new Rect(
                  Screen.width / 2 - (400 / 2),
                  (2 * Screen.height / 3) - 0,
                  400,
                  100
                ),
                "Q u i t",
                myStyle
              )
            )
        {
            Application.Quit();
        }
    }
}