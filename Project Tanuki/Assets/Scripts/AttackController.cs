using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			print ("***fire!");
		}
	}
}
