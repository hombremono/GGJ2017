using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject scoreText;

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update ()
	{

	    scoreText.GetComponent<Text>().text = ConstantsSingleton.Instance._SCORE_TEXT + SystemSingleton.Instance.population.ToString();

	}
}
