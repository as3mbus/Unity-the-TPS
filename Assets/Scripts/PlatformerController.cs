using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformerController : MonoBehaviour{
    public GameObject player;
	public void gameStart(){
        player.transform.SetPositionAndRotation(Vector3.zero+Vector3.up, Quaternion.Euler(0,0,0));
    }
}
