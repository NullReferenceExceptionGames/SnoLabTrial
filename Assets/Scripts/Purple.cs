using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player" && coll.gameObject.GetComponent<Radiation_Shield>().shield) {
			coll.gameObject.GetComponent<Radiation_Shield> ().PermanentlyDisable ();
		}
	}
}
