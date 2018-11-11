using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    public GameObject loadingWrap;
    public GameObject universe;
    public GameObject title;
    public AudioSource warpSound;

	// Use this for initialization
	void Start () {
        loadingWrap.SetActive(false);
        //Invoke("StartGame", 3f); 
       
	}


    void DeActivateUniverse(){
        universe.SetActive(false);
    }

    private IEnumerator KillUniverse()
    {
        yield return new WaitForSeconds(1.5f);

        DeActivateUniverse();
        SceneManager.LoadScene("FlightScene");
    }

    public void StartGame() {
        loadingWrap.SetActive(true);
        // Play Sound
        warpSound.Play();
        StartCoroutine("KillUniverse");
        title.SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            StartGame();
        }
       
	}
}
