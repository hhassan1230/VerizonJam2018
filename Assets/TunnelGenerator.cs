using NVIDIA.Flex;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGenerator : MonoBehaviour {
    public GameObject tunelPrefab;

    public List<GameObject> tunels = new List<GameObject>();
    GameObject lastTunel { get { return tunels[tunels.Count - 1]; } }
    public int tunnelsCount;

    public float angleRange;

    bool isDestroy = false;
    public GameEvent callTunnelCreated;
	// Use this for initialization
	void Start () {
        for(int i = 0; i < tunnelsCount; i++)
        {
            SpawnTunnel();
        }
    }

    private void OnTunnelDestroy(Collider col)
    {
        if (col.tag == "Player")
        {
            isDestroy = true;
        }
    }

    public void OnTunnelSpawn(Collider col)
    {
        if(col.tag == "Player")
        {
            SpawnTunnel();
        }
    }

    public void SpawnTunnel()
    {
        Vector3 pos = Vector3.zero;
       
        Quaternion rot = Quaternion.identity;
        if (tunels.Count > 0)
        {
            GameObject prev = tunels[tunels.Count - 1];
            TunnelControl tPrev = prev.GetComponent<TunnelControl>();

            pos = tPrev.spawnPoint.transform.position;
        }

        GameObject obj = Instantiate(tunelPrefab, pos, rot, transform);
        if (tunels.Count > 0) {
            TunnelControl t = obj.GetComponent<TunnelControl>();

            GameObject prev = tunels[tunels.Count - 1];
            TunnelControl tPrev = prev.GetComponent<TunnelControl>();

            t.spawnTrigger.onTriggerEnter += OnTunnelSpawn;
            t.removeTrigger.onTriggerEnter += OnTunnelDestroy;
        }

        tunels.Add(obj);
        //spawnTrigger.onTriggerEnter += OnTunnelSpawn;
        //destroyTrigger.onTriggerEnter += OnTunnelDestroy;
        callTunnelCreated.Invoke();
    }

    public void DestroyTunnel()
    {
        GameObject obj = tunels[0];
        TunnelControl t = obj.GetComponent<TunnelControl>();
        t.spawnTrigger.onTriggerEnter -= OnTunnelSpawn;
        t.removeTrigger.onTriggerEnter -= OnTunnelDestroy;

        FlexSoftActor[] actors = obj.GetComponentsInChildren<FlexSoftActor>();
     
        tunels.Remove(obj);
        Destroy(obj);
    }
	// Update is called once per frame
	void LateUpdate () {
        if (isDestroy)
        {
            DestroyTunnel();
            isDestroy = false;
        }
	}
}
