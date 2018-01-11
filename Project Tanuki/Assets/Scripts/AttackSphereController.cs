using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSphereController : MonoBehaviour {

	private Rigidbody myRb;

	void Awake () {
		myRb = gameObject.GetComponentInParent<Rigidbody> ();
	}

	void OnTriggerStay (Collider other) {
		// TODO
		// めり込み防止したい
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Hittable")) {
			AttackCollisionController controller = gameObject.GetComponentInParent<AttackCollisionController>();
			PlayerModel myPlayer = gameObject.GetComponentInParent<PlayerModel>();
			PlayerModel otherPlayer = other.gameObject.GetComponentInParent<PlayerModel>();

			int winner = controller.GetWinner (myPlayer.GetMimicType(), otherPlayer.GetMimicType());

			if (winner == 1) {
				controller.KnockbackMe (other.gameObject, 200.0f);
				print ("lose");
			}
			if (winner == 0) {
				print ("win");
			}
			if (winner == -1) {
				print ("drawn");
				controller.KnockbackMe (other.gameObject, 100.0f);
			}
		}
	}
}
