using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugShake : MonoBehaviour {

    public CustomCameraShake camShake;
	// U
	 //this for initializa.tion
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) 
		{
            StartCoroutine(camShake.Shake(.15f, .4f));
		}

	}
}
