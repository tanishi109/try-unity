using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionController : MonoBehaviour {

	private PlayerModel player;

	void Awake () {
		player = GetComponentInParent<PlayerModel> ();
	}

	public int GetWinner(int t0, int t1) {
		print (t0 + "vs" + t1);

		if (t0 == -1 && t1 != -1) {
			return 1; // guarded
		}
		if (t0 != -1 && t1 == -1) {
			return 0; // guarded
		}

		if (t0 == t1) {
			return -1; // drawn game
		}

		bool is1Win = (t0 - t1 + 3) % 3 == 1;

		if (is1Win) {
			return 1;
		}

		return 0;
	}


	public void KnockbackMe (GameObject otherGameObject, float power) {
		Vector3 f = gameObject.transform.position - otherGameObject.transform.position;
		f *= power;
		f.y = 0f;
//		gameObject.transform.position += f * 10f * Time.deltaTime;
		gameObject.GetComponent<Rigidbody> ().AddForce(f);
	}
}
