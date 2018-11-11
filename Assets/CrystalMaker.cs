using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMaker : MonoBehaviour {
    public GameObject[] crystalPrefabs;
    public GetRandomPointInTunnel point;
    public int count;
    public float heightMax = 0.4f;
    public FloatRange scaleRange;
    // Use this for initialization
    void Start () {
		for(int i = 0; i < count; i++)
        {
            getRandomCrystal();
        }
	}
    public GameObject getRandomCrystal()
    {
        Vector3 p = point.getPoint();
        p.y = Random.Range(p.y + 0.2f, heightMax);
        int randomIndex = Random.Range(0, crystalPrefabs.Length);
        Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180)));

        GameObject obj = Instantiate(crystalPrefabs[randomIndex], p, rot, transform);
        float s = scaleRange.random;
        obj.transform.localScale = new Vector3(s, s, s);
        return obj;
    }

}
