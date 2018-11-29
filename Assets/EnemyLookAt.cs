using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
	}
}
