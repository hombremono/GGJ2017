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
	
	List<char> GenerateSequence()
    {
        List<char> Sequence = new List<char>();
        for (int i = 0; i < SequenceSize; i++)
        {
            var number = Random.Range(1, 4);
            Debug.Log(number);
            Sequence.Add(Chars[number]);
        }
        return Sequence;
    }
}
