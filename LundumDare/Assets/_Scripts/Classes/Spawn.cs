using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

	[SerializeField]
	private Transform spawnArea; // The are where will spawn the items

	[SerializeField]
	private GameObject[] items; // List of items to spawn

	[SerializeField]
	private float spawnTime = 8.0f; // Timer before next spawn
	private float nextSpawnTime;

	private List<Item> listItems = new List<Item>();

	// Use this for initialization
	void Start () {
		nextSpawnTime = spawnTime;
		GameObject item;
		Item itemProperties;
		Debug.Log ("lol");
		for (int i = 0; i < items.Length; ++i) {
			item = items [i];
			itemProperties = item.GetComponent<Item>();
			listItems.Add (new Item(itemProperties.getFrequency(), item));
		}
		listItems.Sort ();
	}

	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextSpawnTime) {
			float roll = Random.Range (0.01f, 1.0f);
			GameObject itemToSpawn = null;
			float cumulProba = 0;
			foreach (Item item in listItems) {
				cumulProba += item.getFrequency();
				if (cumulProba >= roll) {
					itemToSpawn = item.getGameObject ();
					break;
				}
			}
			if (itemToSpawn != null)
				spawnItem (itemToSpawn);
		}
	}


	private void spawnItem (GameObject item) {
		float spawnPostionX = Random.Range (0f, spawnArea.GetComponent<Collider2D> ().bounds.size.x);
		GameObject newItem = Instantiate (item) as GameObject;
		newItem.transform.parent = spawnArea.transform;
		newItem.transform.localPosition = new Vector2 (spawnPostionX, 0);
		nextSpawnTime += spawnTime;
	}

}
