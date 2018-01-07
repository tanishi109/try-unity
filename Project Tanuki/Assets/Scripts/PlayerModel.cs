using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {
	public float[] legStates;

	private float maxLegState = 5.0f;
	private float minLegState = 0.0f;

	void Awake() {
		legStates = new float[] {0f, 0f, 0f};
	}

	public void GrowLeg(int index, float amount) {
		float newState = legStates [index] + amount;

		if (newState > maxLegState) {
			newState = maxLegState;
		}
		if (newState < minLegState) {
			newState = minLegState;
		}

		legStates [index] = newState;
	}

	public Vector3 GetLegScale(int index) {
		return new Vector3 (0.25f, 0.25f, legStates [index] + 1f);
	}

	public int GetMimicType () {
		int extendedLegs = 0;
		foreach (float state in legStates) {
			if (IsExtended(state)) {
				extendedLegs++;
			}
		}

		if (extendedLegs == 0) {
			return 0; // Rock
		}
		if (extendedLegs == 2) {
			return 1; // Scissors
		}
		if (extendedLegs == 3) {
			return 2; // Paper
		}

		return -1; // Other
	}

	private bool IsExtended (float legState) {
		return legState >= maxLegState / 2;
	}
}
