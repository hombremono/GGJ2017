using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inputManager : MonoBehaviour
{

    public GameObject Target;
    private bool isWaveKiller;
    public int playerNumber;
    void Start()
    {
        if (Target.GetComponent<TikiGenerator>() == null)
            isWaveKiller = true;
    }
    // Update is called once per frame
    void Update()
    {

        //if (Input.GetButtonDown("A_J"+playerNumber))
        //    SendCommand('A');
        //if (Input.GetButtonDown("B_J" + playerNumber))
        //    SendCommand('B');
        //if (Input.GetButtonDown("X_J" + playerNumber))
        //    SendCommand('X');
        //if (Input.GetButtonDown("Y_J" + playerNumber))
        //    SendCommand('Y');
        //if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        //    print("START button");
        //if (Input.GetAxis("Horizontal") != 0)
        //    print("axis X");
        //if (Input.GetAxis("Vertical") != 0)
        //    print("axis Y");

        if (playerNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                SendCommand('A');
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
                SendCommand('B');
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                SendCommand('X');
            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
                SendCommand('Y');
            if (Input.GetKeyDown(KeyCode.Joystick1Button7))
                SceneManager.LoadScene("PauseMenu");
            //if (Input.GetAxis("Horizontal") != 0)
            //    print("axis X");
            //if (Input.GetAxis("Vertical") != 0)
            //    print("axis Y");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                SendCommand('A');
            if (Input.GetKeyDown(KeyCode.Joystick2Button1))
                SendCommand('B');
            if (Input.GetKeyDown(KeyCode.Joystick2Button2))
                SendCommand('X');
            if (Input.GetKeyDown(KeyCode.Joystick2Button3))
                SendCommand('Y');
            if (Input.GetKeyDown(KeyCode.Joystick2Button7))
                SceneManager.LoadScene("PauseMenu");
            if (Input.GetAxis("Horizontal") != 0)
                print("axis X");
            if (Input.GetAxis("Vertical") != 0)
                print("axis Y");
        }
    }

    void SendCommand(char command)
    {
        if (isWaveKiller)
            Target.GetComponent<PlayerWaveGenerator>().NextElement(command);
        else
            Target.GetComponent<TikiGenerator>().NextElement(command);
    }
}
