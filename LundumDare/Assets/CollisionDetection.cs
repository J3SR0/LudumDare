using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {
	Rigidbody rb;
	Transform tr;
	ChangeSize size;
	Player playerScript;
	Vector3 velSave;

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
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Laser") {
			Vector3 lPos = other.gameObject.transform.position;
			lPos.y += 15;
			other.gameObject.transform.position = lPos;
			//Debug.Log("Laser");
			playerScript.health -= 1;
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
