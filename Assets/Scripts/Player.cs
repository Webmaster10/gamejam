using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed = 2.0f;
	public float stepTime = 0.5f;
	public Camera cam;
	public Sword sword;
	public Sprite[] sprites;
	public GameObject footprint;
	public int footprintAmount = 10;
	public GameObject thrownWeapon;
	public int thrownWeaponAmmo = 20;

    private Rigidbody2D rBody;
	private SpriteRenderer spriteRenderer;
	private float timeToNextSprite;
	private int currentSprite = 0;
	private Vector3 lastPos;
	private int footprints = 0;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		timeToNextSprite = stepTime;
		lastPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		float moveH = Input.GetAxis("Horizontal");
		float moveV = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveH, moveV);
		rBody.MovePosition(rBody.position + (movement * moveSpeed) * Time.deltaTime);
		Vector3 camPosition = new Vector3 (rBody.position.x, rBody.position.y, -10);
		cam.transform.position = camPosition;
		if (movement != new Vector2(0.0f, 0.0f)) {
			timeToNextSprite -= Time.deltaTime;
			if (timeToNextSprite <= 0.0f) {
				SwitchSprite (true);
				timeToNextSprite = stepTime;
			}
		} else {
			SwitchSprite (false);
			timeToNextSprite = stepTime;
		}

		if (Input.GetMouseButton (0)) {
			sword.Attack();
		}

		// Attack with throwing weapon
		if (Input.GetKeyDown ("r")) {
			weaponThrow ();
		}

		if (moveH > 0.0f || moveV > 0.0f || moveH < 0.0f || moveV < 0.0f || sword.IsAttacking() == true) {
			Time.timeScale = 1.0f;
			Time.fixedDeltaTime = 0.02f;
		} else {
			Time.timeScale = 0.2f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
		}

		lastPos = transform.position;
	}

	void FixedUpdate() {
		Vector3 mouse = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f));
		float AngleRad = Mathf.Atan2 (mouse.y - transform.position.y, mouse.x - transform.position.x);
		float angle = (180 / Mathf.PI) * AngleRad - 270;

		rBody.rotation = angle;
	}

	private void weaponThrow(){
		Instantiate (thrownWeapon, transform.position, transform.rotation);
	}

	private void SwitchSprite (bool isWalking) {
		if (isWalking == true) {
			if (currentSprite == 1) {
				currentSprite = 2;
				if (footprints > 0)
					DrawFootprint ("right");
			} else {
				currentSprite = 1;
				if (footprints > 0)
					DrawFootprint ("left");
			}
		} else {
			currentSprite = 0;
		}
		spriteRenderer.sprite = sprites[currentSprite];
	}

	public void EnableFootprints() {
		footprints = footprintAmount;
	}

	private void DrawFootprint(string side) {
		Quaternion rotation = transform.rotation;
		rotation *= Quaternion.Euler (0, 0, 180);
		if (side == "left") {
			Instantiate (footprint, transform.position + Vector3.left * 0.1f, rotation);
		} else {
			Instantiate (footprint, transform.position + Vector3.right * 0.1f, rotation);
		}
		footprints--;
	}
}
