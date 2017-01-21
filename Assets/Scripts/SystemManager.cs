using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour {

    public float timeSpeed = 1;
    public bool pauseGame = false;


    //PRIVATES
    private float lastPopulationGrowth = 0f;

    void Start ()
    {
		
	}
	

	void FixedUpdate ()
    {

        

        if (Time.time > lastPopulationGrowth + 1)
        {
            SystemSingleton.Instance.population += Convert.ToInt32(SystemSingleton.Instance.populationGrowthrate);
            lastPopulationGrowth = Time.time;
        }

        
    }

    void OnGUI()
    {
        if (pauseGame)
        {
            if (!Time.timeScale.Equals(0))
            {
                Time.timeScale = 0;
            }
        }
        else
        {
            Time.timeScale = timeSpeed;
        }
    }
}
