using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{

    #region Attributs

    private bool isPaused = false; // Permet de savoir si le jeu est en pause ou non.
    public Font font;
    #endregion

    #region Proprietes
    #endregion

    #region Constructeur
    #endregion

    #region Methodes

    void Start()
    {

    }


    void Update()
    {
        // Si le joueur appuis sur Echap alors la valeur de isPaused devient le contraire.
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;
        if (isPaused)
            Time.timeScale = 0f; // Le temps s'arrete
        else
            Time.timeScale = 1.0f; // Le temps reprend
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("button"));
        myStyle.fontSize = 32;
        myStyle.font = font;
        if (isPaused)
        {
            // Si le bouton est présser alors isPaused devient faux donc le jeu reprend.
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 160, 400, 100), "C o n t i n u e", myStyle))
            {
                isPaused = false;
            }
            // Si le bouton est présser alors on ferme completement le jeu ou charge la scene "Menu Principal
            // Dans le cas du bouton quitter il faut augmenter sa postion Y pour qu'il soit plus bas
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 40, 400, 100), "M e n u", myStyle))
            {
                // Application.Quit(); 
                Application.LoadLevel("menu");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 100, 400, 100), "Q u i t", myStyle))
            {
                Application.Quit();
            }

        }
    }

    #endregion
}