using Exploder.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMaker : MonoBehaviour {
    public GameObject[] crystalPrefabs;
    public GetRandomPointInTunnel point;
    public int count;
    public float heightMax = 0.4f;
    public FloatRange scaleRange;
    public GameEvent onTunnelSpawn;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < count; i++)
        {
            getRandomCrystal();
        }
    }

    private void OnEnable()
    {
        onTunnelSpawn.e += OnTunnelSpawn;
    }
    private void OnDisable()
    {
        onTunnelSpawn.e -= OnTunnelSpawn;
    }

    private void OnTunnelSpawn()
    {
        //getRandomCrystal*/();
        // tunnel created you can use point.getPoint() to get random point on current tunnel plane
    }

    public GameObject getRandomCrystal()
    {
        Vector3 p = point.getPoint();
        p.y = UnityEngine.Random.Range(p.y + 0.2f, heightMax);
        int randomIndex = UnityEngine.Random.Range(0, crystalPrefabs.Length);
        Quaternion rot = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(-180, 180), UnityEngine.Random.Range(-180, 180), UnityEngine.Random.Range(-180, 180)));

        GameObject obj = Instantiate(crystalPrefabs[randomIndex], p, rot, transform);

        CrystalExploder ce = obj.AddComponent<CrystalExploder>();
        //ExploderSingleton.Instance.crack

        obj.tag = "Exploder";


        float s = scaleRange.random;
        obj.transform.localScale = new Vector3(s, s, s);
        return obj;
    }

}
