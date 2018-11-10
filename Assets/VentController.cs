using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Exploder.Utils;

public class VentController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        ExploderSingleton.Instance.CrackObject(gameObject);
        Invoke("DestroyVentSelf", 2f);
    }

    public void DestroyVentSelf()
    {
        ExploderSingleton.Instance.ExplodeCracked(gameObject);
    }

}
