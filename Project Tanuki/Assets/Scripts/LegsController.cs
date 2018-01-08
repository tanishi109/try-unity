using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegsController : MonoBehaviour {

	public GameObject legsObject;
	public GameObject attackSphere;

	private Transform[] legs;
	private Material sphereMaterial;
	private PlayerModel player;

	private string[] acceptableKeys;
	private Dictionary<string, Command> commands = new Dictionary<string, Command> ();

	void Start () {
		legs = legsObject.GetComponentsInChildren<Transform> ();
		sphereMaterial = attackSphere.GetComponent<Renderer> ().material;
		player = GetComponentInParent<PlayerModel> ();

		// キーコンフィグ
		acceptableKeys = new string[] {"1", "2", "3", "8", "9", "0"};

		commands[acceptableKeys[0]] = Command._R;
		commands[acceptableKeys[1]] = Command._ZR;
		commands[acceptableKeys[2]] = Command._L;

		commands[acceptableKeys[3]] = Command._R;
		commands[acceptableKeys[4]] = Command._ZR;
		commands[acceptableKeys[5]] = Command._L;
	}
	
	void Update () {
		if (gameObject.CompareTag ("Player")) {
			InputByPlayer ();
		} else {
			InputByAI ();
		}

		SetScale ();
		SetMimic ();
	}

	void InputByPlayer() {
		// 実行したコマンド記録用(実行していないコマンドを判定するのに使用)
		Dictionary<Command, bool> execed = new Dictionary<Command, bool> ();

		foreach (string k in acceptableKeys) {
			if (Input.GetKey (k)) {
				Command cmd = commands [k];
				cmd.exec (player, true);
				execed [cmd] = true;
			}
		}
		// コマンドに対応するいずれのキーも押されていなかったら、キーを押してなかった時の処理を行う
		foreach (string k in acceptableKeys) {
			Command cmd = commands [k];
			if (!Input.GetKey (k) && !execed.ContainsKey(cmd)) {
				cmd.exec (player, false);
			}
		}
	}


	void InputByAI () {
		// ずっとチョキ
		Command._L.exec (player, true);
		Command._R.exec (player, true);
	}

	Transform GetLeg(int index) {
		// legsの[0]は自身のObjectなので, 1から3にleg0 ~ 2がある
		return legs [index + 1];
	}

	void SetScale() {
		foreach(int index in new int[] {0, 1, 2}) {
			GetLeg(index).localScale = player.GetLegScale(index);
		}
	}

	void SetMimic() {
		int mType = player.GetMimicType ();

		if (mType == -1) {
			Color newCol = Color.white;
			newCol.a = 0.0f;
			sphereMaterial.color = newCol;
			return;
		}

		Color[] newCols = new Color[] {Color.blue, Color.red, Color.green};
		foreach (int i in new int[] {0, 1, 2}) {
			if (mType == i) {
				Color newCol = newCols[i];
				newCol.a = 0.25f;
				sphereMaterial.color = newCol;
			}
		}
	}
}

class Command {
	public static L _L = new L ();
	public static R _R = new R ();
	public static ZL _ZL = new ZL ();
	public static ZR _ZR = new ZR ();

	public virtual void exec(PlayerModel player, bool isKeyDown) {}
}


class L : Command {
	public override void exec(PlayerModel player, bool isKeyDown) {
		player.GrowLeg (0, isKeyDown);
	}
}

class R : Command {
	public override void exec(PlayerModel player, bool isKeyDown) {
		player.GrowLeg(2, isKeyDown);
	}
}

class ZL : Command {
	public override void exec(PlayerModel player, bool isKeyDown) {
		player.GrowLeg(1, isKeyDown);
	}
}

// same as ZL
class ZR : Command {
	public override void exec(PlayerModel player, bool isKeyDown) {
		player.GrowLeg(1, isKeyDown);
	}
}
