using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemList : MonoBehaviour {

	public GameObject[] lootList;
	public GameObject parentName;
	GameObject randomDrop;
	int index;


	void Awake ()
	{
		index = Random.Range (0, lootList.Length);
		randomDrop = lootList[index];

		GameObject myNewDrop = Instantiate (randomDrop, transform.position, transform.rotation) as GameObject;
		myNewDrop.transform.parent = parentName.transform;
		myNewDrop.transform.localPosition = new Vector3(0, 0, 0);
		myNewDrop.transform.localRotation = Quaternion.Euler(270, 0, 0);

		if(myNewDrop.GetComponent<AudioSource>() != null)
		{
			myNewDrop.GetComponent<AudioSource>().Play ();
		}

	}

	
	void RandomizeLoot()
	{
		index = Random.Range (0, lootList.Length);
		randomDrop = lootList[index];
	}
}	