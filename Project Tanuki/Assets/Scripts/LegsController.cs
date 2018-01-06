using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsController : MonoBehaviour {

	private Transform[] legs;
	private float legSpeed = 0.5f;
	private float legShrinkSpeed = 1.0f;

	void Awake () {
		legs = gameObject.GetComponentsInChildren<Transform> ();
	}
	
	void Update () {
		ScaleLegs ();
	}

	void ScaleLegs() {
		int[] legsN = new int[] { 1, 2, 3 };
		foreach (int n in legsN) {

			Vector3 newScale = legs [n].localScale;
			if (Input.GetKey (n.ToString ())) {
				newScale += new Vector3 (0, 0, legSpeed);
			} else {
				newScale -= new Vector3 (0, 0, legShrinkSpeed);
			}
			if (newScale.z > 5.0f) {
				newScale.z = 5.0f;
			}
			if (newScale.z < 1.0f) {
				newScale.z = 1.0f;
			}
			legs [n].localScale = newScale;
		}
	}
}
