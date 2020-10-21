using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusUI : MonoBehaviour {
	public Status player;
	public float playerHealth;
	Image img;

	public float fill;

	void Start (){
		img = GetComponent<Image>();
		player = GetComponent <Status>();
	}

	void Update () {
		playerHealth = player.healthDec;
		img.fillAmount = playerHealth;

	}
}
