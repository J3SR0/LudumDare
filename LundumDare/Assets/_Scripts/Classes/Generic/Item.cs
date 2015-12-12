using UnityEngine;
using System.Collections;
using System;

public class Item : MonoBehaviour, IComparable<Item> {

	[SerializeField]
	private float frequency;
	private GameObject myGameObject;

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

	public int CompareTo (Item other) {
		if (other == null)
			return 1;
		else if (frequency < other.getFrequency())
			return -1;
		else
			return 1;
	}

}
