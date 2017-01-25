using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PersonIA : MonoBehaviour
{
    private Vector3 targetPosition = Vector3.forward;
    public float speed = 1;
    

	// Use this for initialization
	void Start () {
        StartCoroutine(ChangeDirection());
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed* Time.deltaTime);
    }


    IEnumerator ChangeDirection()
    {
        targetPosition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10),0);
        yield return new WaitForSeconds(Random.Range(1,10));
        StartCoroutine(ChangeDirection());
    }

    //void OnCollisionEnter2D(Collision2D coll)
    //{


    //}
    void OnCollision2D(Collider2D other)
    {
        targetPosition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
    }

}
