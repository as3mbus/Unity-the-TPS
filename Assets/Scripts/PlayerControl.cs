using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Transform center;
    public GameObject body;
    public bool interact = false;

    public float jumpForce;
    public float speed;
    private Vector3 jumpDir = Vector3.zero;
    public float gravity = 20.0f;
    private int logiclayer = 1 << 8;

    // Use this for initialization
    void Start()
    {
        logiclayer = ~logiclayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (interact) return;

        if(Input.GetButtonDown("Fire1")){
            body.GetComponentInChildren<Animation>().Play();
        }
        if (GetComponent<CharacterController>().isGrounded)
        {
            jumpDir.y = 0;
        }
        //jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //GetComponent<Rigidbody>().AddForce(0,jumpForce,0);
            jumpDir.y = jumpForce;
        }

        //gravity
        if (!GetComponent<CharacterController>().isGrounded)
        {
            jumpDir.y -= gravity * Time.deltaTime;

        }

        //move for jump and gravity.
        GetComponent<CharacterController>().Move(jumpDir * Time.deltaTime);

        //read input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical + transform.right * moveHorizontal;
        //Move
        GetComponent<CharacterController>().Move(movement * Time.deltaTime * speed);
        var tolook = center.transform.position + transform.forward * 2;
        tolook.y = 0;
        //body.LookAt(tolook);

    }


    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -transform.up, 1.1f, logiclayer);
    }
}
