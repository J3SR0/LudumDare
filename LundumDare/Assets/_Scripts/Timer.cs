using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public string textTime;
	private float startTime;
	public float time = 0;

	void Awake () {
		startTime = Time.time;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		time = Time.time - startTime;
	}

	void OnGUI () {


   	float guiTime = Time.time - startTime;



   	int minutes = (int)guiTime / 60;
   	int seconds = (int)guiTime % 60;
   	int fraction = (int)(guiTime * 100) % 100;


   	textTime = string.Format ("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction); 
   	GUI.Label (new Rect (400, 25, 100, 30), textTime); //changed variable name to textTime -->text is not a good variable name since it has other use already
	}
}
