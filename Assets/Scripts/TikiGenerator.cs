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
    public UnityEngine.UI.Text txt_CurrentSequence;
    public Text txt_Stack;
    private List<char> Stack;
    public int StackMaxSize;
    public GameObject Tikis;


    // Use this for initialization
    void Start () {
        if (CurrentSequence == null)
            CurrentSequence = new List<char>();
        // Stack = new List<char>();
        Stack = WavesSingleton.Instance.Stack;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void NextElement(char nextElement)
    {
        if (nextElement == 'R')
            CurrentSequence = new List<char>();
        else
            CurrentSequence.Add(nextElement);
        
        UpdateCurrentSequenceText();
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
        if (Stack.Count == StackMaxSize)
            Stack.RemoveAt(0);
        Stack.Add(Button);
       // UpdateStackText();
        Tikis.GetComponent<TikisManager>().DrawTikis(Stack);
        //TODO
    }

    public void UpdateCurrentSequenceText()
    {
        string text =string.Empty;

        foreach (var item in CurrentSequence)
        {
            text += item.ToString() + "  ";
        }
        txt_CurrentSequence.text = text;
    }
    public void UpdateStackText()
    {
        string text = string.Empty;
        for (int i = Stack.Count-1; i >=0; i--)
        {
            text += Stack[i].ToString()+"\n";
        }
       
        txt_Stack.text = text;
    }
}
