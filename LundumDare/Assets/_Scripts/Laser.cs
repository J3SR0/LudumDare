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
	private float timerBeforeDeath = 5f;

	[SerializeField]
	private float timerBeforeShot = 2f;
	public float TimeBeforeShot { get; set; }

	[SerializeField]
	private float frequency = 0.02f;
	public float Frequency { get; set; }

	[SerializeField]
	private float coolDown = 10f;
	public float CoolDown { get; set; }

	private float originalY, y, myColliderSizeY;

	private GameObject lastCollision = null;

	void Start () {
		originalY = transform.position.y;
		y = originalY;
		myColliderSizeY = GetComponent<Collider> ().bounds.size.y / 2f;
		timerBeforeDeath += Time.time;
		timerBeforeShot += Time.time;
	}
		
	void Update () {
		if (lastCollision != null) {
			if (isTouching()) {
				y = lastCollision.transform.position.y + (lastCollision.GetComponent<Collider> ().bounds.size.y / 2f) + myColliderSizeY;
				transform.position = new Vector2 (transform.position.x, y);
			}
			else {
				y = originalY;
				transform.position = new Vector2 (transform.position.x, y);
			}
		}
		if (target != null)
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x, y), speed * Time.deltaTime);
		if (Time.time >= timerBeforeDeath)
			Destroy (gameObject);
		else if (Time.time >= timerBeforeShot)
			Shoot ();		
	}

	void OnCollisionEnter(Collision collision) {
		lastCollision = collision.gameObject;
	}

	private bool isTouching() {
		float lastCollisionColliderSizeY = lastCollision.GetComponent<Collider> ().bounds.size.y / 2f;
		float lastCollisionColliderSizeX = lastCollision.GetComponent<Collider> ().bounds.size.x / 2f;

		float impactY = transform.position.y - myColliderSizeY - 0.5f;
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
