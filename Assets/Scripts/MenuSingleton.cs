using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSingleton : Singleton<MenuSingleton> {

    protected MenuSingleton() { }


    //variables de prueba, reemplazar y borrar
    public bool pause = false;

    public GameObject Menu;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Menu.SetActive(!pause);
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            pause = !pause;
    }
}
