using UnityEngine;
using System.Collections;
using System;

public class Item : Utility, IComparable<Item> {

	[SerializeField]
	private float frequency, deathTimer;
	private GameObject myGameObject;

	private bool blinking = false;

	private Utility test;

	public Item(float newFrequency, GameObject newGameObject) {
		frequency = newFrequency;
		myGameObject = newGameObject;
	}

	public GameObject getGameObject () {
		return myGameObject;
	}

	public float getFrequency () {
		return frequency;
	}

	public void Start () {
		deathTimer += Time.time;
	}

	public void Update () {
		if (Time.time + 5 >= deathTimer) {
			blinking = true;
//			StartCoroutine (blink ());
			blink (gameObject, 0.2f, 0.2f);
		}
		if (Time.time >= deathTimer)
			Destroy (gameObject);
	}

	public int CompareTo (Item other) {
		if (other == null)
			return 1;
		else if (frequency < other.getFrequency())
			return -1;
		else
			return 1;
	}

}
