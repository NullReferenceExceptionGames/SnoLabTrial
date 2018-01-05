using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatVent : MonoBehaviour {

	[SerializeField] private GameObject rat;
	[SerializeField] private Computer comp;
	[SerializeField] private uint noRats;
	
	// Update is called once per frame
	void FixedUpdate () {
		if (comp.Activated) {
			for (int i = 0; i < noRats; i++)
				SpawnRat ();
			Destroy (this);
		}
	}

	private void SpawnRat () {
		GameObject r = Instantiate (rat);
		r.transform.position = transform.position;
	}
}
