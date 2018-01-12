using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float turnSpeed = 4.0f;
	public float turnSpeedY = 6.0f;

	private Vector3 offset;
			

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		offset = new Vector3(player.transform.position.x, player.transform.position.y + 4.0f, player.transform.position.z + 3.0f);
	}

	void LateUpdate()
	{
		Vector3 newOffset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		newOffset.y = (Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeedY, Vector3.right) * offset).y;
		if (newOffset.y < -6f || newOffset.y > 12f) {
			return;
		}
		offset = newOffset;

		transform.position = player.transform.position + offset;
//		print (offset);

		Vector3 lookPoint = player.transform.position;
		lookPoint += new Vector3(0, 3, 0);
		transform.LookAt(lookPoint);
	}
}
