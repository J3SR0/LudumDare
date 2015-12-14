using UnityEngine;
using System.Collections;

public class Player : Character {

	public Transform[] childTr;

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

	private string[] debuffPool = new string[2]{"Slow", "Reversed"};
	private string[] buffPool = new string[3]{"Boost", "Invincible", "Life"};

	private bool slowed = false;
	private bool reversed = false;
	private bool boosted = false;
	private bool invincible = false;
	private bool displayLife = false;
	void Awake () {
		Init();
	}

	// Use this for initialization
	void Start () {
		//debuffPool[0] = "Slow";
		//debuffPool[1] = "Reversed";
		StartCoroutine(applySlow());
		StartCoroutine(applyReversed());
		StartCoroutine(applyBoost());
	}
	
	// Update is called once per frame
	void Update () {
		//base.input.customDebug();
	}

	void FixedUpdate() {
		groundCheck();
		if (!game.gameOver){
			//growOverTime();
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
		Vector3 velocity = new Vector3 (0, 0, 0);

		slide(false);
		dashHandler();
//		if (jumpHandler())
//			return;

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
			this.audio.PlayOneShot(dashSound, soundVolume);
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
			this.audio.PlayOneShot(dashSound, soundVolume);
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
		if (!invincible) {
			this.health -= 1;
			this.audio.PlayOneShot(hitSound, soundVolume);
		}
	}

	private void slide(bool status) {
		this.rb.isKinematic = status;
	}

	public void growOverTime() {
		size.grow();
	}

	public void buff () {
		float rawRoll = Random.Range(0f, 1f);
		int roll = (int) Mathf.Round(rawRoll);
		string res = buffPool[roll];
		StartCoroutine(res);
	}

	public void debuff () {
		float rawRoll = Random.Range(0f, 1f);
		int roll = (int) Mathf.Round(rawRoll);
		string res = debuffPool[roll];
		StartCoroutine(res);
	}

	IEnumerator Slow() {
		slowed = true;
		yield return new WaitForSeconds(1);
		slowed = false;
	}

	IEnumerator Reversed() {
		reversed = true;
		yield return new WaitForSeconds(1);
		reversed = false;
	}

	IEnumerator Life() {
		float startTime = Time.time;
		if (health < 3) {
			++health;
		}
		while (Time.time - startTime < 0.5f) {
			displayLife = true;
			yield return null;
		}
		displayLife = false;
	}

	IEnumerator Boost() {
		boosted = true;
		yield return new WaitForSeconds(1);
		boosted = false;
	}

	IEnumerator Invincible() {
		invincible = true;
		yield return new WaitForSeconds(1);
		invincible = false;
	}

	IEnumerator applyReversed() {
		while (!game.gameOver) {
			if (reversed) {
				this.input.h *= -1;
			}
			yield return null;
		}		
	}

	IEnumerator applySlow() {
		float savedVelocity = slideVelocity;
		float slowedSpeed = slideVelocity / 2;
		while (!game.gameOver) {
			if (slowed) {
				slideVelocity = slowedSpeed;
			}
			else
				slideVelocity = savedVelocity;
			yield return null;
		}
	}

	IEnumerator applyBoost() {
		float savedVelocity = slideVelocity;
		float boostedSpeed = slideVelocity * 2;
		while (!game.gameOver) {
			if (boosted) {
				slideVelocity = boostedSpeed;
			}
			else
				slideVelocity = savedVelocity;
			yield return null;
		}
	}

	void OnGUI () {
        GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("button"));
        myStyle.fontSize = 32;
        GUIStyle myLabel = new GUIStyle(GUI.skin.GetStyle("label"));
        myLabel.fontSize = 32;
        GUIStyle myStyle1 = new GUIStyle(GUI.skin.GetStyle("button"));

		if (slowed && !game.gameOver) {
			GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 20, 200, 50),  "S L O W E D", myStyle);
		}
		if (reversed && !game.gameOver) {
			GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 80, 250, 50),  "R E V E R S E D", myStyle);
		}
		if (boosted && !game.gameOver) {
			GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 20, 200, 50),  "B O O S T", myStyle);
		}
		if (invincible && !game.gameOver) {
			GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 80, 300, 50),  "I N V I N C I B L E", myStyle);
		}
		if (displayLife && !game.gameOver) {
			GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 80, 300, 50),  "+ 1 L I F E", myStyle);
		}
	}
}
