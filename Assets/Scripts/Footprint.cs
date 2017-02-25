using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprint : MonoBehaviour {

	public float aliveTime = 20.0f;

	// Update is called once per frame
	void Update () {
		aliveTime -= Time.deltaTime;
		if (aliveTime <= 0.0f) {
			Destroy (gameObject);
		}
	}
}
