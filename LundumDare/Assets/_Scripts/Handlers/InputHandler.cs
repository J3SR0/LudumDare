using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

	//[DEBUG]
	public bool debug = true;

	// Cooldowns
	private float dashCD = 0.3f;

	//Raw Input
	public float h = 0;
	public float v = 0;
	public float mouseX = 0;
	public float mouseY = 0;
	public bool jump = false;
	public bool fire = false;
	public bool fire2 = false;
	public bool dashLeft = false;
	public bool dashRight = false;

	private float leftCD = 0;
	private float rightCD = 0;
	private int rightCount = 0;
	private int leftCount = 0;

	// Use this for initialization
	void Start () {
		leftCD = dashCD;
		rightCD = dashCD;
	}
	
	// Update is called once per frame
	void Update () {
		getInput();
		dashHandler();
		coolDownHandler();
		//customDebug();
	}

	void getInput() {
		//h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		mouseX = Input.GetAxis("Mouse X");
		mouseY = Input.GetAxis("Mouse Y");

		h = 0;
		if (Input.GetAxis("Jump") == 0) {
			jump = false;
		} else {
			jump = true;
		}

		if (Input.GetAxis("Fire1") == 0){
			fire = false;
		} else {
			fire = true;
			h = -1;
		}

		if (Input.GetAxis("Fire2") == 0){
			fire2 = false;
		} else {
			fire2 = true;
			h = 1;
		}
	}

	void dashHandler() {
		dashLeft = false;
		dashRight = false;
		if (Input.GetKeyDown("e") || Input.GetMouseButtonDown(0)) {
			if (leftCD > 0 && leftCount == 1) {
				//LEFT DASH
				dashLeft = true;
			} else {
				leftCD = dashCD;
				leftCount += 1;
			}
		}

		if (Input.GetKeyDown("r") || Input.GetMouseButtonDown(1)) {
			if (rightCD > 0 && rightCount == 1) {
				// RIGHT DASH
				dashRight = true;
			} else {
				rightCD = dashCD;
				rightCount += 1;			
			}
		} 
	}

	void coolDownHandler() {
		if (leftCD > 0) {
			leftCD -= 1 * Time.deltaTime;
		} else {
			leftCount = 0;
		}

		if (rightCD > 0) {
			rightCD -= 1 * Time.deltaTime;
		} else {
			rightCount = 0;
		}
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
		if (dashLeft)
			Debug.Log("Dash LEFT");
		if (dashRight)
			Debug.Log("Dash RIGHT");
	}
}
