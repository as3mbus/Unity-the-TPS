using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider other){
		other.transform.Translate(transform.parent.parent.parent.forward * 2);
		print("arms triggered");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
