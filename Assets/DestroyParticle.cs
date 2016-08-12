using UnityEngine;

public class DestroyParticle : MonoBehaviour {

	
	void Update () {
		if(!GetComponent<ParticleSystem>().isPlaying)
			Destroy(gameObject);
	}
}
