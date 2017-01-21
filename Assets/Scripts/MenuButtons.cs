using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    // Update is called once per frame
    public void StartButton ()
    {
        SceneManager.LoadScene("inputJoystickScene");
    }

    public void QuitButton ()
    {
        Application.Quit();
    }

    public void SoundOnOff ()
    {
        //TBD
    }
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            SceneManager.LoadScene("inputJoystickScene");
    }
}
