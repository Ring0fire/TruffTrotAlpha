using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{ 
	public bool doublePts;
	public float powerupLength;

	private PowerUpManager thePowerUpManager;
	//not really needed till more powerups are added
	public Sprite[] powerupSprites;
	
    void Start()
    {
        thePowerUpManager = FindObjectOfType<PowerUpManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
		if(other.name == "Player")
		{
			thePowerUpManager.ActivatePowerup(doublePts, powerupLength);
		}
			gameObject.SetActive(false);	
    }
}
