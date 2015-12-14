using UnityEngine;
using System.Collections;

public class ChangeSize : MonoBehaviour {
	
	private CollisionDetection collision;
	private Transform tr;
	private float minSize = 1;

	void Awake () {
		tr = GetComponent<Transform>();
		collision = GetComponent<CollisionDetection>();
		Debug.Log("Here");
	}

	// Use this for initialization
	void Start () {
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
		if (this.tr.localScale.y <= minSize)
			return ;
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
