﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public float bulletSpeed = 3.0f;
	public float bulletMaxDistance = 500.0f;

	private float totalDist = 0.0f;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		direction.x = 0.0f;
		direction.y = -1.0f;
		direction.z = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (direction * bulletSpeed * Time.deltaTime);
		totalDist += (bulletSpeed * Time.deltaTime);
		if (totalDist >= bulletMaxDistance) {
			Destroy (gameObject);
		}
	}

	// Detect collisions
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag != "Player") {
			print (coll.gameObject.tag);
			Destroy (gameObject);
		}
	}
}
