using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chest : MonoBehaviour {

	public string[] lootObjectName;
	public float dropRate = 0.1f;
	
	bool opened = false;
	Animator m_Animator;
	Transform chestTransform;


	void Start()
	{
		m_Animator = GetComponent<Animator>();
		chestTransform = transform;
	}


	void OnMouseDown()
	{
		if (opened == false)
			{
				m_Animator.SetBool("openchest", true);
				opened = true;
			}

		else 
			{
			Debug.Log ("Chest is too far");
			}
	}


	void PlaySound() //Animation Event use this
	{
		GetComponent<AudioSource>().Play();
	}


	void SpawnDrops() //Animation Event use this
	{
		StartCoroutine(InstantiateDrops());
	}


	IEnumerator InstantiateDrops()
	{
		for (int i=0; i < lootObjectName.Length; i++)
		{
			int lootObjectIndex = i;

			GameObject mylootDrop = Instantiate(Resources.Load(lootObjectName[lootObjectIndex])) as GameObject;

			mylootDrop.transform.localPosition = this.transform.position;
			mylootDrop.transform.rotation = Quaternion.Euler( 0, Random.Range((chestTransform.rotation.y) -180, chestTransform.rotation.y + 180) , 0);

			yield return new WaitForSeconds(dropRate);
		}
	}




}




