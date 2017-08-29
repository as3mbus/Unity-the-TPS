using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAIEasy : MonoBehaviour
{

    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMoveSpeed;
    public float damping;
    float fpsTargetDistance;
    Vector3 home;
    public Transform fpsTarget;
    Rigidbody theRigidbody;
    Renderer myRenderer;


    // Use this for initialization
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        theRigidbody = GetComponent<Rigidbody>();
        home = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fpsTargetDistance = Vector3.Distance(transform.position, fpsTarget.transform.position);
        if (fpsTargetDistance < enemyLookDistance)
        {
            chasePlayer();
        }
        else
        {
            goHome();
        }
    }
    void chasePlayer()
    {
        myRenderer.material.color = Color.red;
        transform.LookAt(fpsTarget);
        theRigidbody.AddForce(transform.forward * enemyMoveSpeed);
    }
    void goHome()
    {
        myRenderer.material.color = Color.magenta;
        transform.LookAt(home);
        if (Vector3.Distance(transform.position, home) > 2)
        {
            theRigidbody.AddForce(transform.forward * enemyMoveSpeed);
        }
        else
        {
            theRigidbody.velocity = Vector3.zero;
            theRigidbody.angularVelocity = Vector3.zero;
            theRigidbody.Sleep();
        }
    }
}
