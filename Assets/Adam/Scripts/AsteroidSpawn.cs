using UnityEngine;
using System.Collections;

public class AsteroidSpawn : MonoBehaviour {

	public float AsteroidCount; //The amount of asteroids to be spawned in the field
	public GameObject spawnObject; //The object to make a clone of
	public bool sizeVariation = false; //Should the objects vary in size?
	public float fieldWidth; //The width (x axis) of the generated field in Meters
	public float fieldLength; //The length (z axis) of the generated field in Meters
	public float minimumScale;
	public float maximumScale;

	void Start () {
		Generate();
	}

	void Update () {
		if (Input.GetKey(KeyCode.R)){
			Generate();
		}
	}

	void Generate () {
		for (int i = 0 ; i < AsteroidCount ; i++){

			float width_given = Random.Range(-fieldWidth / 2, fieldWidth / 2);
			float length_given = Random.Range(-fieldLength / 2, fieldLength / 2);

			Vector3 pos_given = new Vector3(width_given, transform.position.y, length_given);

			GameObject clone = Instantiate(spawnObject, pos_given, transform.rotation) as GameObject;

			if (sizeVariation){
				float size_given = Random.Range (minimumScale, maximumScale);
				clone.transform.localScale = new Vector3 (size_given, size_given, size_given);
			}
		}
	}
}
