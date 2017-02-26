using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceFloor : MonoBehaviour {

	public float transitionTime = 3.0f;
	public Renderer rend;

	private Color targetColor;
	private Color currentColor;
	private float timePassed;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		currentColor = rend.material.GetColor("_TintColor");
		timePassed = transitionTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (timePassed >= transitionTime) {
			currentColor = rend.material.GetColor("_TintColor");
			targetColor.r = Random.Range (0.0f, 1.0f);
			targetColor.g = Random.Range (0.0f, 1.0f);
			targetColor.b = Random.Range (0.0f, 1.0f);
			targetColor.a = 1.0f;
			timePassed = 0.0f;
		}
		timePassed += Time.deltaTime;
		Color lerpedColor = Color.Lerp (currentColor, targetColor, timePassed / transitionTime);
		rend.material.SetColor ("_TintColor", lerpedColor);
	}
}
