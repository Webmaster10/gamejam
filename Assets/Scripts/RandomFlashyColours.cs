using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlashyColours : MonoBehaviour {

	public float colourChangeTime = 3.0f;
	public SpriteRenderer renderer;

	private float timer = 0.0f;
	private Color lerpedColour;
	private Color colOne, colTwo, colThree;
	private int current = 0;

	// Use this for initialization
	void Start () {
		colOne = RandomColor ();
		colTwo = RandomColor ();
		colThree = RandomColor ();
	}
	
	// Update is called once per frame
	void Update () {
		// Transition between colours
		if (current == 0)
			lerpedColour = Color.Lerp (colOne, colTwo, timer/colourChangeTime);
		else if (current == 1)
			lerpedColour = Color.Lerp (colTwo, colThree, timer/colourChangeTime);
		else if (current == 2)
			lerpedColour = Color.Lerp (colThree, colOne, timer/colourChangeTime);

		// Change colour state
		if (timer >= colourChangeTime) {
			current++;
			if (current == 3) current = 0;
			timer = 0.0f;
		}

		timer += Time.deltaTime;
		renderer.color = lerpedColour;
	}

	Color RandomColor() {
		return new Color(Random.value, Random.value, Random.value);
	}
}
