using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerChase : MonoBehaviour
{
	public PlayerController thePlayer;
	public Rigidbody2D myRigidbody;	
	public float speedMod =1;

	// Use this for initialization
	void Start () {
//		thePlayer = FindObjectOfType<PlayerController>();
		myRigidbody = GetComponent<Rigidbody2D > ();
	}
	
	// Update is called once per frame
	void Update () {
	//	distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		
		myRigidbody.velocity = new Vector2 ((thePlayer.moveSpeed)* speedMod, transform.position.y);
		
		if(myRigidbody.transform.position.x > thePlayer.transform.position.x + 1)
		{
			myRigidbody.position = new Vector2 (thePlayer.transform.position.x - 5, myRigidbody.position.y);
		}
			
		
	}
}
