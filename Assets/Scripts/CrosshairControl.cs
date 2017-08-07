using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairControl : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, transform.forward, Color.cyan, 5f);
        if (Input.GetButtonDown("Fire1") && objectAimed())
        {
            RaycastHit target;
            Physics.Raycast(transform.position, transform.forward, out target, 4f);
            FindObjectOfType<PlayerControl>().interact = true;
            target.transform.GetComponent<DialogueHolder>().interaction();
        }
    }
    bool objectAimed()
    {

        return Physics.Raycast(transform.position, transform.forward, 4f);

    }
}
