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
        Vector3 p1 = gameObject.transform.position;
        Vector3 p2 = target.transform.position;
        float angle = Mathf.Atan2(p2.y - p1.y, p2.x - p1.x) * 180 / Mathf.PI;
        gameObject.transform.Rotate(new Vector3(0,0,angle));

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
