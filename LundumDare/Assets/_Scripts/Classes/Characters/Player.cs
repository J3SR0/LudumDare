using UnityEngine;
using System.Collections;

public class Player : Character {

	// Use this for initialization
	public override void Start () {
		base.input = this.transform.parent.parent.GetComponent<InputHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		base.input.customDebug();
	}

	public override void Move () {
	}

	public override void Attack () {

	}
}
