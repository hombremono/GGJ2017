using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWaveGenerator : MonoBehaviour {

    List<List<char>> WavesList;
    public List<char> CurrentSequence;
    public Text txt_CurrentSequence;
    public Text txt_Waves;

    // Use this for initialization
    void Start () {
        WavesList = new List<List<char>>();

        //Ini para test
        WavesList.Add(new List<char> { 'A', 'B', 'A' });
        WavesList.Add(new List<char> { 'X', 'B', 'A' });
        WavesList.Add(new List<char> { 'B', 'Y', 'Y' });
        WavesList.Add(new List<char> { 'X', 'Y', 'A' });
        updateWavesText();
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
        List<char> KilledWave=null;
        CurrentSequence.Add(nextElement);
        updateCurrentSequenceText();
        if (CurrentSequence.Count == 3)
        {
            foreach (var wave in WavesList)
            {
                if (CompareLists(wave))
                {
                    KilledWave = wave;
                    break;
                }
            }
            CurrentSequence = new List<char>();
            if (KilledWave != null)
                RemoveWave(KilledWave);
        }
        updateWavesText();
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

    public void updateWavesText()
    {
        string text = string.Empty;
        foreach (var wave in WavesList)
        {
            foreach (var item in wave)
            {
                text += item.ToString() + "  ";
            }
            text += "|| ";
        }
        txt_Waves.text = text;
    }

    public void AddWave(List<char> wave)
    {
        WavesList.Add(wave);
    }

    public void RemoveWave(List<char> wave)
    {
        WavesList.Remove(wave);
    }
}
