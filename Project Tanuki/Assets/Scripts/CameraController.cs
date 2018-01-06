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
		offset = new Vector3(player.transform.position.x, player.transform.position.y + 8.0f, player.transform.position.z + 7.0f);
	}

	void LateUpdate()
	{
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		offset.y = (Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeedY * -1f, Vector3.right) * offset).y;
		transform.position = player.transform.position + offset;
		transform.LookAt(player.transform.position);
	}
}
