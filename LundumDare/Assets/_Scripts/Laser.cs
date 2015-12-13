using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	[SerializeField]
	private GameObject target = null;
	public GameObject Target {
		set {target = value;}
	}
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float liveTime = 5f;
	[SerializeField]
	private float timeBeforeShot = 2f;
	[SerializeField]
	private float frequency;
	public float Frequency {
		get { return frequency; }
	}
	[SerializeField]
	private float coolDown;
	public float CoolDown {
		get { return coolDown;}
	}

	private float originalY, y, deathTime, shootingTime;
	private GameObject lastCollision = null;

	void Start () {
		originalY = transform.position.y;
		y = originalY;
		shootingTime = Time.time + timeBeforeShot;
		deathTime = Time.time + liveTime;
	}
		
	void Update () {
		if (lastCollision != null) {
			if (isTouching()) {
				y = lastCollision.transform.position.y + (lastCollision.GetComponent<Collider> ().bounds.size.y / 2f) + (GetComponent<Collider> ().bounds.size.y / 2f);
				transform.position = new Vector2 (transform.position.x, y);
			}
			else {
				y = originalY;
				transform.position = new Vector2 (transform.position.x, y);
			}
		}
		if (target != null)
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x, y), speed * Time.deltaTime);
		if (Time.time >= deathTime)
			Destroy (gameObject);
		else if (Time.time >= shootingTime)
			Shoot ();		
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("Hey");
		lastCollision = collision.gameObject;
	}

	private bool isTouching() {
		float colliderSizeY = GetComponent<Collider> ().bounds.size.y / 2f;
		float lastCollisionColliderSizeY = lastCollision.GetComponent<Collider> ().bounds.size.y / 2f;
		float lastCollisionColliderSizeX = lastCollision.GetComponent<Collider> ().bounds.size.x / 2f;

		float impactY = transform.position.y - colliderSizeY - 0.5f;
		float realImpactY = lastCollision.transform.position.y + lastCollisionColliderSizeY;
		float leftPoint = lastCollision.transform.position.x - lastCollisionColliderSizeX - 2f;
		float rightPoint = lastCollision.transform.position.x + lastCollisionColliderSizeX + 2f;
		float positionX = transform.position.x;

		if (!(impactY <= realImpactY && leftPoint <= positionX && positionX <= rightPoint))
			return false;
		else
			return true;
	}

	private void Shoot() {
		Debug.Log ("Shot!");
	}
		
}
