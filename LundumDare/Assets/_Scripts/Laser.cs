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

	[SerializeField]
	private float coolDownReducer = 0.05f;
	public float CoolDownReducer { get { return coolDown; } set { coolDown = value; } }

	public GameObject GameObject { get { return gameObject; } }

	private bool shooting = false;

	void Start () {
		target =  GameObject.Find ("Cube");
		timerBeforeShot += Time.timeSinceLevelLoad;
	}
		
	void Update () {
		float currentTime = Time.timeSinceLevelLoad;
		if (currentTime >= timerBeforeShot && !shooting)
			Shoot ();
		else if (currentTime >= timerBeforeShot + 1f)
			Destroy (gameObject);
		else if (target != null && !shooting)
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x, transform.position.y), speed * Time.deltaTime);
	}

	private void Shoot() {
		transform.localPosition = new Vector3(transform.localPosition.x, -19f, 0);
		shooting = true;
	}

	public void setPositionY(float y) {
		transform.localPosition = new Vector3 (transform.localPosition.x, y, 0);
	}
		
}
