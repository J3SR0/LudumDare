using UnityEngine;
using System.Collections;

public class CollisionDetection : Utility {
	Rigidbody rb;
	Transform tr;
	ChangeSize size;
	Player playerScript;
	Vector3 velSave;

	private bool invicibility = false;
	private float invicibilityTime;

	public Transform LeftWall;
	public Transform RightWall;
	public Transform Floor;

	// Use this for initialization
	void Start () {
		playerScript = this.transform.parent.GetComponent<Player>();
		size = GetComponent<ChangeSize>();
		rb = GetComponent<Rigidbody>();
		tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		velSave = rb.velocity;
		if (Time.time >= invicibilityTime)
			invicibility = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Laser" && !invicibility) {
			blink (gameObject, 0.1f, 0.01f, 0.1f, 0.01f, 1f);
			invicibility = true;
			invicibilityTime = Time.time + 1f;
			other.gameObject.transform.position = new Vector3 (other.gameObject.transform.position.x, other.gameObject.transform.position.y + GetComponent<Collider> ().bounds.size.y, 0);
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Seed") {
			Destroy(col.gameObject);
			rb.velocity = velSave;
			size.shrink();
		} else if (col.gameObject.tag == "Buff") {
			Destroy(col.gameObject);
			rb.velocity = velSave;
			//Debug.Log("Buff");
		} else if (col.gameObject.tag == "Debuff") {
			Destroy(col.gameObject);
			rb.velocity = velSave;
			//Debug.Log("Debuff");
		}
	}

	public bool LWCollision() {
		Bounds wall = LeftWall.GetComponent<Renderer>().bounds;
		Bounds target = tr.GetComponent<Renderer>().bounds;
		if (target.Intersects(wall)) {
			return true;
		}
		return false;
	}

	public bool RWCollision() {
		Bounds wall = RightWall.GetComponent<Renderer>().bounds;
		Bounds target = tr.GetComponent<Renderer>().bounds;
		if (target.Intersects(wall)) {
			return true;
		}
		return false;
	}

	public bool FCollision() {
		Bounds floor = Floor.GetComponent<Renderer>().bounds;
		Bounds target = tr.GetComponent<Renderer>().bounds;
		if (target.Intersects(floor)) {
			return true;
		}
		return false;
	}
}
