using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerScript : MonoBehaviour {

	public GameObject player;
	public float curTime;
	public float spawnDelay;
	public List<Vector3>spawnPoints =  new List<Vector3>();
	public float gizmoSize;


	int ranSect;
	void Start () {
		curTime = spawnDelay;
	}

	void Update () {
		GameObject gotPlayer = GameObject.FindGameObjectWithTag (player.tag); 

		if (!gotPlayer){
			curTime -= Time.deltaTime;
		}

		if (curTime <= 0){
			ranSect = Random.Range(0, spawnPoints.Count);
			GameObject clone = Instantiate(player, spawnPoints[ranSect], transform.rotation) as GameObject;
			curTime = spawnDelay;
			Debug.Log(ranSect);
		}
	
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.green;
		foreach(Vector3 spawnPoint in spawnPoints){

			Gizmos.DrawCube(spawnPoint, new Vector3(gizmoSize, gizmoSize, gizmoSize));
		}
	}
}
