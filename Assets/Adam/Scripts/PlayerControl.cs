using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	Rigidbody rb;
	public bool gamePad = false;


	//Boost Effect
	public Transform boostEffect;
	public Vector3 relativeB_ESize; //The relative size the boost affect vibrates around
	public float minimumWobble;
	public float maximumWobble;

	//Movement
	public float pThrust = 50;
	public float bankSpeed = 10;

	//Boosting
	public float boostThrust = 500;
	public float boostA_DFactor = 0.5f; //How much the angular drag is affected when boosting
	public float boostDrain = 5;
	public float boostRegen = 2.5f;
	public float boostCharge = 100;
	public float maxBoostCharge = 100;
	public bool boosting;

	//Misc
	public float forwardVel;
	float defdrag;

	float h;
	float v;

	AudioSource audio;
	Status stat;

	void Start () {
		rb = GetComponent<Rigidbody>();
		audio = GetComponent<AudioSource>();
		stat = GetComponent<Status>();
		defdrag = rb.drag;

	}

	void FixedUpdate () {

		//Calculating forward Velocity
		float vx = rb.velocity.x;
		float vz = rb.velocity.z;

		forwardVel = Mathf.Sqrt((vx * vx) + (vz * vz));

		//Axial input for gamepad and keyboard
		if (!gamePad){
			h = Input.GetAxisRaw ("Horizontal");
			v = Input.GetAxisRaw ("Vertical");

		}
		else{
			h = Input.GetAxisRaw ("HorzGP");
			v = Input.GetAxisRaw ("VertGP");

		}

		//Random wobbling for the boosting effect
		float ranX = Random.Range (minimumWobble, maximumWobble);
		float ranY = Random.Range (minimumWobble, maximumWobble);
		float ranZ = Random.Range (minimumWobble, maximumWobble);


		rb.AddTorque(Vector3.up * h * bankSpeed);//Yaw
			


		//Boosting for gamepad and Keyboard

		if (v > 0) {
			boosting = true;

		} else {
			boosting = false;
		}

		if (boostCharge <= 0){
			stat.health = 0;
		}

		//Boosting Status
		if (boosting && boostCharge >= 0) {
			if(!audio.isPlaying){
				audio.Play();
			}

			rb.drag = defdrag * boostA_DFactor;
			rb.AddForce (transform.forward * boostThrust);
			boostEffect.localScale = new Vector3(relativeB_ESize.x + ranX, relativeB_ESize.y + ranY, relativeB_ESize.z + ranZ);
			boostCharge -= boostDrain * Time.deltaTime;

		} else {
			audio.Stop();
			rb.drag = defdrag;
			boostEffect.localScale = new Vector3 (0,0,0);

			if (boostCharge < maxBoostCharge){
				boostCharge += boostRegen * Time.deltaTime;

			}
		}
	}
}
