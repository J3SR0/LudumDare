using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	//Input Link
	public InputHandler input;

	// Standard properties
	public float health;
	public float mana;
	public float speed;
	public float attackSpeed;
	public float jumpHeight;

	// Use this for initialization
	public virtual void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Move() {

	}

	public virtual void Attack() {
		
	}
}
