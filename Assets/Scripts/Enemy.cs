using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10.0f;
	public LayerMask ignoredObjects;
	GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// Find player
		player = GameObject.FindWithTag ("Player");

		// Point to player
		if (inLineOfSight (player)) {
			Quaternion rotEnemy = lookAt (player);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotEnemy, Time.deltaTime * speed);
		} else {
			transform.rotation = Quaternion.identity;
		}
	}

	// Checks if the enemy can see the player
	bool inLineOfSight (GameObject target){
		// Get direction
		Vector3 vectorToTarget = target.transform.position - transform.position;
		float distance = vectorToTarget.magnitude;
		Vector3 direction = vectorToTarget.normalized;

		// Raycast to see if enemy can see player
		if(Physics2D.Raycast(transform.position, direction, distance, ignoredObjects.value))
			return false; // Collider detected by ray, no line of sight
		else
			return true; // No collider detected, line of sight
	}

	// Finds angle from enemy to target and returns a float
	Quaternion lookAt (GameObject target){
		Vector3 vectorToTarget = target.transform.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

		return q;
	}
}
