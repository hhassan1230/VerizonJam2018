using UnityEngine;
using System.Collections;

public class PlayerLoot : MonoBehaviour {


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "loot")
		{
			Destroy(other.transform.root.gameObject);
			//Destroy(other.gameObject);
			GetComponent<AudioSource>().Play();
		}
	}
}
