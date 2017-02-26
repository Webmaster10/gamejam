using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour {
	public Button playButton;
	public int targetScene;

	// Use this for initialization
	void Start () {
		Button btn = playButton.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnClick(){
		print ("Meme Machine");
		Application.LoadLevel (targetScene);
	}
}
