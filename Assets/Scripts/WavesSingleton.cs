using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesSingleton : Singleton<WavesSingleton>
{
    protected WavesSingleton() { } // guarantee this will be always a singleton only - can't use the constructor!

    public int sequenceSize;
    public int wavesMaxCount=20;
    public List<GameObject> WavesList;
    public List<char> Stack;
    private char[] Chars = new char[4] { 'A', 'B', 'X', 'Y' };
    public Text txt_Waves;

    void Start()
    {
        if (sequenceSize == 0)
            sequenceSize = 5;

       // Chars = ;
        WavesList = new List<GameObject>();
        Stack = new List<char>();
    }

    public List<char> GetSequence()
    {
        bool hasMatch=true;
        List<char> sequence = GenerateSequence() ;
        while (hasMatch)
        {
            if (!CheckMatch(sequence))
                hasMatch = false;
        }
        return sequence;

    }
    public List<char> GenerateSequence()
    {
        List<char> Sequence = new List<char>();
        for (int i = 0; i < sequenceSize; i++)
        {
            var number = UnityEngine.Random.Range(1, 4);
            Sequence.Add(Chars[number]);
        }
        return Sequence;
    }

    private bool CheckMatch(List<char> sequence)
    {
        foreach (var wave in WavesList)
        {
            int matchCount = 0;
            for (int i = 0; i < wave.GetComponent<testWave>().Sequence.Count; i++)
            {

                if (sequence[i] == wave.GetComponent<testWave>().Sequence[i])
                    matchCount++;
                else
                    break;
            }
            if (matchCount == sequence.Count)
                return true;
        }
        return false;
    }
    public bool AddWave(GameObject newWave)
    {
        if (WavesList.Count < wavesMaxCount)
        {
            newWave.GetComponent<testWave>().Sequence = GetSequence();
            newWave.GetComponent<testWave>().setSequenceText();
            WavesList.Add(newWave);
            return true;
        }

        return false;
    }
    public void RemoveWave(GameObject wave)
    {
        WavesList.Remove(wave);
        Destroy(wave);
      //  updateWavesText();
    }


    //public void updateWavesText()
    //{
    //    string text = string.Empty;
    //    foreach (var wave in WavesList)
    //    {
    //        foreach (var item in wave.GetComponent<testWave>().Sequence)
    //        {
    //            text += item.ToString() + "  ";
    //        }
    //        text += "| ";
    //    }
    //    txt_Waves.text = text;
    //}






}
