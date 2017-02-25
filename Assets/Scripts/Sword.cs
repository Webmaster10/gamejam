using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public GameObject hand;
	public Collider2D col;
	public float attackCooldown = 1.0f;
	public float attackTime = 0.4f;

	private float coolDown = 0.0f;
	private bool attacking = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (coolDown > 0.0f) {
			coolDown -= Time.deltaTime;
			if (attackCooldown - coolDown >= attackTime && attacking == true) {
				hand.transform.Rotate (new Vector3 (0.0f, 0.0f, 40.0f));
				col.enabled = false;
				attacking = false;
			}
		} else {
			coolDown = 0.0f;
		}
	}

	public void Attack() {
		if (coolDown <= 0.0f) {
			col.enabled = true;
			hand.transform.Rotate (new Vector3 (0.0f, 0.0f, -40.0f));
			coolDown = attackCooldown;
			attacking = true;
		}
	}

	public bool IsAttacking() {
		return attacking;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name == "enemySprite") {
			col.gameObject.GetComponent<Enemy>().Kill();
		}
	}

}
