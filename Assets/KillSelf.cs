using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour {

	// Use this for initialization
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
