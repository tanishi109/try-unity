using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Camera mainCam;
	public float speed;

	void FixedUpdate() {
		if (gameObject.CompareTag ("Player")) {
			InputByPlayer ();
		} else {
			InputByAI ();
		}

		if (gameObject.CompareTag ("Player")) {
		} else {
			UpdateForAI ();
		}

		RespawnIfFall ();
	}

	void InputByPlayer() {
		float inputHorizontal = Input.GetAxis("Horizontal");
		float inputVertical = Input.GetAxis("Vertical");

		Vector3 forward = mainCam.transform.forward;
		Vector3 right = mainCam.transform.right;

		forward.y = 0f;
		right.y = 0f;
		forward.Normalize();
		right.Normalize();

		Vector3 desiredMoveDirection = forward * inputVertical + right * inputHorizontal;

		if (inputHorizontal != 0 || inputVertical != 0) {
			transform.position += desiredMoveDirection * speed * Time.deltaTime;

			Quaternion targetRotation = Quaternion.LookRotation (desiredMoveDirection * speed * Time.deltaTime, Vector3.up);
			Quaternion newRotation = Quaternion.Lerp (transform.rotation, targetRotation, 15f * Time.deltaTime);

			transform.rotation = newRotation;
		}
	}

	void InputByAI() {
		float horizontal = 0.0f;
		float vertical = 1.0f;

		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		foreach(GameObject p in players) {
			Vector3 distance = p.transform.position - transform.position;

			horizontal = distance.normalized.x;
			vertical = distance.normalized.z;

//			print ("x = " + distance.normalized.x + ", z = " + distance.normalized.z);
		}
			
		// mainCamじゃなくてgameObject.transformにしたら向いてる方向基準でInput制御になる。カメラは不要になる
		Vector3 forward = gameObject.transform.forward;
		Vector3 right = gameObject.transform.right;

		forward.y = 0f;
		right.y = 0f;
		forward.Normalize();
		right.Normalize();

		Vector3 desiredMoveDirection = forward * vertical + right * horizontal;

		if (horizontal != 0 || vertical != 0) {
			transform.position += desiredMoveDirection * speed * Time.deltaTime;

			Quaternion targetRotation = Quaternion.LookRotation (desiredMoveDirection * speed * Time.deltaTime, Vector3.up);
			Quaternion newRotation = Quaternion.Lerp (transform.rotation, targetRotation, 15f * Time.deltaTime);

			// TODO: 開店した時に正しくプレイヤーに向かわせるにはどうすればいい？
//			transform.rotation = newRotation;
		}
	}

	void UpdateForAI() {
	}

	void RespawnIfFall() {
		if (transform.position.y < -20f) {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero; 
			transform.position = new Vector3 (0f, 4f, -2.5f);
		}
	}
}

//class Command {
//	public static H _H = new H ();
//	public static V _V = new V ();
//
//	public virtual void exec(PlayerModel player, float axis) {}
//}
//
//
//class H : Command {
//	public override void exec(PlayerModel player, bool isKeyDown) {
//		player.GrowLeg (0, isKeyDown);
//	}
//}
//
//class V : Command {
//	public override void exec(PlayerModel player, bool isKeyDown) {
//		player.GrowLeg(2, isKeyDown);
//	}
//}
