using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject bulletImpactParticle;
	public GameObject redball;
	public LayerMask canHit;

	Vector3 lastPosition;


	void Awake()
	{
		lastPosition = transform.position;
		Destroy(gameObject, 2f);
	}
	
	void FixedUpdate () 
	{
		RaycastHit hit;
		Physics.Raycast(lastPosition, transform.position, out hit, canHit);

		Debug.DrawLine(lastPosition, transform.position, Color.red, 3);

		if(hit.collider != null)
		{			
			print(hit.collider.name);
			Instantiate(bulletImpactParticle, hit.point, bulletImpactParticle.transform.rotation);
			Instantiate(redball, hit.point, Quaternion.identity);
			Destroy(gameObject);

			if(hit.collider.GetComponent<Rigidbody>())
			{
				hit.collider.GetComponent<Rigidbody>().AddExplosionForce(1000, hit.point, 0);
			}
		}
		else
		{
			lastPosition = transform.position;
		}
	}
}
