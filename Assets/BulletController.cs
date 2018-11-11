using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;
    public GameObject impact;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("KillSelf");

    }

    private IEnumerator KillSelf() {
        yield return new WaitForSeconds(5f);

        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrust);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MushroomCap")
        {
            // Crystal Gameobject
            other.gameObject.GetComponent<MushroomCapController>().ActivateSpore();
            print("MushCap bam!!");

        }
        else if (other.gameObject.tag == "Mushroom")
        {
            // Crystal Gameobject
            print("MushStem bam!!");

        }
        else if (other.gameObject.tag == "Exploder")
        {
            //if (other.gameObject.name == "Crystal")
            print("Crystal bam bam!!");
            
            other.gameObject.GetComponent<CrystalExploder>().DestroyVentSelf();

            //other.gameObject.GetComponent<Collider>().enabled = false;
            // }
            Instantiate(impact, gameObject.transform.position, gameObject.transform.rotation); // Quaternion.identity
                                                                                               // gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}