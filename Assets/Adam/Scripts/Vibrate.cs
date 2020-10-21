using UnityEngine;
using System.Collections;

public class Vibrate : MonoBehaviour {
	public float intensity;
	Vector3 defSize;

	void Start () {
		defSize = transform.localScale;
	
	}

	void Update () {
		float ranx = Random.Range(defSize.x - (intensity / 2), defSize.x + (intensity / 2));
		float rany = Random.Range(defSize.y - (intensity / 2), defSize.y + (intensity / 2));
		float ranz = Random.Range(defSize.z - (intensity / 2), defSize.z + (intensity / 2));

		transform.localScale = new Vector3(ranx, rany, ranz);
	
	}
}
