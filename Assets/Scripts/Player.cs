﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed = 2.0f;

    private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveH, moveV);
		rBody.position = rBody.position + (movement * moveSpeed) * Time.deltaTime;
	}
}
