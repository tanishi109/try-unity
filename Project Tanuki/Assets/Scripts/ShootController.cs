using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

	public int gunDamage = 1;
	public float fireRate = .25f;
	public float weaponRange = 10f;
	public float hitForce = 100f;
	public Transform shotOrigin;
	public Camera mainCam;

	private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
	private LineRenderer laserLine;
	private float nextFire; 



	void Start () {
		laserLine = GetComponent<LineRenderer>();
	}

	void Update () {
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			StartCoroutine (ShotEffect());

			Vector3 rayOrigin = mainCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

			RaycastHit hit;

			laserLine.SetPosition (0, shotOrigin.position);

			if (Physics.Raycast (rayOrigin, mainCam.transform.forward, out hit, weaponRange)) {
				laserLine.SetPosition (1, hit.point);
			} else {
				laserLine.SetPosition (1, rayOrigin + (mainCam.transform.forward * weaponRange));
			}
		}
	}

	private IEnumerator ShotEffect() {
		laserLine.enabled = true;

		yield return shotDuration;

		laserLine.enabled = false;
	}

}
