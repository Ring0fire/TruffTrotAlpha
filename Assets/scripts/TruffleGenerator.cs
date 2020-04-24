using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruffleGenerator : MonoBehaviour
{
	public ObjectPooler trufflePool;
	
	private float truffPlacement;

	public void SpawnTruffles (Vector3 startPosition)
	{
		truffPlacement = Random.Range(0f, 3f);
		GameObject truffle1 = trufflePool.GetPooledObject();
		truffle1.transform.position = new Vector3 (startPosition.x + truffPlacement, startPosition.y + (truffPlacement/2), startPosition.z);
		truffle1.SetActive (true);
	}
}
