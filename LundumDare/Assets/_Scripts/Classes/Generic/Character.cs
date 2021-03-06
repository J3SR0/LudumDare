﻿using UnityEngine;
using System.Collections;

public class Character : Utility {

	//Input Link
	public InputHandler input;

	// Standard Components
	protected Rigidbody rb;
	protected Transform tr;
	protected Animator an;

	// Standard properties
	public int health;
	public float mana;
	public float speed;
	public float attackSpeed;
	public float jumpHeight;

	//Standard Status
	public bool isGrounded;

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
