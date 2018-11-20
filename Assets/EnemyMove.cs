using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    private GameObject player;

    private float speed;


    float xAxis = 0;
    float yAxis = 0;
    float zAxis = 0;


    public float difference;

	// Use this for initialization
	void Start () {
        // zAxis += speed * Time.deltaTime;
        player = GameObject.FindWithTag("Player");
        speed = player.GetComponent<ShipController>().speed;
	}
	
	// Update is called once per frame
	void Update () {
        //zAxis += speed * Time.deltaTime;

        //float x = xAxis;
        //float y = yAxis;
        //float z = zAxis;
        var position = transform.position;

        position.z = player.transform.position.z + difference;

        transform.position = position;
        //transform.rotation = EndRotation;
	}
}
