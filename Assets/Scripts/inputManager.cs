using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                print("START button");
            if (Mathf.Round(Input.GetAxisRaw("T_J1")) != 0)
            {
                SendCommand('R');
            }
            //if (Input.GetAxis("Horizontal") != 0)
            //if (Input.GetAxis("Vertical") != 0)
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
                print("START button");
            //if (Input.GetAxis("Horizontal") != 0)
            //    print("axis X");
            //if (Input.GetAxis("Vertical") != 0)
            //    print("axis Y");
            if (Mathf.Round(Input.GetAxisRaw("T_J2")) != 0)
            {
                SendCommand('R');
            }
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
