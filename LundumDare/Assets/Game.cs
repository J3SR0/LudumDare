using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	Timer time;
	Player player;

	public float Score;

	// Use this for initialization
	void Start () {
		time = GetComponent<Timer>();
		player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		Score = time.time;
		if (player.health == 0)
			end();
	}

	void end() {
		Debug.Log("Game Ends");
	}
}
