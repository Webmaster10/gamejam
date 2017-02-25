using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name == "Player") {
			col.gameObject.GetComponent<Player> ().EnableFootprints ();
		}
	}
}
