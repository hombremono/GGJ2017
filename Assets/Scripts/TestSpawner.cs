using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour {


    //-----------------VARIABLES PUBLICAS-----------------
    public Transform centerPoint;
    public Transform[] attackPoints;
    public GameObject prefabToSpawn;
    public int spawnRate;
    //public float spawnTime = 3f;
    //----------------------------------------------------


    //Use this for initialization

   void Start ()
    {
        StartCoroutine(Spawn());
    }
    //void Start()
    //{
    //    // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
    //    InvokeRepeating("Spawn", spawnTime, spawnTime);
    //}

    // Update is called once per frame
    void Update ()
    {
		
	}


    // corutinas
    IEnumerator Spawn()
    {
        //WavesSingleton.Instance.AddWave();
        int number = Random.Range(0, attackPoints.Length);
        Transform t = attackPoints[number];
        var spawnedObject = Instantiate(prefabToSpawn, t.position, Quaternion.identity);
        if (WavesSingleton.Instance.AddWave(spawnedObject))
        {
            spawnedObject.transform.parent = gameObject.transform;
        }
        else
        {
            Destroy(spawnedObject);
        }

        yield return new WaitForSeconds(spawnRate);

        StartCoroutine(Spawn());
    }
    //void Spawn()
    //{
    //    int number = Random.Range(0, attackPoints.Length);
    //    Transform t = attackPoints[number];
    //    var spawnedObject = Instantiate(prefabToSpawn, t.position, Quaternion.identity);
    //    if (WavesSingleton.Instance.AddWave(spawnedObject))
    //    {
    //        spawnedObject.transform.parent = gameObject.transform;
    //    }
    //    else
    //    {
    //        Destroy(spawnedObject);
    //    }
    //}
}

/*  var myNewSmoke = Instantiate (poisonSmoke, Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity);
  myNewSmoke.transform.parent = gameObject.transform;*/
