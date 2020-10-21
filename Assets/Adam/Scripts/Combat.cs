using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {

	public Transform PGun1;
	public Transform PGun2;
	public Rigidbody PProjectile;
	public bool leftGun =  true;
	public float delay;
	public float projForce;
	float curtime = 0.25f;

	PlayerControl pc;

	void Start (){
		pc = GetComponent<PlayerControl>();

	}

	void Update () {

		curtime -= Time.deltaTime;

		if (curtime <= 0) {
			if (!pc.gamePad){
			
				if (Input.GetButton("Fire1")){
					Fire();

				}
			}
			else {
				if (Input.GetButton("Fire1GP")){

					Fire();
				}
			}
		}
	}

	void Fire (){
		if (leftGun) {
			Rigidbody clone = Instantiate (PProjectile, PGun1.position, transform.rotation) as Rigidbody;
			curtime = delay;
			clone.AddForce (transform.forward * projForce);

			leftGun = false;

		} else {
			Rigidbody clone = Instantiate (PProjectile, PGun2.position, transform.rotation) as Rigidbody;
			curtime = delay;
			clone.AddForce (transform.forward * projForce);

			leftGun = true;

		}
		
	}
}
