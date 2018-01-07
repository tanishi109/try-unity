using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegsController : MonoBehaviour {

	public GameObject legsObject;
	public GameObject attackSphere;

	private Transform[] legs;
	private float legGrowSpeed = 0.5f;
	private float legShrinkSpeed = -1.0f;
	private Material sphereMaterial;
	private PlayerModel player;

	void Start () {
		legs = legsObject.GetComponentsInChildren<Transform> ();
		sphereMaterial = attackSphere.GetComponent<Renderer> ().material;
		player = GetComponentInParent<PlayerModel> ();
	}
	
	void Update () {
		ScaleLegs ();
		Mimic ();
	}

	void ScaleLegs() {
		int[] legsN = new int[] { 1, 2, 3 };
		foreach (int n in legsN) {
			int index = n - 1;
			if (Input.GetKey (n.ToString ())) {
				player.GrowLeg(index, legGrowSpeed);
			} else {
				player.GrowLeg(index, legShrinkSpeed);
			}
			legs [n].localScale = player.GetLegScale(index);
		}
	}

	void Mimic() {
		int mType = player.GetMimicType ();

		Color[] newCols = new Color[] {Color.blue, Color.white, Color.red, Color.green};
		foreach (int i in new int[] {0, 1, 2, 3}) {
			if (mType == i) {
				Color newCol = newCols[i];
				newCol.a = 0.25f;
				sphereMaterial.color = newCol;
			}
		}
	}
}
