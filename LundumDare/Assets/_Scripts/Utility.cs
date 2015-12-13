using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {

	private bool isBlinking = false;

	///<summary>
	///This function allow to blink a gameobject.
	///</summary>
	public void blink (GameObject gameObjectToBlink = null, float showTime = 1f, float hideTime = 1f, float timer = 0f) {
		if (gameObjectToBlink != null && !isBlinking) {
			StartCoroutine (blinking (gameObjectToBlink, showTime, hideTime, timer));
			isBlinking = true;
		}
	}

	private IEnumerator blinking (GameObject gameObjectToBlink, float showTime, float hideTime, float timer) {
		if (timer == 0f) {
			while (true) {
				gameObjectToBlink.GetComponent<Renderer> ().enabled = false;
				yield return new WaitForSeconds (hideTime);
				hideTime -= 0.01f;
				gameObjectToBlink.GetComponent<Renderer> ().enabled = true;
				yield return new WaitForSeconds (showTime);
				showTime -= 0.01f;
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
