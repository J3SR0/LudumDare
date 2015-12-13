﻿using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {

	///<summary>
	///This function allow to blink a gameobject.
	///</summary>
	public void blink (GameObject gameObjectToBlink = null, float showTime = 1f, float showTimeReduction = 0.01f, float hideTime = 1f, float hideTimeReduction = 0.01f, float timer = 0f) {
		if (gameObjectToBlink != null)
			StartCoroutine (blinking (gameObjectToBlink, showTime, showTimeReduction, hideTime, hideTimeReduction, timer));
	}

	private IEnumerator blinking (GameObject gameObjectToBlink, float showTime, float showTimeReduction, float hideTime, float hideTimeReduction, float timer) {
		if (timer == 0f) {
			while (true) {
				gameObjectToBlink.GetComponent<Renderer> ().enabled = false;
				yield return new WaitForSeconds (hideTime);
				hideTime -= hideTimeReduction;
				gameObjectToBlink.GetComponent<Renderer> ().enabled = true;
				yield return new WaitForSeconds (showTime);
				showTime -= showTimeReduction;
			}
		} else {
			timer += Time.time;
			while (Time.time < timer) {
				gameObjectToBlink.GetComponent<Renderer> ().enabled = false;
				yield return new WaitForSeconds (hideTime);
				hideTime -= hideTimeReduction;
				gameObjectToBlink.GetComponent<Renderer> ().enabled = true;
				yield return new WaitForSeconds (showTime);
				showTime -= showTimeReduction;
			}
		}
	}

}
