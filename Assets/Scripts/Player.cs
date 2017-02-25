using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed = 2.0f;
	public float stepTime = 1.0f;
	public Camera cam;
	public Sword sword;
	public Sprite[] sprites;

    private Rigidbody2D rBody;
	private SpriteRenderer spriteRenderer;
	private float timeToNextSprite;
	private int currentSprite = 0;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		timeToNextSprite = stepTime;
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

		Vector3 mouse = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f));
		float AngleRad = Mathf.Atan2 (mouse.y - transform.position.y, mouse.x - transform.position.x);
		float angle = (180 / Mathf.PI) * AngleRad - 270;

		rBody.rotation = angle;

		if (Input.GetMouseButton (0)) {
			sword.Attack();
		}
	}

	private void SwitchSprite (bool isWalking) {
		if (isWalking == true) {
			if (currentSprite == 1) {
				currentSprite = 2;
			} else {
				currentSprite = 1;
			}
		} else {
			currentSprite = 0;
		}
		spriteRenderer.sprite = sprites[currentSprite];
	}
}
