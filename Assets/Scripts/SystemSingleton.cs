using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSingleton : Singleton<SystemSingleton>
{
    protected SystemSingleton() { } // guarantee this will be always a singleton only - can't use the constructor!
    public Transform centerPoint;
    public int population;
    public float populationGrowthrate = 0f;







}
