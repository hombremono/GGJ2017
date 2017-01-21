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
    public List<char> Sequence;
    public int ElementIndex;




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
        //CurrentPos.position = gameObject.transform.position;
       

    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        SystemSingleton.Instance.WaveHit(WaveStrength);
        WavesSingleton.Instance.RemoveWave(gameObject);
        

    }
    public void setSequenceText()
    {
        
        string txtSequence = string.Empty;
        foreach (var item in Sequence)
        {
            txtSequence += item + " ";
        }
        gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>().text = txtSequence;
    }
}
