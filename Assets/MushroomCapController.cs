using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCapController : MonoBehaviour {
    private GameObject Spore;
    private bool IsSporing;
	// Use this for initialization
	void Start () {
        Spore = gameObject.transform.GetChild(0).gameObject;
        print(Spore.name);
                          //transform.GetChild(0);
        Spore.SetActive(false);
	}

    public void ActivateSpore() {
        if (!IsSporing) {
            Spore.SetActive(true);
            GetComponent<AudioSource>().Play();
            IsSporing = true;
        }
    }
}
