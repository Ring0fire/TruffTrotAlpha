using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Transform objectGenerator;
	public Transform cloudGenerator;
	private Vector3 platformStartPoint;
	
	public PlayerController thePlayer; 
	private Vector3 playerStartPoint;
	
	
	private ObjectDestroyer[] objectList;
    
	private ScoreManager theScoreManager;
	
	public GameOverMenu theGameOverScreen;
	public bool powerupReset;
	
	public bool mainTrot;
	//public bool tunnelTrot;
	public bool cloudTrot;
	
    void Start()
    {
        platformStartPoint = objectGenerator.position;
		playerStartPoint = thePlayer.transform.position;
		theScoreManager = FindObjectOfType<ScoreManager>();
	}

    void Update()
    {
		if (thePlayer.myRigidbody.transform.position.y > cloudGenerator.transform.position.y)
		{
		GameObject.Find("ObjectGenerator").GetComponent<ObjectGenerator>().enabled = false;
		cloudTrot = true;
		mainTrot = false;
		objectGenerator.position = new Vector2 (cloudGenerator.position.x, objectGenerator.position.y);
		} 
		if (thePlayer.myRigidbody.transform.position.y < cloudGenerator.transform.position.y)		
		{
		cloudTrot = false;
		}
		
		if (thePlayer.myRigidbody.transform.position.y < cloudGenerator.transform.position.y)
		{
		mainTrot = true;
		} 

    }
	public void RestartGame()
	{
		theScoreManager.distIncreasing = false;
		thePlayer.gameObject.SetActive(false);
		theGameOverScreen.gameObject.SetActive(true);
	}
	
	public void Reset()
	{
		theGameOverScreen.gameObject.SetActive(false);		
		objectList = FindObjectsOfType<ObjectDestroyer>();
		for(int i =0; i < objectList.Length; i++)
		{
			objectList[i].gameObject.SetActive(false);
		}
		thePlayer.transform.position = playerStartPoint;
		objectGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive(true);
		
		theScoreManager.scoreCount = 0;
		theScoreManager.distanceCount = 0;
		theScoreManager.distIncreasing = true;
		
		powerupReset = true;
	}
	/*public void CloudTrot()
	{
		thePlayer.transform.position = playerStartPoint;
	}*/
}
