using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public ObjectGenerator objectGenerator;
	public ObjectGenerator cloudGenerator;
	public Transform cloudTrotAltitude;
	
	private Vector3 platformStartPoint;
	
	public PlayerController thePlayer; 
	public VillagerChase theVillager;
	private Vector3 playerStartPoint;
	private Vector3 villagerStartPoint;
	
	private ObjectDestroyer[] objectList;
    
	private ScoreManager theScoreManager;
	
	public GameOverMenu theGameOverScreen;
	public bool powerupReset;
	
    void Start()
    {
        platformStartPoint = objectGenerator.transform.position;
		playerStartPoint = thePlayer.transform.position;
		villagerStartPoint = theVillager.transform.position;
		theScoreManager = FindObjectOfType<ScoreManager>();
		
	}

    void Update()
    {
		if (thePlayer.myRigidbody.transform.position.y > cloudTrotAltitude.transform.position.y)
		{
			cloudGenerator.Generate();
			objectGenerator.Generate();
			//objectGenerator.transform.position = new Vector3 (thePlayer.transform.position.x + 20f, objectGenerator.transform.position.y, transform.position.z);
		} 
		// else if normal trot... 
		else if (thePlayer.myRigidbody.transform.position.y < cloudTrotAltitude.transform.position.y)
		{
			objectGenerator.Generate();
			cloudGenerator.transform.position = new Vector3 (thePlayer.transform.position.x + 5f, cloudGenerator.transform.position.y, transform.position.z);
		}


    }
	public void RestartGame()
	{
		theScoreManager.distIncreasing = false;
		thePlayer.gameObject.SetActive(false);
		theVillager.gameObject.SetActive(false);
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
		theVillager.transform.position = villagerStartPoint;
		objectGenerator.transform.position = platformStartPoint;
		thePlayer.gameObject.SetActive(true);
		theVillager.gameObject.SetActive(true);
		
		theScoreManager.scoreCount = 0;
		theScoreManager.distanceCount = 0;
		theScoreManager.distIncreasing = true;
		
		powerupReset = true;
	}
}
