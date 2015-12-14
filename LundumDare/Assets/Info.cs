using UnityEngine;
using System.Collections;

public class Info : MonoBehaviour {
	Rigidbody rb;
	Transform tr;
	ChangeSize size;
	Player playerScript;

	[SerializeField]
	public Transform[] lifes;


	// Use this for initialization
	void Start () {
		playerScript = this.transform.parent.GetComponent<Player>();
		size = GetComponent<ChangeSize>();
		rb = GetComponent<Rigidbody>();
		tr = GetComponent<Transform>();	
	}
	
	// Update is called once per frame
	void Update () {
		updateLife();
	}

	void updateLife() {
		lifes[0].gameObject.active = false;
		lifes[1].gameObject.active = false;
		lifes[2].gameObject.active = false;
		for (int i = 0; i < playerScript.health; ++i) {
			lifes[i].gameObject.active = true;
		}
	}
}
