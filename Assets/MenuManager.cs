using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : Singleton<MenuManager> {

    protected MenuManager() { }


    //variables de prueba, reemplazar y borrar
    public bool pause = false;

    public GameObject Menu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Menu.SetActive(!pause);


    }
}
