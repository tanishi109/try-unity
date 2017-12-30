using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrower : MonoBehaviour {
	private Animator animator;
	public string key;

	void Awake ()
	{
		animator = GetComponent<Animator> ();
	}

	void Update()
	{
		if (Input.GetKey (key)) {
			animator.SetBool ("IsGrowing", true);
		} else {
			animator.SetBool ("IsGrowing", false);
		}
	}
}
