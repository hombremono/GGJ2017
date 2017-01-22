using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceGenerator : MonoBehaviour {

    public int SequenceSize;
    private char[] Chars;
	void Start () {
        SequenceSize = WavesSingleton.Instance.sequenceSize;
        Chars = new char[4] { 'A', 'B', 'X', 'Y' };
	}
	
	
}
