using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other){
		Debug.Log ("something trigered the killer");
		GameObject.Find("Platformer").GetComponent<PlatformerController>().gameStart();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
