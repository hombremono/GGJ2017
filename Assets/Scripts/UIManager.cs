using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public TextMesh ScoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    ScoreText.text = ConstantsSingleton.Instance._SCORE_TEXT + SystemSingleton.Instance.population.ToString();

	}
}
