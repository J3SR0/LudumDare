

function OnGUI() {

    if (GUI.Button(Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 200, 50), "Jouer")) {
        Application.LoadLevel("Level 1");
    }

    if (GUI.Button(Rect(Screen.width / 2 - 100, Screen.height / 2 - 20, 200, 50), "Instructions")) {

    }

    if (GUI.Button(Rect(Screen.width / 2 - 100, Screen.height / 2 - -40, 200, 50), "Quitter")) {
        Application.Quit();

    }

}
