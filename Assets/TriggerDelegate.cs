using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDelegate : MonoBehaviour {
    public delegate void TriggerEvent(Collider other);

    public TriggerEvent onTriggerEnter;
    public TriggerEvent onTriggerExit;

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (onTriggerEnter != null)
        {
            onTriggerEnter(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (onTriggerExit != null)
        {
            onTriggerExit(other);
        }
    }
}
