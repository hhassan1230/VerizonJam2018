using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "GetRandomPointInTunnel")]
public class GetRandomPointInTunnel : ScriptableObject {

    public GameObject reference;

    public Vector3 getPoint()
    {
        if (reference != null)
        {
            Bounds b = new Bounds(reference.transform.position, Vector3.zero);
            b.Encapsulate(reference.GetComponent<Renderer>().bounds);
            float x = Random.Range(b.center.x - b.size.x / 2, b.center.x + b.size.x / 2);
            float y = Random.Range(b.center.y - b.size.y / 2, b.center.y + b.size.y / 2);
            float z = Random.Range(b.center.z - b.size.z / 2, b.center.z + b.size.z / 2);
            return new Vector3(x, y, z);
        }
        Debug.Log("Point in tunnel not found");
        return Vector3.zero;
        
    }
}
