using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public Transform target;
	public float movementSpeed;
	public Vector3 offset;
	public bool hasPlayerControl;
	public float targetV;
	public float zoomFactor;

	Vector3 camtar;

	void FixedUpdate () {
		if (target.gameObject.GetComponent<PlayerControl>()){
			targetV = target.gameObject.GetComponent<PlayerControl>().forwardVel;
			hasPlayerControl = true;

		}else{
			hasPlayerControl = false;

		}

		camtar = new Vector3 (target.position.x + offset.x, target.position.y + offset.y + targetV * zoomFactor, target.position.z + offset.z);
		transform.position = Vector3.Lerp(transform.position, camtar, movementSpeed * Time.deltaTime);

	}
}