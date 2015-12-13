using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {

	private bool isBlinking = false;

	public void blink (GameObject gameObjectToBlink = null, float showTime = 1f, float hideTime = 1f, float timer = 0f) {
		Debug.Log ("--- Start ---");
		Debug.Log ("gameObject: " + gameObjectToBlink);
		Debug.Log ("isBlinking: " + isBlinking);
		if (gameObjectToBlink != null && !isBlinking) {
			StartCoroutine (blinking (gameObjectToBlink, showTime, hideTime, timer));
			isBlinking = true;
		}
	}

	IEnumerator blinking (GameObject gameObjectToBlink, float showTime, float hideTime, float timer) {
		if (timer == 0f) {
			while (true) {
				gameObjectToBlink.GetComponent<Renderer> ().enabled = false;
				yield return new WaitForSeconds (hideTime);
				gameObjectToBlink.GetComponent<Renderer> ().enabled = true;
				yield return new WaitForSeconds (showTime);
			}
		} else {
			timer += Time.time;
			while (Time.time < timer) {
				gameObjectToBlink.GetComponent<Renderer> ().enabled = false;
				yield return new WaitForSeconds (hideTime);
				gameObjectToBlink.GetComponent<Renderer> ().enabled = true;
				yield return new WaitForSeconds (showTime);
			}
		}
	}

}
