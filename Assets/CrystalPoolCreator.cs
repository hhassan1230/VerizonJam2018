using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrystalPoolCreator : MonoBehaviour {
    //public GameObject[] CrystalPool;
    public GameObject[] crystalPrefabs;

    public CrystalMaker crystalScript;
    public GameEvent onTunnelSpawn;
    public float heightMax = 0.4f;

    public GetRandomPointInTunnel point;


    public List<GameObject> CrystalPool = new List<GameObject>();


    public int PoolSize ;
    private int Poolindex = 0;
	// Use this for initialization
	void Awake () {
        for (int i = 0; i < PoolSize; i++)
        {
            PoolRandomCrystal();
        }
        print("CrystalPool SIZE: " + CrystalPool.Count);
	}

    private void OnEnable()
    {
        onTunnelSpawn.e += SpawnCrystal;
    }
    private void OnDisable()
    {
        onTunnelSpawn.e -= SpawnCrystal;
    }

    private void SpawnCrystal() 
    {
        if (Poolindex < PoolSize)
        {

            int spawnedNumber = UnityEngine.Random.Range(1, 7);
            for (int i = 0; i < spawnedNumber; i++)
            {
                Vector3 p = point.getPoint();
                p.y = UnityEngine.Random.Range(p.y + 0.2f, heightMax);

                print(CrystalPool.Count);

                GameObject CurrentSpawnCrystal = CrystalPool[Poolindex];
                CurrentSpawnCrystal.transform.position = p;
                CurrentSpawnCrystal.SetActive(true);

                Poolindex++;
            }
        }
        else {
            SceneManager.LoadScene(0);
        }
    }

    public void PoolRandomCrystal()
    {

        int randomIndex = UnityEngine.Random.Range(0, crystalPrefabs.Length);
        Quaternion rot = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(-180, 180), UnityEngine.Random.Range(-180, 180), UnityEngine.Random.Range(-180, 180)));

        GameObject CurrentCrystal = Instantiate(crystalPrefabs[randomIndex], Vector3.zero, rot);
        CurrentCrystal.SetActive(false);
        CrystalPool.Add(CurrentCrystal);

    }
}
