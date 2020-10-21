using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

	public float health = 100;
	public float shield = 100;
	public float maxHealth = 100;
	public float maxShield = 100;
	public float healthDec;
	int shieldPerc;

	public float collisionThreshold = 200;
	public float collisionDamageFactor;

	//Status bars
	public float barDiv;
	public Transform healthBar;
	public Transform shieldBar;
	float hDefHeight;
	float hDefDepth;
	float sDefHeight;
	float sDefDepth;

	public int fv;
	public bool collisions =  false;

	public GameObject exp;


	PlayerControl pc;

	void Start(){

		pc = gameObject.GetComponent<PlayerControl>();

	}

	void Update () {

		if(health <= 0){
			GameObject expl = Instantiate(exp, transform.position, transform.rotation) as GameObject;
			Destroy (gameObject);

		}
			
		healthDec = health / maxHealth;
			
	}

	void OnCollisionEnter(Collision coll){
		if (collisions){
			if (pc.forwardVel > collisionThreshold){
				health -= pc.forwardVel * collisionDamageFactor;
			}
		}
	}

}
 