using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTest : MonoBehaviour {
    public GameObject bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //print(Input.GetAxisRaw("Fire1"));
        if(Input.GetButton("Fire1")) {
            Instantiate(bullet, transform.position, transform.rotation);

        }
	}
}
