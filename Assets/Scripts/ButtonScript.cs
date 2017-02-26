using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public GameObject MainMenuButtons;
    public GameObject LevelSelectorButtons;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("ShowLevelSelect") > 0){
            LoadLevelSelector(); 
            PlayerPrefs.SetInt("ShowLevelSelect", 0); 
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevelSelector()
    {
        MainMenuButtons.SetActive(false);
        LevelSelectorButtons.SetActive(true);
    }

    public void LoadMainMenu()
    {
        MainMenuButtons.SetActive(true);
        LevelSelectorButtons.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
