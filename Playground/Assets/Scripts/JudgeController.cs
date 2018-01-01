using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeController : MonoBehaviour {
	private GameObject[] fingers1;
	private GameObject[] fingers2;
	private GameObject player1;
	private GameObject player2;

	private void OnEnable()
	{
		fingers1 = new GameObject[] {
			GameObject.Find ("/Player/Left"),
			GameObject.Find ("/Player/Center"),
			GameObject.Find ("/Player/Right")
		};
		fingers2 = new GameObject[] {
			GameObject.Find ("/Player2/Left"),
			GameObject.Find ("/Player2/Center"),
			GameObject.Find ("/Player2/Right")
		};
		player1 = GameObject.Find ("/Player");
		player2 = GameObject.Find ("/Player2");
	}

	private void Update()
	{
		int winner = GetWinner();

		if (winner == 1) {
			PlayerHealth ph = player2.GetComponent<PlayerHealth> ();
			ph.TakeDamage ();
		}
		if (winner == 2) {
			PlayerHealth ph = player1.GetComponent<PlayerHealth> ();
			ph.TakeDamage ();
		}
	}

	private int GetWinner()
	{
		int weapon1 = GetWeapon (fingers1);
		int weapon2 = GetWeapon (fingers2);

		if (weapon1 == weapon2) {
			return 0; // drawn game
		}

		bool is2Win = (weapon1 - weapon2 + 3) % 3 == 1;

		if (is2Win) {
			return 2;
		}

		return 1;
	}

	private int GetWeapon(GameObject[] fingers)
	{
		int fcount = 0;
		foreach (GameObject f in fingers) {
			PlayerGrower pg = f.GetComponent<PlayerGrower> ();
			if (pg.length >= 30f) {
				fcount += 1;
			}
		}
		if (fcount == 0) {
			return 0; // Rock
		}
		if (fcount == 2) {
			return 1; // Scissors
		}
		if (fcount == 3) {
			return 2; // Paper
		}

		return 0;
	}
}
