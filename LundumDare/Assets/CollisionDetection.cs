using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {
	Rigidbody rb;
	Transform tr;
	Player playerScript;

	public Transform LeftWall;
	public Transform RightWall;

	// Use this for initialization
	void Start () {
		playerScript = this.transform.parent.GetComponent<Player>();
		rb = GetComponent<Rigidbody>();
		tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		LWCollision();
		RWCollision();
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Floor") {
			playerScript.isGrounded = true;
		}
	}

	public bool LWCollision() {
		Bounds wall = LeftWall.GetComponent<Renderer>().bounds;
		Bounds target = tr.GetComponent<Renderer>().bounds;
		if (target.Intersects(wall)) {
			//Debug.Log("Youpi");
			return true;
		}
		return false;
	}

	public bool RWCollision() {
		Bounds wall = RightWall.GetComponent<Renderer>().bounds;
		Bounds target = tr.GetComponent<Renderer>().bounds;
		if (target.Intersects(wall)) {
			//Debug.Log("Youpla");
			return true;
		}
		return false;
	}
}
