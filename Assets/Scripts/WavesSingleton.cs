using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WavesSingleton : Singleton<WavesSingleton>
{
    protected WavesSingleton() { } // guarantee this will be always a singleton only - can't use the constructor!

    public int sequenceSize=3;
    public int wavesMaxCount = 20;
    public List<GameObject> WavesList;
    public List<char> Stack;
    private char[] Chars = new char[4] { 'A', 'B', 'X', 'Y' };
    public Text txt_Waves;
    private Dictionary<string,bool> posibleCombinations=new Dictionary<string, bool>();
    private string[] lstKeys = new string[64];

    void Start ()
    {
       
    }

    public char[] GetSequence()
    {
        //bool hasMatch=true;
        //List<char> sequence = GenerateSequence() ;
        //while (hasMatch)
        //{
        //    if (!CheckMatch(sequence))
        //        hasMatch = false;
        //}
        //return sequence;
        while (true)
        {
            int random = UnityEngine.Random.Range(0, 63);

            string sequence = lstKeys[random];
            var available = posibleCombinations[sequence];
            if (available)
            {
                posibleCombinations[sequence] = false;
                return sequence.ToCharArray();
                
            }
        }

    }
    //public List<char> GenerateSequence()
    //{
    //    List<char> Sequence = new List<char>();
    //    for (int i = 0; i < sequenceSize; i++)
    //    {
    //        var number = UnityEngine.Random.Range(1, 4);
    //        Sequence.Add(Chars[number]);
    //    }
    //    return Sequence;
    //}

    private bool CheckMatch(char[] charSequence)
    {
        //foreach (var wave in WavesList)
        //{
        //    int matchCount = 0;
        //    for (int i = 0; i < wave.GetComponent<testWave>().Sequence.Count; i++)
        //    {

        //        if (sequence[i] == wave.GetComponent<testWave>().Sequence[i])
        //            matchCount++;
        //        else
        //            break;
        //    }
        //    if (matchCount == sequence.Count)
        //        return true;
        //}
        //return false;
        string sequence = new string(charSequence);
        return posibleCombinations[sequence];
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


    public void populateDictionary()
    {
        int count = 0;
        for (int i = 0; i < Chars.Length; i++)
        {
            for (int j = 0; j < Chars.Length; j++)
            {
                for (int k = 0; k < Chars.Length; k++)
                {
                    string sequence = Chars[i].ToString() + Chars[j].ToString() + Chars[k].ToString();
                    posibleCombinations.Add(sequence, true);
                    lstKeys[count] = sequence;
                    count++;
                }
            }
        }
    }

    public void KillWave(string sequence)
    {
        if (!posibleCombinations[sequence])
        {
            GameObject KilledWave = null;
            posibleCombinations[sequence] = true;
            foreach (var wave in WavesList)
            {
                string waveSequence = new string(wave.GetComponent<testWave>().Sequence);
                if (waveSequence == sequence)
                {
                    KilledWave = wave;
                    break;
                }
            }
            if (KilledWave != null)
                RemoveWave(KilledWave);
        }
    }





}
