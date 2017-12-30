using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrower : MonoBehaviour {
	private Animator animator;

	void Awake ()
	{
		animator = GetComponent<Animator> ();
	}

	void Update()
	{
		if (Input.GetKey ("space")) {
			animator.SetBool ("IsGrowing", true);
		} else {
			animator.SetBool ("IsGrowing", false);
		}
	}
}
