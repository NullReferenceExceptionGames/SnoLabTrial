using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		Invoke ("End", 0.2f);
	}

	private void End() {
		Destroy (gameObject);
	}
}
