using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingForPlayer : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var camScript = GameObject.FindWithTag("MainCamera").GetComponent<CustomCameraShake>();
            StartCoroutine(camScript.Shake(.15f, .6f));
        }
    }
}
