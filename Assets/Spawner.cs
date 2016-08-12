using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnObject;
	public float spawnTime = 1;
	float lastSpawn;
	
	void Update () 
	{
		if(Time.time > lastSpawn + spawnTime)
		{
			Instantiate(spawnObject, transform.position + Random.insideUnitSphere *2, Random.rotation);
			lastSpawn = Time.time;
		}
	}
}
