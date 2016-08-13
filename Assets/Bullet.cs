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
		RaycastHit[] hits = Physics.RaycastAll(lastPosition, transform.position, canHit);

		Debug.DrawLine(lastPosition, transform.position, Color.red, 3);

		if(hits.Length != 0)
		{
			for(int i = 0; i < hits.Length; i++)
			{
				print(hits[i].collider.name);
				Instantiate(bulletImpactParticle, hits[i].point, bulletImpactParticle.transform.rotation);
				Instantiate(redball, hits[i].point, Quaternion.identity);
				Destroy(gameObject);
				break;
			}
		}

		/*if(hit.collider != null)
		{			
			print(hit.collider.name);
			Instantiate(bulletImpactParticle, hit.point, bulletImpactParticle.transform.rotation);
			Instantiate(redball, hit.point, Quaternion.identity);
			Destroy(gameObject);

			if(hit.collider.GetComponent<Rigidbody>())
			{
				hit.collider.GetComponent<Rigidbody>().AddExplosionForce(1000, hit.point, 0);
			}
		}*/
		else
		{
			lastPosition = transform.position;
		}
	}
}
