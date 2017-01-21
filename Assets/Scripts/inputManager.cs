using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inputManager : MonoBehaviour
{
    bool pause = false;
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
            SceneManager.LoadScene("PauseMenu");
        if (Input.GetAxis("Horizontal") != 0)
            print("axis X");
        if (Input.GetAxis("Vertical") != 0)
            print("axis Y");
    }
}
