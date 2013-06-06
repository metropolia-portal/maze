using UnityEngine;
using System.Collections;

public class ExitTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.tag == "Player") {
			Time.timeScale = 0;
			GameObject.Find("GameManager").GetComponent<GameManager>().statusLine.text = "Victory!";
		}
	}
}
