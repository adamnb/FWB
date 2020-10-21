using UnityEngine;
using System.Collections;

public class TwoPlayerCamera : MonoBehaviour {

	[SerializeField]
	private Transform player1;

	[SerializeField]
	private Transform player2;

	public float yOffset;
	public float distantialZoomLimit;
	public float distance;
	public Vector3 middlePoint;

	void Update () {

		player1 = GameObject.FindGameObjectWithTag("Team1").transform;
		player2 = GameObject.FindGameObjectWithTag("Team2").transform;

		distance = Mathf.Sqrt((player1.position.x - player2.position.x)*(player1.position.x - player2.position.x) + 
							 (player1.position.z - player2.position.z) * (player1.position.z - player2.position.z));

		if(player1.position.z < player2.position.z){
			middlePoint.z = Mathf.Abs((player1.position.z - player2.position.z)/2) + player1.position.z;
		}else{
			middlePoint.z = Mathf.Abs((player1.position.z - player2.position.z)/2) + player2.position.z;
		}

		if(player1.position.x < player2.position.x){
			middlePoint.x = Mathf.Abs((player1.position.x - player2.position.x)/2) + player1.position.x;
		}else{
			middlePoint.x = Mathf.Abs((player1.position.x - player2.position.x)/2) + player2.position.x;
		}

		if (distance > distantialZoomLimit){

			transform.position =  new Vector3(middlePoint.x, distance + yOffset, middlePoint.z);
		}
		else{
			transform.position =  new Vector3(middlePoint.x, distantialZoomLimit + yOffset, middlePoint.z);
		}
			
	}
}
