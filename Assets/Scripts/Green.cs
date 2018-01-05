using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player" && coll.gameObject.GetComponent<Radiation_Shield>().shield == false) {
			coll.gameObject.GetComponent<Player>().HP = 0;	
		}
	}
}
