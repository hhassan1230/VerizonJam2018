using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public int health;
	private bool hasDied = false;

	// Bond Script

	// Use this for initialization
	void Start () {
		
	}

	void KillEnemies() {
		// Disappears

		// Timeout

		// SetActive

	}

	public void HurtEnemy() {
		 health -= 10;
		 if (health <= 0) {
		 	if (!hasDied) {
			 	KillEnemies();
				hasDied = true;
		 	}
		 }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
