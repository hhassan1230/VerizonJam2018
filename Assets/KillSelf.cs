using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour {
    private AudioSource crackedSource;

    public AudioClip[] shatters;
    // Use this for initialization

    void Awake()
    {
        crackedSource = GetComponent<AudioSource>();
        if (crackedSource != null) {
            //crackedSource = shatters
            var randomIndex = Random.Range(0, shatters.Length);
            print(randomIndex);
            crackedSource.clip = shatters[randomIndex];
        }
    }

	void Start () {
		//Start
        StartCoroutine("KillSelfCor");

	}
	
	// Update is called once per frame
	void Kill () {
        gameObject.SetActive(false);
	}

    private IEnumerator KillSelfCor()
    {
        yield return new WaitForSeconds(1.5f);

        Kill();
    }

}
