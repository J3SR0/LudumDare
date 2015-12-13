﻿using UnityEngine;
using System.Collections;
using System;

public class Item : Utility, IComparable<Item> {

	[SerializeField]
	private float frequency, timerBeforeDeath, timerBeforeBlink, timerShowBlink, timerShowBlinkReduction, timerHideBlink, timerHideBlinkReduction, timerBlink;

	private GameObject myGameObject;
	private bool blinking = false;

	public Item(float newFrequency, GameObject newGameObject) {
		frequency = newFrequency;
		myGameObject = newGameObject;
	}
		
	public GameObject MyGameObject{
		get { return myGameObject; }
	}
	public float Frequency {
		get { return frequency; }
	}

	public void Start () {
		timerBeforeBlink += Time.time;
		timerBeforeDeath += Time.time;
	}

	public void Update () {
		float actualTime = Time.time;
		if (actualTime >= timerBeforeBlink && !blinking) {
			blink (gameObject, timerShowBlink, timerShowBlinkReduction, timerHideBlink, timerHideBlinkReduction, timerBlink);
			blinking = true;
		}
		if (actualTime >= timerBeforeDeath)
			Destroy (gameObject);
	}
		
	public int CompareTo (Item other) {
		if (other == null)
			return 1;
		else if (frequency < other.Frequency)
			return -1;
		else
			return 1;
	}

}
