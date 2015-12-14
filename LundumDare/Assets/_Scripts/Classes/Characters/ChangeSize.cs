using UnityEngine;
using System.Collections;

public class ChangeSize : Utility {
	
	private CollisionDetection collision;
	private Transform tr;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();
		collision = GetComponent<CollisionDetection>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void grow() {
		Vector3 scale = this.tr.localScale;
		Vector3 position = this.tr.position;

		position.y += 0.5f;
		scale.x += 1;
		scale.y += 1;

		if (collision.LWCollision()) {
			position.x += 0.5f;
		} else if (collision.RWCollision()) {
			position.x -= 0.5f;
		}
		this.tr.position = position;
		this.tr.localScale = scale;
	}

	public void shrink() {
		Vector3 scale = this.tr.localScale;
		Vector3 position = this.tr.position;

		position.y -= 0.5f;
		scale.x -= 1;
		scale.y -= 1;

		if (collision.LWCollision()) {
			position.x += 0.5f;
		} else if (collision.RWCollision()) {
			position.x -= 0.5f;
		}
		this.tr.position = position;
		this.tr.localScale = scale;		
	}
}
