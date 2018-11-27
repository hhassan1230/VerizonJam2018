using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorEnemyHealth : MonoBehaviour {

	private float health = 100f;
	private float OriginalHealth;
	public float KillTime;



	// Use is for initialization
	void Start () {
		OriginalHealth = health;
	}

	public void ApplyingDamage()
	{
		health -= Time.deltaTime * OriginalHealth/KillTime;
		print(health);
		if (health <= 0) {
			killEnemy();
		}
	}

	public void killEnemy() {
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
}
