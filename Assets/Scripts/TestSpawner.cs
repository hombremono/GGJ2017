using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour {


    //-----------------VARIABLES PUBLICAS-----------------
    public Transform centerPoint;
    public Transform[] attackPoints;
    public GameObject prefabToSpawn;
    public int spawnRate;
    //----------------------------------------------------


	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(Spawn());


	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    // corutinas
    IEnumerator Spawn()
    {
        print(Time.time);
        int number = Random.Range(0, attackPoints.Length);
        Transform t = attackPoints[number];

        var spawnedObject = Instantiate(prefabToSpawn, t.position, Quaternion.identity);
        spawnedObject.transform.parent = gameObject.transform;
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(Spawn());
    }
}

/*  var myNewSmoke = Instantiate (poisonSmoke, Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity);
  myNewSmoke.transform.parent = gameObject.transform;*/
