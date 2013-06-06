using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GUIText statusLine;
	public GameObject world;
	public GameObject mouse;
	public Camera cam;
	public Bounds cameraBounds;
	public InputManager inputManager;


	
	float cameraBoundsHalfWidth;
	float cameraBoundsHalfHeight;
	
	// Use this for initialization
	void Start () {
		cameraBoundsHalfWidth = Mathf.Abs((cam.camera.ScreenToWorldPoint(new Vector3(Screen.width,0,1)) - cam.camera.ScreenToWorldPoint(Vector3.up)).x) / 2;
		cameraBoundsHalfHeight = Mathf.Abs((cam.camera.ScreenToWorldPoint(new Vector3(0,Screen.height,1)) - cam.camera.ScreenToWorldPoint(Vector3.up)).z) / 2;
	}
	
	// Update is called once per frame
	void Update () {
		
		statusLine.text = inputManager.GetAcceleration().ToString();
		
		
		
		cam.camera.transform.localPosition = new Vector3(
			Mathf.Clamp(mouse.transform.localPosition.x, cameraBounds.min.x + cameraBoundsHalfWidth, cameraBounds.max.x - cameraBoundsHalfWidth),
			cam.camera.transform.localPosition.y,
			Mathf.Clamp(mouse.transform.localPosition.z, cameraBounds.min.z + cameraBoundsHalfHeight, cameraBounds.max.z - cameraBoundsHalfHeight));
		
	}
}
