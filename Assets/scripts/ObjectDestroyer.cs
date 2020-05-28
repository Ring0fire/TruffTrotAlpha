using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

public GameObject DestructionPoint;
public GameObject LvlDestPnt;

	// Use this for initialization
	void Start () {
		DestructionPoint = GameObject.Find ("destructionPoint");
		LvlDestPnt = GameObject.Find ("lvlDestPnt");
	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.position.x < DestructionPoint.transform.position.x)
		{ 
			gameObject.SetActive(false);
		}
		else if ((transform.position.y > (LvlDestPnt.transform.position.y + 5f)) && gameObject.tag == "cloudLvl")
		{
			gameObject.SetActive(false);
		}	
	}
}
