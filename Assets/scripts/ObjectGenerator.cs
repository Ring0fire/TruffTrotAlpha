using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
	//create a space in the editor to place a platform that can be generated
	//create a public transform, this will act as a coordinate where our objects will spawn
	public GameObject thePlatform;
	public Transform generationPoint;
	 
	private float distanceBetween;
	
	public float distanceBetweenMin;
	public float distanceBetweenMax;
	
	//create the platformSelector whcih will pull a whole number from our platformWidths array, and use that number to choose a game object
	private int platformSelector;
	private float [] platformWidths;
	
	//our ObjectPooler array will hold ObjectPools we can place in the editor
	public ObjectPooler[] theObjectPools;

	public GameManager theGameManager;

	//private float minHeight;
	//public Transform maxHeightPoint;
	//private float maxHeight;
	public float minHeightChange;
	public float maxHeightChange;
	private float heightChange;

    // this will be where we spawn collectables, in this game, truffles, and we limit how many truffles can appear at any one time
	private TruffleGenerator theTruffleGenerator;
	public float randomTruffleThreshold;
	
	//this will spawn pitfall traps in the same way we spawn our collectable truffles
	public float rndSpeedModThreshold;
	private int modSelector;
	public ObjectPooler[] speedModPools;
	
	public ObjectPooler baloonBouncePool;
	public float rndBalloonThreshold;
	
	
	public float powerupHeight;
	public ObjectPooler powerupPool;
	public float powerupThreshold;
	
    void Start()
    {
		/*
		 object generation notes	  
		first we set our platformWidths to a number that we get by finding the length of an object within our object pools (in the editor). 
		so our platformWidths will be set to the 'Length' (size on the x axis). in my project all the platforms are built to be the same size
		so this doesn't do much, but still gives me room to make changes later.
		
		we have 'for loop', which will initialize at 0, then check to see if the object in our ObjectPools has a size. it should, so then
		we set our platformWidths
		*/

        platformWidths = new float [theObjectPools.Length];
		
		for (int i = 0; i < theObjectPools.Length; i ++)
		{
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;	
		}	
		theTruffleGenerator = FindObjectOfType<TruffleGenerator>();
    }

    public void Generate()
    {
        if(transform.position.x < generationPoint.position.x)
		{
			platformSelector = Random.Range(0, theObjectPools.Length);
		 	
			

			distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
			heightChange = Random.Range(maxHeightChange, minHeightChange);
			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] * 2) + distanceBetween, heightChange , 0f);			

			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
			
			if(Random.Range(0f, 100f) < powerupThreshold)
				{
					GameObject newPowerup = powerupPool.GetPooledObject();
					newPowerup.transform.position = transform.position + new Vector3(Random.Range(-platformWidths[platformSelector], platformWidths[platformSelector]), Random.Range(3f,powerupHeight), 0f);
			
					newPowerup.SetActive(true);
				}
				if(Random.Range(0f, 100f) < randomTruffleThreshold)
				{	
					theTruffleGenerator.SpawnTruffles(new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z));
				}
	
			modSelector = Random.Range(0,speedModPools.Length);
			
				if((Random.Range(0f, 100f) < rndSpeedModThreshold) && platformSelector == 0)
				{				
					//float modXPos = platformWidths[platformSelector];
					Vector3 modPosition = new Vector3(0, 1.01f, -1f);
					
					GameObject newSpeedMod = speedModPools[modSelector].GetPooledObject();
					
					newSpeedMod.transform.position = transform.position + modPosition;
					newSpeedMod.transform.rotation = transform.rotation;
					newSpeedMod.SetActive(true);
					
				}
						
				if(Random.Range(0f, 100f) < rndBalloonThreshold)
				{				
					Vector3 baloonFloat = new Vector3(0f, Random.Range(3f, 8.5f), -1f);
					
					GameObject newBaloon = baloonBouncePool.GetPooledObject();
					
					newBaloon.transform.position = transform.position + baloonFloat;
					newBaloon.transform.rotation = transform.rotation;
					newBaloon.SetActive(true);
					
				}
				
		}
    }
}
