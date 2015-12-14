using UnityEngine;
using System.Collections;
using System;

public class Item : Utility, IComparable<Item> {

	[SerializeField]
	private float frequency, timerBeforeDeath, timerBeforeBlink, timerShowBlink, timerShowBlinkReduction, timerHideBlink, timerHideBlinkReduction, timerBlink;
	public float Frequency { get; set; }

	private GameObject myGameObject;
	public GameObject MyGameObject{
		get { return myGameObject; }
	}

	private bool blinking = false;

	public Item(float newFrequency, GameObject newGameObject) {
		frequency = newFrequency;
		myGameObject = newGameObject;
	}

	public void Start () {
		timerBeforeBlink += Time.time;
		timerBeforeDeath += Time.time;
	}

	public void Update () {
		float actualTime = Time.time;
		if (actualTime >= timerBeforeBlink && !blinking)
			blinking = blink (gameObject, timerShowBlink, timerShowBlinkReduction, timerHideBlink, timerHideBlinkReduction, timerBlink);
		if (actualTime >= timerBeforeDeath)
			Destroy (gameObject);
	}
		
	public int CompareTo (Item other) {
		if (other == null)
			return 1;
		return (frequency < other.Frequency ? -1 : 1);
	}

}
