using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantsSingleton : Singleton<ConstantsSingleton>
{
    protected ConstantsSingleton () {}


    public string _SCORE_TEXT = "Population: ";

}
