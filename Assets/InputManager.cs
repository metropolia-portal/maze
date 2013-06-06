using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	
	Vector3 acceleration;
	bool isEscapeButtonDown = false;
	

	
	public float sensitivity = 40;
	
	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_ANDROID
		acceleration = Input.acceleration*sensitivity;
#else
		acceleration = new Vector3 (2*Input.mousePosition.x/Screen.width - 1, 2*Input.mousePosition.y/Screen.height - 1, 0)*sensitivity;
#endif
		
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("MazeLevel");
		}
	}
	
	public Vector3 GetAcceleration() {
		return acceleration;
	}
	
	public bool IsEscapeButtonDown() {
		return isEscapeButtonDown;
	}
	
}
