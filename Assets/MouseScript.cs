using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {
	
	
	public float windupAtStart = 30;
	public GameObject keyObject;
	public InputManager inputManager;
	
	float rotSpeed = 10;
	
	float windupLeft;
	
		
	float speedModifier = 0.5f;

	// Use this for initialization
	void Start () {
		windupLeft = windupAtStart;
	}
	
	// Update is called once per frame
	void Update () {
		
		Transform model = transform.Find("MouseModel").transform;
		
		windupLeft -= Time.deltaTime;
	
		
		rigidbody.velocity = new Vector3 (inputManager.GetAcceleration().x*speedModifier,-1,inputManager.GetAcceleration().y*speedModifier);
		//Quaternion rot = Quaternion.Slerp(model.rotation, Quaternion.LookRotation(model.position + new Vector3(inputManager.GetAcceleration().x, 0, inputManager.GetAcceleration().z)), rotSpeed * Time.deltaTime);
		
		model.rotation = Quaternion.Slerp(model.rotation, Quaternion.LookRotation(new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z)), rotSpeed*Time.deltaTime);
		
		keyObject.transform.rotation = Quaternion.Euler(0, 180*windupLeft,0);
		
	}
}
