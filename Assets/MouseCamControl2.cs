using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamControl2 : MonoBehaviour {

	public float sensitivity = 5f;

	public GameObject center; //center for camera and crosshair
	public GameObject character; //using playercontroller component
	public GameObject head; //object that rotate on the point

	private float mouseX, mouseY, mouseX2;

	private Vector3 centerOffset;

	// Use this for initialization
	void Start () {
		centerOffset= center.transform.position;
		centerOffset.y-=1;;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Cursor.lockState == CursorLockMode.Locked) {

			//get mouse movement
			mouseX += Input.GetAxis ("Mouse X") * sensitivity;

			// another var for head movement that limited
			mouseX2 += Input.GetAxis ("Mouse X") * sensitivity;

			mouseY -= Input.GetAxis ("Mouse Y") * sensitivity; 

			//limit lookup and lookdown
			mouseY = Mathf.Clamp (mouseY, -60f, 60f);

			//Limit head movement
			mouseX2  = Mathf.Clamp (mouseX2, -45f, 45f);

			//rotating center point
			center.transform.rotation = Quaternion.Euler (mouseY, mouseX, 0);
			//head rotation
			head.transform.localRotation = Quaternion.Euler (mouseY, mouseX2 ,0);

			//FAIL//rotate head to limit it by certain value
			//head.transform.rotation = Quaternion.Euler (head.transform.eulerAngles.x, Mathf.Clamp(head.transform.eulerAngles.y,-45f,45f),


			//FAIL//rotate head using lerp cant limit the head movement because quaternion wont return negative euler value
			//Quaternion headRotation = Quaternion.Lerp (character.transform.rotation, Quaternion.Euler (mouseY, mouseX ,0),1 );

			//rotate head to limit it by certain value
			//head.transform.rotation = Quaternion.Euler (head.transform.eulerAngles.x, Mathf.Clamp(head.transform.eulerAngles.y,-45f,45f),0 );

			//FAIL// trying to use var to store current euler angle
			/*float maxTiltAngle = 45f;
			Vector3 curRot = headRotation.eulerAngles;
			float maxY = curRot.y + maxTiltAngle;
     		float minY = curRot.y - maxTiltAngle;
			Debug.Log("unclamped : "+curRot.y);
			curRot.y = Mathf.Clamp(curRot.y, -45f, 45f);
			Debug.Log("clamped : "+curRot.y);
			head.transform.rotation = Quaternion.Euler( curRot);
			*/

			//rotate head to look at center pos
			//head.transform.LookAt(center.transform.position+center.transform.forward+center.transform.up-center.transform.right*0.5f);


			//rotating camera to always look at center
			transform.LookAt (center.transform);


			//when moving forward/backward
			if (Input.GetAxis ("Vertical") != 0) {
				//rotate character to face the same side as camera
				character.transform.rotation = Quaternion.Euler (0, center.transform.eulerAngles.y, 0);
				//rotate head as well
				mouseX2=0;
			}
		}

		//follow character
		//center.transform.position = (centerOffset + character.transform.position);
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
