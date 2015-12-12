using UnityEngine;
using System.Collections;

public class Player : Character {

	private float h;
	private float v;

	// Use this for initialization
	public override void Start () {
		base.input = this.transform.parent.parent.GetComponent<InputHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		base.input.customDebug();
	}

	public override void Move () {
		h = base.input.h;
		v = base.input.v;
		if (h < 0) {
			Debug.Log("LEL");
		} else if (h > 0) {
			Debug.Log("LOL");
		}
	}

	public override void Attack () {

	}
}
