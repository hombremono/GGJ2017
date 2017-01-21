using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWave : MonoBehaviour
{

    private Transform target;
    public float speed;
    



    // Use this for initialization
    void Start ()
    {
        target = SystemSingleton.Instance.centerPoint;

    }
	
	// Update is called once per frame
	void Update ()
	{

            if (Vector3.Distance(target.position, transform.position) > 2.0)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
            else
            {
                Destroy(gameObject);
            }
        
        
    }
}
