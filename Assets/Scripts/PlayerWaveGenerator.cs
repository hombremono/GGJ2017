using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWaveGenerator : MonoBehaviour {

    List<GameObject> WavesList;
    public List<char> CurrentSequence;
    public Text txt_CurrentSequence;
    

    // Use this for initialization
    void Start () {
        WavesList = WavesSingleton.Instance.WavesList;

        ////Ini para test
        //WavesList.Add(new List<char> { 'A', 'B', 'A' });
        //WavesList.Add(new List<char> { 'X', 'B', 'A' });
        //WavesList.Add(new List<char> { 'B', 'Y', 'Y' });
        //WavesList.Add(new List<char> { 'X', 'Y', 'A' });
       // updateWavesText();
    }

    // Update is called once per frame
    void Update()
    {

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
        GameObject KilledWave=null;
        CurrentSequence.Add(nextElement);
        updateCurrentSequenceText();
        if (CurrentSequence.Count == 3)
        {
            foreach (var wave in WavesList)
            {
                if (CompareLists(wave.GetComponent<testWave>().Sequence))
                {
                    KilledWave = wave;
                    break;
                }
            }
            CurrentSequence = new List<char>();
            if (KilledWave != null)
            {
               WavesSingleton.Instance.RemoveWave(KilledWave);
            }
                
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
        Debug.Log("Secuencia correcata: " + Button);
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
