using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Entity {

	[SerializeField] private GameObject player;
	
	void Start () {
		defaultFacingLeft = true;
	}

	// Update is called once per frame
	void Update () {
		float d = Vector2.Distance (transform.position, player.transform.position);
		if (player.transform.position.x > transform.position.x) {
			rb.velocity = new Vector2 (0.5f, rb.velocity.y);
		} else if (player.transform.position.x < transform.position.x) {
			rb.velocity = new Vector2 (-0.5f, rb.velocity.y);
		}
		if (d < 1.2f && Random.value > 0.9f) {
			Jump (150);
		}
	}

	public void Squash () {
		Destroy (gameObject);
	}
}
