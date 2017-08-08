using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	public string [] dialogueLines;
	private DialogueControl dControl;
	// Use this for initialization
	void Start () {
		dControl=FindObjectOfType<DialogueControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void interaction(){
		dControl.dialogueLines=dialogueLines;
		dControl.currentLine=0;
		dControl.showDialogue(dialogueLines[0]);
	}
}
