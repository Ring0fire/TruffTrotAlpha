using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

public PlayerController thePlayer;
public ObjectGenerator cloudGenerator;
public ObjectGenerator objectGenerator;
public Transform cloudTrot; 

private Vector3 cameraCalibration;
private Vector3 lastPlayerPosition;
private float distanceToMove;
//private float levelToMove;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
		cameraCalibration = transform.position;
		lastPlayerPosition = thePlayer.transform.position;
		//levelToMove = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);
		lastPlayerPosition = thePlayer.transform.position;

		if (thePlayer.myRigidbody.transform.position.y >= cloudTrot.transform.position.y)
		{
			transform.position = new Vector3 (transform.position.x, cloudTrot.transform.position.y + 5, transform.position.z);
		}
		else if (thePlayer.myRigidbody.transform.position.y < cloudTrot.transform.position.y)
		{
			transform.position = new Vector3 (transform.position.x, cameraCalibration.y, transform.position.z);
		}
		
	}
}
