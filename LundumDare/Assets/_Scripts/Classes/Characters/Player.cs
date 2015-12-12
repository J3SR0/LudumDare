using UnityEngine;
using System.Collections;

public class Player : Character {

	private float h;
	private float v;

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
	}
	public override void Move () {
		h = this.input.h;
		flipCharacter();
		Vector3 movement = new Vector3 (h, 0.0f, 0.0f);
		if (h < 0) {
			this.rb.AddForce(movement * this.speed);
		} else if (h > 0) {
			this.rb.AddForce(movement * this.speed);
		}
		updateAnimator();
		groundCheck();
	}

	public override void Attack () {

	}

	public void Init () {
		this.tr = GetComponent<Transform>();
		InitBody();
		this.speed = 30;
		this.input = this.transform.parent.parent.GetComponent<InputHandler>();
	}

	public void InitBody () {
		Transform[] childTr;

		childTr= gameObject.GetComponentsInChildren<Transform>();
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
	}

	private void lockZaxis() {
		Vector3 pos = this.tr.position;
		pos.z = 0;
		this.tr.position = pos;
	}

	private void flipCharacter() {
		Vector3 scale = this.tr.lossyScale;

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
}
