using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public ObjectGenerator objectGenerator;
	public ObjectGenerator cloudGenerator;
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
        platformStartPoint = objectGenerator.transform.position;
		playerStartPoint = thePlayer.transform.position;
		theScoreManager = FindObjectOfType<ScoreManager>();
	}

    void Update()
    {
	    // if cloud trot...
		if (thePlayer.myRigidbody.transform.position.y > cloudGenerator.transform.position.y)
		{
			GameObject.Find("ObjectGenerator").GetComponent<ObjectGenerator>().enabled = false;
			cloudGenerator.Generate();
			objectGenerator.transform.position = new Vector2 (cloudGenerator.transform.position.x, objectGenerator.transform.position.y);
		} 
		// else if normal trot...
		else if (thePlayer.myRigidbody.transform.position.y < cloudGenerator.transform.position.y)
		{
			objectGenerator.Generate();
		}
		
//		if (thePlayer.myRigidbody.transform.position.y < cloudGenerator.transform.position.y)
//		{
//			mainTrot = true;
//		}
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
		objectGenerator.transform.position = platformStartPoint;
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
