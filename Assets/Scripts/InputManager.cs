using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	
	Vector3 acceleration;
	bool isButtonDown = false;
	bool isEscapeButtonDown = false;
	bool isApplicationPaused = false;
	

	
	public float sensitivity = 40;
	
	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Escape)){
			isEscapeButtonDown = true;
		} else {
			isEscapeButtonDown = false;
		}
		
#if UNITY_ANDROID
		acceleration = Input.acceleration;
		isButtonDown = Input.touchCount == 1;
		
#else
		acceleration = new Vector3 (2*Input.mousePosition.x/Screen.width - 1, 2*Input.mousePosition.y/Screen.height - 1, 0);
		isButtonDown = Input.GetMouseButtonDown(0);
#endif
		
		acceleration.x = Mathf.Clamp(acceleration.x, -0.5f, 0.5f) * sensitivity;
		acceleration.y = Mathf.Clamp(acceleration.y, -0.5f, 0.5f) * sensitivity;
		
	}
	
	void  OnApplicationPause(bool pauseStatus) {
		isApplicationPaused = pauseStatus;
	}
	
	public bool IsApplicationPaused() {
		return isApplicationPaused;
	}
	
	public Vector3 GetAcceleration() {
		return acceleration;
	}
	
	public bool IsButtonDown() {
		return isButtonDown;
	}
	
	public bool IsEscapeButtonDown() {
		return isEscapeButtonDown;
	}
	
}
