using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrower : MonoBehaviour {
	private Animator animator;
	public string key;
	public float length;

	void Awake ()
	{
		animator = GetComponent<Animator> ();
		length = 60f;
	}

	void Update()
	{
		if (Input.GetKey (key)) {
			animator.SetBool ("IsGrowing", true);
			if (length < 60f) {
				length += 1f * Time.deltaTime * 100;
			} else {
				length = 60f;
			}
		} else {
			animator.SetBool ("IsGrowing", false);
			if (length > 0f) {
				length -= 1f * Time.deltaTime * 100;
			} else {
				length = 0f;
			}
		}
	}
}
