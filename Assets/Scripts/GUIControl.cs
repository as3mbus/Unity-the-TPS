using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIControl : MonoBehaviour
{

    public bool help;
    public bool dialogue;

    public GameObject helpW;
    public GameObject reticle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            reticle.SetActive(!reticle.activeSelf);
        if (Input.GetKeyDown(KeyCode.F1))
            helpW.SetActive(!helpW.activeSelf);
    }
}
