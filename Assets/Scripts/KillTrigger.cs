using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour {
	public Transform player;
	// Use this for initialization
	void OnTriggerEnter(Collider other){
		Debug.Log ("something trigered the killer");
		GameObject.Find("Platformer").GetComponent<PlatformerController>().gameStart();
	}
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		var newpos = player.transform.position;
		newpos.y = transform.position.y;
		transform.position= newpos;	
	}
}
