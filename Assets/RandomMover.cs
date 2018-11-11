using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour {
     public float offset = 0.2f;
    public float speed = 0.2f;
    Vector3 initPos;
    
	// Use this for initialization
	void Start () {
        initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float x = Mathf.PerlinNoise(Time.time * speed, 0);
        float y = Mathf.PerlinNoise(Time.time * speed + 1000, 0);
        float z = Mathf.PerlinNoise(Time.time * speed + 23423, 0);
        transform.position = initPos + new Vector3(x, y, z);
	}
}
