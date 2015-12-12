using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

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
		Debug.Log("Mouse X = " + mouseX.ToString());
		Debug.Log("Mouse Y = " + mouseY.ToString());
		Debug.Log("horizontal = " + h.ToString());
		Debug.Log("vertical = " + v.ToString());
	}
}
