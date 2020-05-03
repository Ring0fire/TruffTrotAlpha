using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	
	public string mainMenuLevel;
	
	public GameObject pauseMenu;
	public GameObject pauseButton;
	
	public void PauseGame()
	{
		GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
		Time.timeScale = 0f;
		pauseMenu.SetActive(true);
		pauseButton.SetActive(false);
	}
	public void ResumeGame()
	{
		GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
		pauseButton.SetActive(true);
	}
	public void RestartGame()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
		FindObjectOfType<GameManager>().Reset();
	}
	public void QuitToMain()
	{
		Time.timeScale = 1f;
		Application.LoadLevel (mainMenuLevel);
	}

}
