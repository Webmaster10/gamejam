using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public float timeToOpen = 0.5f;
	public Collider2D topCollider;
	public Collider2D bottomCollider;

	private bool opening = false;
	private float openingTime = 0.0f;
	private string hitSide;

	void Update() {
		if (opening == true && openingTime <= timeToOpen) {
			if (hitSide == "front")
				transform.Rotate (Vector3.forward * (-90.0f / timeToOpen) * Time.deltaTime);
			else
				transform.Rotate (Vector3.forward * (90.0f / timeToOpen) * Time.deltaTime);
			openingTime += Time.deltaTime;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.GetComponent<Player> () != null) {
			if (col.collider.GetType() == typeof (BoxCollider2D)) {
				hitSide = "front";
			} else {
				hitSide = "back";
			}
			opening = true;
		}
	}
}
