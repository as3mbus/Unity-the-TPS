using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueControl : MonoBehaviour
{


    public GameObject dPanel, center;
    public Text dText;

    public bool dialogueActive;
    public string[] dialogueLines;
    public int currentLine = 0;

    // Use this for initialization
    void Start()
    {
        dPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (currentLine < dialogueLines.Length-1)
            {
                currentLine++;
                showDialogue(dialogueLines[currentLine]);
            }
            else{
                dPanel.SetActive(!dialogueActive);
                dialogueActive = !dialogueActive;
                FindObjectOfType<PlayerControl>().interact = false;
            }
            
        }
    }
    public void showDialogue(string dialogue)
    {
        dialogueActive = true;
        dPanel.SetActive(true);
        dText.text = dialogue;
    }
    public void hideDialogue()
    {
        dialogueActive = false;
        dPanel.SetActive(false);
    }

}
