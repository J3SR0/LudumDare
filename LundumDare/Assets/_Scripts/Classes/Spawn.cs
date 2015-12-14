using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

	[SerializeField]
	private Transform spawnArea;

	[SerializeField]
	private GameObject[] items;

	[SerializeField]
	private float spawnTime = 8.0f;

	[SerializeField]
	private GameObject laser;

	private Game game;

	private float nextSpawnTime, nextLaserTime;

	private List<Item> listItems = new List<Item>();

	void Start () {
		nextSpawnTime = spawnTime;
		nextLaserTime = laser.GetComponent<Laser> ().CoolDown;
		game = GetComponent<Game>();
		for (int i = 0; i < items.Length; ++i)
			listItems.Add (new Item(items [i].GetComponent<Item>().Frequency, items [i]));
		listItems.Sort ();
	}
		
	void Update () {
		if (!game.gameOver)
			spawn();
	}

	private void spawn() {
		float roll = Random.Range (0.01f, 1.0f);
		if (Time.time >= nextSpawnTime) {
			GameObject itemToSpawn = null;
			float cumulProba = 0;
			foreach (Item item in listItems) {
				cumulProba += item.Frequency;
				if (cumulProba >= roll) {
					itemToSpawn = item.MyGameObject;
					break;
				}
			}
			if (itemToSpawn != null) {
				spawnGameObject (itemToSpawn, new Vector2(getSpawnPositionX(), 0f));
				nextSpawnTime += spawnTime;
			}
		}
		if (laser.GetComponent<Laser> ().Frequency >= roll && Time.time >= nextLaserTime) {
			spawnGameObject (laser, new Vector2 (getSpawnPositionX (), 16f));
			nextLaserTime = Time.time + laser.GetComponent<Laser> ().CoolDown;
		}
	}

	private float getSpawnPositionX () {
		return Random.Range (0f, spawnArea.GetComponent<Collider2D> ().bounds.size.x);
	}
		
	private void spawnGameObject (GameObject gameObjectToSpawn, Vector2 coordinates) {
		GameObject gameObjectSpawned = Instantiate (gameObjectToSpawn) as GameObject;
		gameObjectSpawned.transform.parent = spawnArea.transform;
		gameObjectSpawned.transform.localPosition = coordinates;
	}

}
