﻿using System.Collections;
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
        if (Input.GetButtonDown("A_J"+playerNumber))
            SendCommand('A');
        if (Input.GetButtonDown("B_J" + playerNumber))
            SendCommand('B');
        if (Input.GetButtonDown("X_J" + playerNumber))
            SendCommand('X');
        if (Input.GetButtonDown("Y_J" + playerNumber))
            SendCommand('Y');
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            print("START button");
        if (Input.GetAxis("Horizontal") != 0)
            print("axis X");
        if (Input.GetAxis("Vertical") != 0)
            print("axis Y");

    }

    void SendCommand(char command)
    {
        if (isWaveKiller)
            Target.GetComponent<PlayerWaveGenerator>().NextElement(command);
        else
            Target.GetComponent<TikiGenerator>().NextElement(command);
    }
}
