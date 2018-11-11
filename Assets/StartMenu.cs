using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {
    public GameObject loadingWrap;
    public GameObject universe;
	// Use this for initialization
	void Start () {
        loadingWrap.SetActive(false);
        Invoke("StartGame", 3f);
	}


    void DeActivateUniverse(){
        universe.SetActive(false);
    }

    private IEnumerator KillUniverse()
    {
        yield return new WaitForSeconds(1.5f);

        DeActivateUniverse();
    }

    public void StartGame() {
        loadingWrap.SetActive(true);
        StartCoroutine("KillUniverse");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
