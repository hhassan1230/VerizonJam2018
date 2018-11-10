﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public float thrust;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

	}
	
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrust);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mushroom")
        {
            print("Mushroom bam!!");

        }
        else if (other.gameObject.tag == "Crystal")
        {
            print("Crystal bam bam!!");


        }
    }

}