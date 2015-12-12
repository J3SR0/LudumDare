using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

	//[DEBUG]
	public bool debug = false;

	//Raw Input
	public float h = 0;
	public float v = 0;
	public float mouseX = 0;
	public float mouseY = 0;
	public bool Jump = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		mouseX = Input.GetAxis("Mouse X");
		mouseY = Input.GetAxis("Mouse Y");
		if (debug)
			customDebug();
	}

	// Prints values in the Console
	public void customDebug () {
		if (mouseX != 0)
			Debug.Log("Mouse X = " + mouseX.ToString());
		if (mouseY != 0)
			Debug.Log("Mouse Y = " + mouseY.ToString());
		if (h != 0)
			Debug.Log("horizontal = " + h.ToString());
		if (v != 0)
			Debug.Log("vertical = " + v.ToString());
	}
}
