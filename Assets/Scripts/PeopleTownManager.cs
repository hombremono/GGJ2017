using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleTownManager : MonoBehaviour
{

    public List<Transform> PeopleSpawnPoints;
    public Transform peopleParent;
    public GameObject peoplePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    int actualPopulation = SystemSingleton.Instance.population / 10;
        
        if (peopleParent.childCount > actualPopulation)
        {
            for (int i = 0; i < peopleParent.childCount - actualPopulation; i++)
            {
                Destroy(peopleParent.GetChild(0).gameObject);
            }
            
        }
        else
        {
            if (peopleParent.childCount < actualPopulation)
            {
                for (int i = 0; i < actualPopulation - peopleParent.childCount ; i++)
                {
                    var spawnedObject = Instantiate(peoplePrefab, PeopleSpawnPoints[Random.Range(0, PeopleSpawnPoints.Count)].position, Quaternion.identity);
                    spawnedObject.transform.parent = peopleParent;
                }
               
            }
        }
	}
}
