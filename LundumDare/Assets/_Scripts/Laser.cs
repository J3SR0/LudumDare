using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	[SerializeField]
	private GameObject target = null;
	public GameObject Target { set { target = value; } }

	[SerializeField]
	private float speed = 5f;
	public float Speed { get { return speed; } set { speed = value; } }
	[SerializeField]
	private float timerBeforeShot = 2f;
	public float TimeBeforeShot { get { return timerBeforeShot; } set { timerBeforeShot = value; } }

	[SerializeField]
	private float frequency = 0.02f;
	public float Frequency { get { return frequency;} set { frequency = value; } }

	[SerializeField]
	private float coolDown = 10f;
	public float CoolDown { get { return coolDown; } set { coolDown = value; } }

	public GameObject GameObject { get { return gameObject; } }

	void Start () {
		timerBeforeShot += Time.time;
	}
		
	void Update () {
		float currentTime = Time.time;
		if (currentTime >= timerBeforeShot) {
			Shoot ();
			if (currentTime >= timerBeforeShot + 1f)
				Destroy (gameObject);
		}
		else if (target != null)
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x, transform.position.y), speed * Time.deltaTime);
	}

	private void Shoot() {
		transform.localPosition = new Vector3(transform.localPosition.x, -19f, 0);
	}
		
}
