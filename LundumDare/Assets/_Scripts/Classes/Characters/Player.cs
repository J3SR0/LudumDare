using UnityEngine;
using System.Collections;

public class Player : Character {

	private float h;
	private float v;
	private bool fire;
	private bool jump;
	private bool jumpReady = false;

	private float fallSpeed = 1;
	private float fallMass = 15;
	private float slideVelocity = 20;
	private float growthRate = 1;

	private CollisionDetection collision;
	private ChangeSize size;
	private Timer time;
	private Game game;

	private AudioSource audio;
	public AudioClip dashSound;
	public AudioClip hitSound;

	// Use this for initialization
	public override void Start () {
		Init();
	}
	
	// Update is called once per frame
	void Update () {
		//base.input.customDebug();
	}

	void FixedUpdate() {
		groundCheck();
		if (!game.gameOver){
			growOverTime();
			Move();
		}
		//applyFall();
	}

	public void Init () {
		this.tr = GetComponent<Transform>();
		InitBody();
		InitTimer();
		this.health = 3;
		this.speed = 120;
		this.jumpHeight = 32;
		this.input = this.transform.parent.parent.GetComponent<InputHandler>();
		this.game = this.transform.parent.parent.GetComponent<Game>();
		this.audio = GetComponent<AudioSource>();
	}

	public void InitBody () {
		Transform[] childTr;

		childTr = gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform tr in childTr) {
			if (tr != this.tr) {
				this.rb = tr.GetComponent<Rigidbody>();
				this.an = tr.GetComponent<Animator>();
				this.tr = tr.GetComponent<Transform>();
				collision = tr.GetComponent<CollisionDetection>();
				size = tr.GetComponent<ChangeSize>();
				break ;
			}
		}
	}

	public void InitTimer () {
		time = tr.parent.parent.parent.GetComponent<Timer>();
	}

	public override void Move () {
		h = this.input.h;
		jump = this.input.jump;

		Vector3 velocity = new Vector3 (0, 0, 0);

		slide(false);
		dashHandler();
		if (jumpHandler())
			return;

		Vector3 movement = new Vector3 (h, 0.0f, 0.0f);
		if (h < 0 && this.isGrounded) {
			slide(false);
			velocity.x = -slideVelocity;
			this.rb.velocity = velocity;
		} else if (h > 0 && this.isGrounded) {
			slide(false);
			velocity.x = slideVelocity;
			this.rb.velocity = velocity;
		} else if (h == 0 && this.isGrounded) {
			slide(true);
		}
	}

	public override void Attack () {

	}

	public void dashHandler () {
		bool Lcol = collision.LWCollision();
		bool Rcol = collision.RWCollision();

		if (input.dashLeft && !Lcol) {
			this.audio.PlayOneShot(dashSound, 1F);
			Vector3 newPos = this.tr.position;
			Vector3 newVel = this.rb.velocity;

			newPos.x -= 6;
			newVel.x = -slideVelocity;

			this.tr.position = newPos;
			this.rb.velocity = newVel;
			if (collision.LWCollision()) {
				newPos = this.tr.position;
				newPos.x = -30 + (this.tr.localScale.x / 2);
				this.tr.position = newPos;
			}
		}
		if (input.dashRight && !Rcol) {
			this.audio.PlayOneShot(dashSound, 1F);
			Vector3 newPos = this.tr.position;
			Vector3 newVel = this.rb.velocity;

			newPos.x += 6;
			newVel.x = slideVelocity;
			this.tr.position = newPos;
			this.rb.velocity = newVel;
			if (collision.RWCollision()) {
				newPos = this.tr.position;
				newPos.x = 30 - (this.tr.localScale.x / 2);
				this.tr.position = newPos;
			}
		}

	}

	public bool jumpHandler() {
		if (input.fire && input.fire2 && this.isGrounded) {
			Vector3 vel = this.rb.velocity;
			vel.y += this.jumpHeight / 10;
			this.rb.velocity = vel;
			//Vector3 verticalMovement = new Vector3 (0.0f, 10 * this.jumpHeight, 0.0f);
			//this.rb.AddForce(verticalMovement);
			return true;
		}		
		return false;
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
		this.isGrounded = collision.FCollision();
	}

	private void applyFall() {
		if (!this.isGrounded) {
			this.rb.mass = fallMass;
			Vector3 vel = this.rb.velocity;
			vel.y -= fallSpeed;
			this.rb.velocity = vel;
		} else {
			this.rb.mass = 0.5f;
		}
	}

	public void hit() {
		this.health -= 1;
		this.audio.PlayOneShot(hitSound, 1F);
	}

	private void slide(bool status) {
		this.rb.isKinematic = status;
	}

	private void growOverTime() {
		if (time.time  != 0 && time.time % growthRate == 0) {
			size.grow();
		} else if ((time.time % (growthRate / 2)) == 0) {
			//size.blink(this.tr.gameObject, 0.4f, 0.08f, 0.4f, 0.08f, growthRate / 2);
		}
	}
}
