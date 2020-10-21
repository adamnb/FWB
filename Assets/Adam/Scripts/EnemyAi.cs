using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {
	public TargetFinder targetFinder;
	public float turnSpeed = 10;
	public float matchPerc;
	public float rayLength = 1.0f;
	public float targetDir;
	public float sightDistance;

	public float percentage;
	public float rotDist;

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();

	}

	void Update (){
		rotDist = targetDir - transform.eulerAngles.y; 
		percentage = (rotDist/360)* 100;
		float absPer = Mathf.Abs(percentage);

		if (targetFinder.dist <= sightDistance){

			if (absPer <= matchPerc && absPer >= 0){
				Debug.Log("I is locked on you boi.");
			}
			else{
				rb.AddTorque(transform.up * turnSpeed);
			}
		}
	
		Debug.DrawRay(transform.position, transform.forward * rayLength, Color.green);
		targetDir = targetFinder.gameObject.transform.eulerAngles.y;

	}

}
