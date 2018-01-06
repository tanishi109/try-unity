using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Camera mainCam;
	public float speed;

	void FixedUpdate() {
		float inputHorizontal = Input.GetAxis("Horizontal");
		float inputVertical = Input.GetAxis("Vertical");

		Vector3 forward = mainCam.transform.forward;
		Vector3 right = mainCam.transform.right;

		forward.y = 0f;
		right.y = 0f;
		forward.Normalize();
		right.Normalize();

		Vector3 desiredMoveDirection = forward * inputVertical + right * inputHorizontal;

		transform.position += desiredMoveDirection * speed * Time.deltaTime;

		if (inputHorizontal != 0 || inputVertical != 0) {
			Quaternion targetRotation = Quaternion.LookRotation (desiredMoveDirection * speed * Time.deltaTime, Vector3.up);
			Quaternion newRotation = Quaternion.Lerp (transform.rotation, targetRotation, 15f * Time.deltaTime);

			transform.rotation = newRotation;
		}
	}
}
