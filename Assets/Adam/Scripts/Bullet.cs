using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float hullDamage = 5;
	public float shieldDamage = 2;
	public float shieldPenalty = 2;
	public bool team1 = true;
	public string team;
	public float lifeTime = 5;

	void Update () {
		Destroy(gameObject, lifeTime);

	}

	void OnTriggerEnter (Collider col){

		if (col.gameObject.tag != team) { //If my collidee isn't on my team
			
			if (col.gameObject.GetComponent<Status> ()){//If the collidee has health and shield
				
				if (col.gameObject.GetComponent<Status> ().shield <= 0) {
					col.gameObject.GetComponent<Status> ().health -= hullDamage;

				} else {
						
					col.gameObject.GetComponent<Status> ().health -= hullDamage - shieldPenalty;
					col.gameObject.GetComponent<Status> ().shield -= shieldDamage;
				}
			}
			Destroy(gameObject);
		}
	}
}
