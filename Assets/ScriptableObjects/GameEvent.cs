using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu, SerializeField]
public class GameEvent : ScriptableObject {
    public delegate void Event();
    public Event e;
    public bool isDebug = false;
    public void Invoke(){
        if (e!=null){
            if(isDebug) Debug.Log("Run Event: " + this.name);
            e();
        }
        else
        {
            if (isDebug) Debug.Log("Run empty Event: " + this.name);
        }   
    }
	private void OnDisable()
	{
        if (isDebug) Debug.Log("Destroy Event: " + this.name);
	}
}
