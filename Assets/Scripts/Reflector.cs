using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflector : MonoBehaviour {

	[SerializeField] Vector2 outputVec;

	void Start() {
		outputVec.Normalize ();
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == "Proj") {
			Rigidbody2D inRb = coll.gameObject.GetComponent<Rigidbody2D> ();
			float speed = inRb.velocity.magnitude;
			inRb.velocity = outputVec * speed;
		}
	}
}
