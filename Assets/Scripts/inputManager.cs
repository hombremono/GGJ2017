using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            print("A button");
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            print("B button");
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            print("X button");
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            print("Y button");
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            print("START button");
        if (Input.GetAxis("Horizontal") != 0)
            print("axis X");
        if (Input.GetAxis("Vertical") != 0)
            print("axis Y");
    }
}
