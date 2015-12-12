using UnityEngine;
using System.Collections;

public class SpawnPlatform : MonoBehaviour {

	[SerializeField]
	private int maxPlatform = 0;

	[SerializeField]
	private float minY, maxY, minX, maxX = 0;

	[SerializeField]
	private Transform[] platforms;

	[SerializeField]
	private Transform firstPlatform;

	private bool toto = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (toto) {
			Spawn ();
			toto = false;
		}	
	}

	void OnTriggerEnter2D (Collider2D touchedCollider) {
		if (touchedCollider.tag == "Platform")
			Destroy (touchedCollider.gameObject, 3);
	}

	private void Spawn() {
		Transform nextPlatform;
		Vector2 lastPosition = new Vector2(firstPlatform.Find ("Right").position.x + (firstPlatform.GetComponent<Collider2D> ().bounds.size.x / (firstPlatform.childCount * 2)), firstPlatform.position.y);
		Vector2 nextPosition = new Vector2();
		for (int i = 0; i < maxPlatform; ++i) {
			nextPlatform = platforms [Random.Range (0, platforms.Length)];
			nextPosition.Set(lastPosition.x + Vector3.Distance(nextPlatform.position, nextPlatform.Find("Left").position) + (nextPlatform.GetComponent<Collider2D> ().bounds.size.x / (nextPlatform.childCount * 2)), nextPosition.y);
			nextPosition.Set (Random.Range (nextPosition.x + minX, nextPosition.x + maxX), Random.Range (nextPosition.y - minY, nextPosition.y + maxY));	
			Instantiate (nextPlatform, nextPosition, Quaternion.identity);
			lastPosition.Set (nextPosition.x + Vector3.Distance (nextPlatform.position, nextPlatform.Find ("Right").position) + (nextPlatform.GetComponent<Collider2D> ().bounds.size.x / (nextPlatform.childCount * 2)), nextPosition.y);

		}
	}

}