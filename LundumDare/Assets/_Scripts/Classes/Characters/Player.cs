using UnityEngine;
using System.Collections;

public class Player : Character {

	private float h;
	private float v;
	private bool fire;
	private bool jump;
	private float fallSpeed = 1;
	private float fallMass = 10;

	// Use this for initialization
	public override void Start () {
		Init();
	}
	
	// Update is called once per frame
	void Update () {
		//base.input.customDebug();
	}

	void FixedUpdate() {
		Move();
		//lockZaxis();
		applyFall();
	}
	public override void Move () {
		h = this.input.h;
		jump = this.input.jump;

		flipCharacter();
		Vector3 movement = new Vector3 (h, 0.0f, 0.0f);
		if (h < 0) {
			this.rb.AddForce(movement * this.speed);
		} else if (h > 0) {
			this.rb.AddForce(movement * this.speed);
		}

		if (jump && this.isGrounded) {
			Vector3 verticalMovement = new Vector3 (0.0f, 10 * this.jumpHeight, 0.0f);
			this.rb.AddForce(verticalMovement * 4);
		}

		updateAnimator();
		groundCheck();
	}

	public override void Attack () {

	}

	public void Init () {
		this.tr = GetComponent<Transform>();
		InitBody();
		this.speed = 120;
		this.jumpHeight = 32;
		this.input = this.transform.parent.parent.GetComponent<InputHandler>();
	}

	public void InitBody () {
		Transform[] childTr;

		childTr = gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform tr in childTr) {
			if (tr != this.tr) {
				this.rb = tr.GetComponent<Rigidbody2D>();
				this.an = tr.GetComponent<Animator>();
				this.tr = tr.GetComponent<Transform>();
				break ;
			}
		}
	}

	private void updateAnimator() {
		float absH = h < 0 ? -h : h;
		this.an.SetFloat("speed", absH);
		this.an.SetBool("jump", jump);
	}

	private void lockZaxis() {
		Vector3 pos = this.tr.position;
		pos.z = 0;
		this.tr.position = pos;
	}

	private void flipCharacter() {
		Vector3 scale = this.tr.localScale;

		if (h < 0 && scale.x > 0 || h > 0 && scale.x < 0) {
			scale.x *= -1;
			this.tr.localScale = scale;
		}
	}

	private void groundCheck() {
		if (this.rb.velocity.y == 0)
			this.isGrounded = true;
		else
			this.isGrounded = false;
	}

	private void applyFall() {
		if (this.rb.velocity.y < 0) {
			this.rb.mass = fallMass;
			Vector3 vel = this.rb.velocity;
			vel.y -= fallSpeed;
			this.rb.velocity = vel;
		} else {
			this.rb.mass = 2;
		}
	}
}
