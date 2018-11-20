using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public int health;
    public GameObject hurtLight;

	private bool hasDied = false;
    private bool HurtFlickering = false;

    private GameObject parentOject;
	// Bond Script

	// Use this for initialization
	void Start () {
        parentOject = SearchForParent();
        hurtLight.SetActive(false);
        //print(parentOject.name);
	}

    GameObject SearchForParent() {
        var t = transform.parent;

        while (t != null && t.gameObject.tag != "SwarmEnemy") {
            t = t.parent;
        }
        if (t != null) {
            return t.gameObject;
        }
        return null;
    }

	void KillEnemies() {
        // Disappears

        // Timeout

        // SetActive
        // neighborDist
        parentOject.GetComponentInChildren<BoidController>().neighborDist = 10f;
        // Start Corutine
        StartCoroutine("SwarmSplitterAndParentKiller");

	}


    private IEnumerator SwarmSplitterAndParentKiller()
    {
        

        yield return new WaitForSeconds(1.5f);

        KillParent();
    }

    private IEnumerator hurtLightActive()
    {
        if (!HurtFlickering) {
            HurtFlickering = true;
            hurtLight.SetActive(true);
            // Play A SOund
            yield return new WaitForSeconds(.4f);
            hurtLight.SetActive(false);
            HurtFlickering = false;
        }
    }

    void KillParent()
    {
        parentOject.GetComponentInChildren<BoidController>().TakeOutSwam();
        parentOject.SetActive(false);
    }


	public void HurtEnemy() {
		 health -= 10;
        StartCoroutine("hurtLightActive");
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
