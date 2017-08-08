using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamControl : MonoBehaviour {
	public float sensitivity = 5f;

	public GameObject center;
	public GameObject character;
	private float mouseX, mouseY;
	private Vector3 centerOffset;
	// Use this for initialization
	void Start () {
		centerOffset= center.transform.position;
		centerOffset.y-=1;;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if reticle mode active
		if (Cursor.lockState == CursorLockMode.Locked) {

			//get mouse movement
			mouseX += Input.GetAxis ("Mouse X") * sensitivity;
			mouseY -= Input.GetAxis ("Mouse Y") * sensitivity; 
			//limit lookup and lookdown
			mouseY = Mathf.Clamp (mouseY, -45f, 45f);
			//rotating center point
			center.transform.localRotation = Quaternion.Euler (mouseY, mouseX, 0);
			//rotating camera to always look at center
			transform.LookAt (center.transform);

			if (Input.GetAxis ("Vertical") != 0 ||Input.GetAxis ("Horizontal") != 0) {
				character.transform.rotation = Quaternion.Euler (0, center.transform.eulerAngles.y, 0);
			}
		}

		//follow character
		center.transform.position = (centerOffset + character.transform.position);
		if (Input.GetKeyDown (KeyCode.LeftAlt)) {
			switch (Cursor.lockState) {
				case CursorLockMode.None:
					Cursor.lockState = CursorLockMode.Locked;
					break;
				case CursorLockMode.Locked:
					Cursor.lockState = CursorLockMode.None;
					break;					
				default:
					break;
			}
		}
	         
	         
	     
	}

	

}
