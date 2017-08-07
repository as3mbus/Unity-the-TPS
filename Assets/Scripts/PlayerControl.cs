using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Transform center;

    public bool interact = false;

    public float jumpForce;
    public float speed;
    private Vector3 jumpDir = Vector3.zero;
    public float gravity = 20.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!interact)
        {
            //jump
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                //GetComponent<Rigidbody>().AddForce(0,jumpForce,0);
                jumpDir.y = jumpForce;
            }
            //gravity
            jumpDir.y -= gravity * Time.deltaTime;
            //move for jump and other stuff.
            GetComponent<CharacterController>().Move(jumpDir * Time.deltaTime);


            //read input
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0, (moveVertical));
            //Move
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }


    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -transform.up, 1.1f);
    }
}
