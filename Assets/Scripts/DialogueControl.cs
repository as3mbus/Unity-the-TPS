using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueControl : MonoBehaviour
{


    public GameObject dPanel;
    public Text dText;
    private GameObject GUI;
    public string[] dialogueLines;
    public int currentLine = 0;
    private GUIControl guicontrol;

    // Use this for initialization
    void Start()
    {
        guicontrol = FindObjectOfType<GUIControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && guicontrol.dialogue)
        {
            if (currentLine < dialogueLines.Length - 1)
            {
                currentLine++;
                showDialogue(dialogueLines[currentLine]);
            }
            else
            {
                dPanel.SetActive(!guicontrol.dialogue);
                guicontrol.dialogue = !guicontrol.dialogue;
                FindObjectOfType<PlayerControl>().interact = false;
                FindObjectOfType<MouseCamControl2>().interact = false;
                guicontrol.reticle.SetActive(true);
            }

        }
    }
    public void showDialogue(string dialogue)
    {
        guicontrol.dialogue = true;
        dPanel.SetActive(true);
        dText.text = dialogue;
        guicontrol.reticle.SetActive(false);
    }
    public void hideDialogue()
    {
        guicontrol.dialogue = false;
        dPanel.SetActive(false);
    }

}
