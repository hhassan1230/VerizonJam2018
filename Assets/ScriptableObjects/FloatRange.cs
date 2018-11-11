using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RangeParameter/FloatRange")]
public class FloatRange : ScriptableObject
{
    public float value;
    public float min;
    public float max;

    public float random
    {
        get { return Random.Range(min, max); }
    }
}
