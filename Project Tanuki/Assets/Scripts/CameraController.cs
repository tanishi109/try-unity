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
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		offset.y = (Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeedY, Vector3.right) * offset).y;
		transform.position = player.transform.position + offset;

		Vector3 lookPoint = player.transform.position;
		lookPoint += new Vector3(0, 3, 0);
		transform.LookAt(lookPoint);
	}
}
