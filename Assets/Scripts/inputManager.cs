using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    public GameObject ElementsPanel;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            ElementsPanel.GetComponent<TikiGenerator>().NextElement('A');
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            ElementsPanel.GetComponent<TikiGenerator>().NextElement('B');
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            ElementsPanel.GetComponent<TikiGenerator>().NextElement('X');
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            ElementsPanel.GetComponent<TikiGenerator>().NextElement('Y');
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            print("START button");
    }
}
