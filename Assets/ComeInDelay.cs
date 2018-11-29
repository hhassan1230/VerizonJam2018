using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeInDelay : MonoBehaviour {
    public float delay = 2f;
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        Invoke("TurnOn", delay);

	}

    void TurnOn() {
        gameObject.SetActive(true);
    }
}
