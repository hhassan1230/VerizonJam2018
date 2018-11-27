using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Exploder.Utils;

public class CrystalExploder : MonoBehaviour {

    public GameObject audioSourceForCystals;

    bool isFirst = true;
    void Start()
    {
        //ExploderSingleton.Instance.CrackObject(gameObject);

        //Invoke("DestroyVentSelf", 2f);

    }

    public void DestroyVentSelf()
    {
        ExploderSingleton.Instance.ExplodeObject(gameObject);

        // ExploderSingleton.Instance.ExplodeCracked(gameObject);
        print("I am checking for sounds");
        if (audioSourceForCystals) {
            Instantiate(audioSourceForCystals, gameObject.transform.position, gameObject.transform.rotation);
        }
        //if (gameObject.GetComponent<AudioSource>()) {
        //    print("It has sound");
        //    gameObject.GetComponent<AudioSource>().Play();
        //}
    }

    private void Update()
    {
        //if (isFirst)
        //{
        //    ExploderSingleton.Instance.CrackObject(gameObject);
        //    isFirst = false;
        //}
    }

}
