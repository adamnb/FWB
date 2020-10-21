using UnityEngine;
using System.Collections;

public class tempExplosion : MonoBehaviour {

	public float shrinkSpeed;
	void Update () {
		transform.localScale = new Vector3(transform.localScale.x - shrinkSpeed,
										   transform.localScale.y - shrinkSpeed,
										   transform.localScale.z - shrinkSpeed);

		if (transform.localScale == Vector3.zero){
			Destroy(gameObject);
		}
	
	}
}
