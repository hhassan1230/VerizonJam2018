using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {
    public float AttackIterval;
    public GameObject projectile;
    public float seped = 6f;

    private GameObject CurrentProjectile;
    private Vector3 CurrentDirection;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        StartCoroutine("ActivateEnemyShooting");
        print("HIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIiii");
	}
	
    private IEnumerator ActivateEnemyShooting()
    {
        
        yield return new WaitForSeconds(20f); // 20
        //Soti
        StartCoroutine("ShootingInterval");
    }

    private IEnumerator ShootingInterval()
    {
        FireAtPlayer();
        yield return new WaitForSeconds(10f); // 10
        StartCoroutine("ShootingInterval");
    }

    private void FireAtPlayer() {

        print("in FireAtPlayer");
        var currentShotPosition = player.transform.position;
        CurrentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        CurrentDirection = (currentShotPosition - transform.position).normalized;

    }

	// Update is called once per frame
	void Update () {
        if (CurrentProjectile != null) {
            CurrentProjectile.transform.position += (CurrentDirection * seped) * Time.deltaTime;
        }
	}
}
