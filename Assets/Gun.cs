using UnityEngine;
using System.Collections;


public class Gun : MonoBehaviour {

	public GameObject bulletPrefab;
	public int ammo = 300;
	public float roundsPerMinute = 800f;
	public float muzzleVelocity = 320f;

	AudioSource myAudio;
	float lastFire;


	void Awake()
	{
		myAudio = GetComponent<AudioSource>();
	}

	
	void Update () 
	{
		if(Input.GetMouseButton(0))
		{
			Fire();
		}
	}

	void Fire()
	{
		if(ammo <= 0)
			return;
		
		if(Time.time > lastFire + 60f/roundsPerMinute)
		{
			GameObject bullet = Instantiate(bulletPrefab, transform.GetChild(0).position, transform.rotation) as GameObject;
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * muzzleVelocity;

			ammo--;

			GetComponent<AudioSource>().PlayOneShot(myAudio.clip);
			lastFire = Time.time;
		}
	}
}
