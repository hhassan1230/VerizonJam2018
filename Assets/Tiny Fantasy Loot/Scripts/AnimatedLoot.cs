using UnityEngine;
using System.Collections;

public class AnimatedLoot : MonoBehaviour {
	
	public bool scale = false;
	public bool rotate = false;
	public bool updown = false;
	public float speed = 1;
	
	Animator m_Animator;


	void Start ()
	
	{
		m_Animator = GetComponent<Animator>();
		m_Animator.SetFloat("Itemspeed", speed);
		m_Animator.SetBool ("drop", true);
		m_Animator.SetBool ("scale", scale);
		m_Animator.SetBool ("rotate", rotate);
		m_Animator.SetBool ("updown", updown);
		m_Animator.SetFloat ("droptype", Random.Range (0f,1.0f));

	}
}


