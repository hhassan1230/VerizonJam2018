using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelControl : MonoBehaviour {
    [Header("Triggers")]
    public TriggerDelegate spawnTrigger;
    public TriggerDelegate removeTrigger;

    [Header("Next plane spawn")]
    public GameObject spawnPoint;

    [Header("Mushrooms")]
    public GameObject[] mushroomPrefabs;
    public int mushroomCount = 5;
    public GameObject floor;

    [Header("Crystals")]
    public GameObject[] crystalPrefabs;

    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < mushroomCount; i++)
        {
            CreateMushroom();
        }
    }

    private void CreateMushroom()
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
        
        return mushroomPrefabs[Random.Range(0, mushroomPrefabs.Length)];
    }
    // Update is called once per frame
    void Update()
    {

    }
}
