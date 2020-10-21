using UnityEngine;
using System.Collections;

public class TargetFinder : MonoBehaviour {

	public GameObject target;
	public Transform body;
	public float dist;

	void Update () {
		transform.position = body.position;

		float zdist = transform.position.z - target.transform.position.z;
		float xdist = transform.position.x - target.transform.position.x;
		dist = Mathf.Sqrt((xdist * xdist) + (zdist * zdist));

		transform.LookAt(target.transform.position);
		Debug.DrawRay(transform.position, transform.forward * dist, Color.red);
	}	
}
