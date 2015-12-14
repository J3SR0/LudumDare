using UnityEngine;
using System.Collections;

public class Game : Utility {

	Timer time;
	Player player;
	public bool gameOver;
	public bool restart;

	public string Score;

	public AudioSource audioSource;

	public GUIText ScoreText;
	public GUIText RestartText;
	public GUIText GameOverText;
    public Font font;
    public Font font1;

    void Awake () {

    }

    // Use this for initialization
    void Start () {
		audioSource.volume = soundVolume;
		gameOver = false;
		restart = false;
		time = GetComponent<Timer>();
		player = GameObject.Find("Player").GetComponent<Player>();
		StartCoroutine(growOverTime());
	}
	
	// Update is called once per frame
	void Update () {
		if (player.health <= 0) {
			if (!gameOver) {
				Score = time.textTime;
			}
			end();
		}
	}

	void end() {
		gameOver = true;
	}

	void OnGUI() {
        GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("button"));
        myStyle.fontSize = 32;
        GUIStyle myLabel = new GUIStyle(GUI.skin.GetStyle("label"));
        myLabel.fontSize = 32;
        GUIStyle myStyle1 = new GUIStyle(GUI.skin.GetStyle("button"));
        myStyle1.fontSize = 22;
        myStyle1.font = font1;
        if (gameOver) {
            GUI.Label(new Rect(Screen.width - 370, 45 , 200, 100), "Your time :", myLabel);
            Time.timeScale = 0f;
            GUI.Button (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 200,  400, 100), "G A M E   O V E R", myStyle);

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 40, 200, 50), "R e s t a r t", myStyle1))
            {
            	//player.childTr.Clear();
                Application.LoadLevel(Application.loadedLevel);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 20, 200, 50), "M e n u", myStyle1))
            {
                Application.LoadLevel("menu");
            }
        }
	}

	IEnumerator growOverTime() {
		while (!gameOver) {
			player.growOverTime();
			yield return new WaitForSeconds(1);
		}
	}
}
