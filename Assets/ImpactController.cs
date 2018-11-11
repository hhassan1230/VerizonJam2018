using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("KillSelf");
	}

    private IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(1.5f);

        gameObject.SetActive(false);
    }
	
}
