using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamControl2 : MonoBehaviour
{

    public float sensitivity = 5f;

    public GameObject center; //center for camera and crosshair
    public GameObject character; //using playercontroller component
    public GameObject head; //object that rotate on the point

    private float mouseX2;
    private float mouseX, mouseY, headX;

    private Vector3 centerOffset;
    public bool interact = false;

    public static float euler2Float(float euler)
    {
        if (euler > 180)
        {
            return -360 + euler;
        }
        else return euler;
    }

    // Use this for initialization
    void Start()
    {
        centerOffset = center.transform.position;
        centerOffset.y -= 1; ;
    }

    // Update is called once per frame
    void Update()
    {
        if (interact) return;
        if (Cursor.lockState == CursorLockMode.Locked)
        {

            //get mouse movement
            mouseX += Input.GetAxis("Mouse X") * sensitivity;

            // another var for head movement that limited
            mouseX2 += Input.GetAxis("Mouse X") * sensitivity;

            mouseY -= Input.GetAxis("Mouse Y") * sensitivity;

            //limit lookup and lookdown
            mouseY = Mathf.Clamp(mouseY, -60f, 60f);

            //Limit head movement
            mouseX2 = Mathf.Clamp(mouseX, -45f, 45f);

            //rotating center point
            center.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            //head rotation
            headX =  Mathf.Clamp(euler2Float(center.transform.localRotation.eulerAngles.y),-45f,45f);
            //print(euler2Float(center.transform.localRotation.eulerAngles.y));
            //print(Time.deltaTime);
            //head.transform.localRotation = Quaternion.Euler(center.transform.localRotation.eulerAngles.x,(headX + 30f), 0);
            //head.transform.Rotate(new Vector3(center.transform.localRotation.eulerAngles.x,(headX + 30f), 0));
            if (euler2Float(head.transform.localRotation.eulerAngles.x)-euler2Float(center.transform.localRotation.eulerAngles.x)>=1)
                head.transform.Rotate(-Vector3.right*Time.deltaTime*30);
            if (euler2Float(head.transform.localRotation.eulerAngles.x)-euler2Float(center.transform.localRotation.eulerAngles.x)<=-1)
                head.transform.Rotate(Vector3.right*Time.deltaTime*30);

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
            transform.LookAt(center.transform);


            //when moving forward/backward
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                //rotate character to face the same side as camera
                character.transform.rotation = Quaternion.Euler(0, center.transform.eulerAngles.y, 0);
                //rotate head as well
                mouseX2 = 0;
            }
        }

        //follow character
        //center.transform.position = (centerOffset + character.transform.position);
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            switch (Cursor.lockState)
            {
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
