using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	[SerializeField] private Computer comp;

	void Start() {
		if (comp == null)
			Destroy (this);
	}

	void FixedUpdate () {
		if (comp.Activated) {
			if (GetComponent<Rigidbody2D> () == null)
				gameObject.AddComponent<Rigidbody2D> ();
			transform.position += new Vector3 (0f, 0f, 1f);
			Invoke ("KillObject", 1f);
			Destroy (GetComponent<Collider2D> ());
		}
	}

	private void KillObject () {
		Destroy(gameObject);
	}
}
