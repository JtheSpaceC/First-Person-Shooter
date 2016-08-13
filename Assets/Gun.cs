using UnityEngine;
using System.Collections;


public class Gun : MonoBehaviour {

	public enum ShootType {Ray, Projectile};
	public ShootType shootType;

	public GameObject bulletPrefab;
	public int ammo = 300;
	public float roundsPerMinute = 800f;
	public float muzzleVelocity = 320f;

	AudioSource myAudio;
	float lastFire;

	[Header("Only used if Shoot Type is set to 'Ray'")]
	public LayerMask canHit;
	public GameObject bulletImpactParticle;


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
			if(shootType == ShootType.Projectile)
			{
				GameObject bullet = Instantiate(bulletPrefab, transform.GetChild(0).position, transform.rotation) as GameObject;
				bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * muzzleVelocity;
			}
			else if (shootType == ShootType.Ray)
			{
				RaycastHit hit;
				Physics.Raycast(transform.GetChild(0).position, transform.forward * 200, out hit, canHit);

				if(hit.collider != null)
				{			
					print(hit.collider.name);
					Instantiate(bulletImpactParticle, hit.point, bulletImpactParticle.transform.rotation);

					if(hit.collider.GetComponent<Rigidbody>())
					{
						hit.collider.GetComponent<Rigidbody>().AddExplosionForce(1000, hit.point, 0);
					}
				}
			}

			ammo--;

			GetComponent<AudioSource>().PlayOneShot(myAudio.clip);
			lastFire = Time.time;
		}
	}
}
