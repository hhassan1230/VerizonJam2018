using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingLevelManager : MonoBehaviour {
    public GameObject swarmEnemy;
    private bool firstUpdate = true;
	// Use this for initialization
	void Start () {
        //swarmEnemy = GameObject.FindWithTag("SwarmEnemy");
        StartCoroutine("ActivateEnemy");
	}

    private IEnumerator ActivateEnemy()
    {
        yield return new WaitForSeconds(10f);
        if (!firstUpdate) {
            Instantiate(swarmEnemy, new Vector3(0f, 5f, 0f), Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(firstUpdate) {
            //swarmEnemy.SetActive(false);
            firstUpdate = false;
        }
	}
}
