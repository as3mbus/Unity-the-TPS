using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairControl : MonoBehaviour
{
    private GUIControl guictrl;
    public Transform arms;

    // Use this for initialization
    void Start()
    {
        guictrl = FindObjectOfType<GUIControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!guictrl.reticle.activeSelf)
            return;

        //Debug.DrawRay(transform.position, transform.forward, Color.cyan, 5f);
        if (Input.GetButtonDown("Fire1") && objectAimed())
        {
            
            RaycastHit target;
            Physics.Raycast(transform.position, transform.forward, out target, 4f);
            if (target.transform.CompareTag("Interact"))
            {
                FindObjectOfType<PlayerControl>().interact = true;
                FindObjectOfType<MouseCamControl2>().interact = true;
                target.transform.GetComponent<DialogueHolder>().interaction();
            }
        }
    }
    bool objectAimed()
    {
        return Physics.Raycast(transform.position, transform.forward, 4f);
    }
}
