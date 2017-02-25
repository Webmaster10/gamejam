using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingWeaponRotate : MonoBehaviour {

	public float rotationSpeed = 100.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Rotation of weapon
		transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
	}
}
