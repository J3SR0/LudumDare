using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	Timer time;
	Player player;
	public bool gameOver;
	public bool restart;

	public string Score;

	public GUIText ScoreText;
	public GUIText RestartText;
	public GUIText GameOverText;
    public Font font;

	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		time = GetComponent<Timer>();
		player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.health <= 0) {
			if (!gameOver)
				Score = time.textTime;
			end();
		}
	}

	void end() {
		gameOver = true;
	}

	void OnGUI() {
        GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("button"));
        myStyle.fontSize = 32;
        myStyle.font = font;
		if (gameOver) {
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50,  400, 100), "GAME OVER");

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 40, 400, 100), "R e s t a r t", myStyle))
            {
                Application.LoadLevel("StdTerrain");
            }

		}
	}
}
