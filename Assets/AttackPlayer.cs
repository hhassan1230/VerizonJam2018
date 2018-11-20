using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {
    public float AttackIterval;

    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        StartCoroutine("ActivateEnemyShooting");
	}
	
    private IEnumerator ActivateEnemyShooting()
    {
        yield return new WaitForSeconds(20f);
        StopCoroutine("ShootingInterval");
        //if (!firstUpdate)
        //{
        //    Instantiate(swarmEnemy, new Vector3(0f, 5f, 0f), Quaternion.identity);
        //}
    }

    private IEnumerator ShootingInterval()
    {
        FireAtPlayer();
        yield return new WaitForSeconds(10f);
        StopCoroutine("ShootingInterval");
        //if (!firstUpdate)
        //{
        //    Instantiate(swarmEnemy, new Vector3(0f, 5f, 0f), Quaternion.identity);
        //}
    }

    private void FireAtPlayer() {
        var currentShotPosition = player.transform.position;

    }

	// Update is called once per frame
	void Update () {
		
	}
}
