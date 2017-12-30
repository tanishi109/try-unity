using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeController : MonoBehaviour {
	private GameObject center;

	// Use this for initialization
	void Start () {
		center = GameObject.Find ("/Player/Center");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerGrower playerGrower = center.GetComponent<PlayerGrower>();
		print (playerGrower.key);
	}
}
