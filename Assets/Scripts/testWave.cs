using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWave : MonoBehaviour
{

    private Transform target;
    public float speed;
    public float WaveStrength=10;




    // Use this for initialization
    void Start ()
    {
        target = SystemSingleton.Instance.centerPoint;

    }
	
	// Update is called once per frame
	void Update ()
	{

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        SystemSingleton.Instance.WaveHit(WaveStrength);
        Destroy(gameObject);
    }
}
