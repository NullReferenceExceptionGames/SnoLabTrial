using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour {

	private bool activated = false;

	public bool Activated {
		get {
			return activated;
		}
		set {
			activated = value;
			if (value) {
				GetComponent<AudioSource> ().enabled = true;
			}
		}
	}
}
