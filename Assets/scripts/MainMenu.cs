﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	
	public PlayerController thePlayer;
	public string playGameLevel;

	public void PlayGame()
	{
		Application.LoadLevel(playGameLevel);
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}

}
