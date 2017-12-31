using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeController : MonoBehaviour {
	private GameObject[] fingers1;

	// Use this for initialization
	void Start () {
		fingers1 = new GameObject[] {
			GameObject.Find ("/Player/Left"),
			GameObject.Find ("/Player/Center"),
			GameObject.Find ("/Player/Right")
		};
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject f in fingers1) {
			PlayerGrower playerGrower = f.GetComponent<PlayerGrower>();
			print ("");
			print (playerGrower.key);
			print (playerGrower.length);
		}
	}
}
