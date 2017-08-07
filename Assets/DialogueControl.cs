using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueControl : MonoBehaviour {


	public GameObject dPanel,center;
	public Text dText;
	// Use this for initialization
	void Start () {
		dPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if (Input.GetButtonDown ("Fire1")) {
			//Debug.DrawRay(transform.position,center.transform.forward,Color.cyan,5f);
		//}
	}
	public void showDialogue (string dialogue)
	{
		dPanel.SetActive(true);
		dText.text=dialogue;
	}

}
