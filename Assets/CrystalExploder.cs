using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Exploder.Utils;

public class CrystalExploder : MonoBehaviour {
    bool isFirst = true;
    void Start()
    {

        
        //Invoke("DestroyVentSelf", 2f);

    }

    public void DestroyVentSelf()
    {
        ExploderSingleton.Instance.ExplodeCracked(gameObject);
    }

    private void Update()
    {
        if (isFirst)
        {
            ExploderSingleton.Instance.CrackObject(gameObject);
            isFirst = false;
        }
    }

}
