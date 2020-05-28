 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	public PlayerController myPlayer;
	public Transform cloudTrotAltitude;
	public Transform tunlTrotAltitude;
	
	public Material[] backgroundList;
	private Renderer myRenderer;
	
	
    // Start is called before the first frame update
    void Start()
    {
		myPlayer = FindObjectOfType<PlayerController>();
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
	
	if(myPlayer.myRigidbody.transform.position.y > cloudTrotAltitude.transform.position.y)
		{
			myRenderer.material = backgroundList[1];		
		}
	else if(myPlayer.myRigidbody.transform.position.y < tunlTrotAltitude.transform.position.y)
		{
			myRenderer.material = backgroundList[2];
		}	
	else if((myPlayer.myRigidbody.transform.position.y < cloudTrotAltitude.transform.position.y) && (myPlayer.myRigidbody.transform.position.y > tunlTrotAltitude.transform.position.y))
		{
			myRenderer.material = backgroundList[0];		
		}	
		
		Vector2 offset = new Vector2(Time.time *(myPlayer.moveSpeed / 100), 0);
		myRenderer.material.mainTextureOffset = offset;
		
    }
}
