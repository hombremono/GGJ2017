using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testWave : MonoBehaviour
{

    private Transform target;
    private Transform CurrentPos;
    public float speed;
    public float WaveStrength=10;
    public char[] Sequence;
    public int ElementIndex;




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
        //CurrentPos.position = gameObject.transform.position;
       

    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        SystemSingleton.Instance.WaveHit(WaveStrength);
        WavesSingleton.Instance.RemoveWave(gameObject);
        

    }
    public void setSequenceText()
    {

        string txtSequence = new string(Sequence);
        
        gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>().text = txtSequence;
    }
}
