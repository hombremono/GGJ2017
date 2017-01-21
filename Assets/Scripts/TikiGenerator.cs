using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TikiGenerator : MonoBehaviour {

    public List<char> SequenceX;
    public List<char> SequenceY;
    public List<char> SequenceA;
    public List<char> SequenceB;
    public List<char> CurrentSequence;
    public int SequenceSize;
    public Text txt_CurrentSequence;

    // Use this for initialization
    void Start () {
        if (CurrentSequence == null)
            CurrentSequence = new List<char>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1))
            this.NextElement('X');
        if (Input.GetKeyDown(KeyCode.Alpha2))
            this.NextElement('Y');
        if (Input.GetKeyDown(KeyCode.Alpha3))
            this.NextElement('A');
        if (Input.GetKeyDown(KeyCode.Alpha4))
            this.NextElement('B');
    }

    public void NextElement(char nextElement)
    {

        CurrentSequence.Add(nextElement);
        if (CurrentSequence.Count == 3)
        {
            if (CompareLists(SequenceX)) 
                MatchFound('X');
            if (CompareLists(SequenceY))
                MatchFound('Y');
            if (CompareLists(SequenceA))
                MatchFound('A');
            if (CompareLists(SequenceB))
                MatchFound('B');

            CurrentSequence = new List<char>();
        }
        updateCurrentSequenceText();
    }

    private bool CompareLists(List<char> Sequence)
    {
        
        for (int i = 0; i < Sequence.Count; i++)
        {
            if (Sequence[i] != CurrentSequence[i])
                return false;
        }
        return true;
    }

    public void MatchFound(char Button)
    {
        Debug.Log("Secuencia correcata: "+Button);
        //TODO
    }

    public void updateCurrentSequenceText()
    {
        string text = string.Empty;

        foreach (var item in CurrentSequence)
        {
            text += item.ToString() + "  ";
        }
        txt_CurrentSequence.text = text;
    }
}
