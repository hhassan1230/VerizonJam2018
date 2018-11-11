using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelDecoration : MonoBehaviour {
    public GameObject[] Decorations;
    public int decorationCount=10;
    public GameObject floor;
	// Use this for initialization
	void Start () {

        for (int i = 0; i < decorationCount; i++)
        {
            spawnDecoration();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void spawnDecoration()
    {
        Bounds b = new Bounds(floor.transform.position, Vector3.zero);
        b.Encapsulate(floor.GetComponent<Renderer>().bounds);
        float x = Random.Range(b.center.x - b.size.x / 2, b.center.x + b.size.x / 2);
        float y = Random.Range(b.center.y - b.size.y / 2, b.center.y + b.size.y / 2);
        float z = Random.Range(b.center.z - b.size.z / 2, b.center.z + b.size.z / 2);
        Vector3 randomPos = new Vector3(x, y, z);

        GameObject obj = Instantiate(getRandomShroom(), randomPos, Quaternion.identity, transform);
    }
    GameObject getRandomShroom()
    {

        return Decorations[(int)Random.Range(0, Decorations.Length)];
    }
}
