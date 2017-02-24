using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public GameObject hand;
	public float attackCooldown = 1.0f;
	public float attackTime = 0.4f;

	private float coolDown = 0.0f;
	private bool attacking = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (attacking == true) {
			attackingTime += Time.deltaTime;
			if (attackingTime <= 0.5 * animationTime) {
				//hand.transform.Rotate (new Vector3 (0.0f, 0.0f, -90.0f) * 2.0f * animationTime * Time.deltaTime);
				hand.transform.Translate(Vector2.up * -2.0f * animationTime * Time.deltaTime);
			} else {
				//hand.transform.Rotate (new Vector3 (0.0f, 0.0f, 90.0f) * 2.0f * animationTime * Time.deltaTime);
				hand.transform.Translate(Vector2.up * 2.0f * animationTime * Time.deltaTime);
			}
			if (attackingTime >= animationTime) {
				attacking = false;
				attackingTime = 0.0f;
			}
		}*/
		if (coolDown > 0.0f) {
			coolDown -= Time.deltaTime;
			if (attackCooldown - coolDown >= attackTime && attacking == true) {
				hand.transform.Rotate (new Vector3 (0.0f, 0.0f, 40.0f));
				attacking = false;
			}
		} else {
			coolDown = 0.0f;
		}
	}

	public void Attack() {
		if (coolDown <= 0.0f) {
			hand.transform.Rotate (new Vector3 (0.0f, 0.0f, -40.0f));
			coolDown = attackCooldown;
			attacking = true;
		}
	}

}
