using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private SpriteRenderer sp;
	private Vector3 playerPos;
	private Vector3 projectileDirection;
	private bool dead = false;
	[SerializeField] private List<Sprite> sprites;
	[SerializeField] private GameObject proj;
	[SerializeField] private Transform player;
	[SerializeField] private Computer comp;
	[SerializeField] private float multiplier = 1;

	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer> ();
	}

	void FixedUpdate() {
		if (comp.Activated && !dead) {
			dead = true;
			InvokeRepeating ("UpdatePlayerRegistry", 0f, 1f);
			InvokeRepeating ("Fire", 0f, 5f);
		}
	}

	void UpdatePlayerRegistry() {
		playerPos = player.transform.position;
		projectileDirection = (playerPos - transform.position).normalized;
		if (projectileDirection.y < 0) {
			projectileDirection.y = 0;
		}
		if (projectileDirection.x > 0) {
			sp.flipX = true;
		}
		if (Mathf.Abs (projectileDirection.x - projectileDirection.y) > 0.35f) {
			sp.sprite = sprites [2];
		} else if (Mathf.Abs (projectileDirection.x - projectileDirection.y) < 0.1f) {
			sp.sprite = sprites [0];
		} else {
			sp.sprite = sprites [1];
		}
	}

	void Fire() {
		GameObject b = Instantiate (proj);
		b.transform.position = transform.position;
		b.GetComponent<Rigidbody2D> ().AddForce (projectileDirection * 100 * multiplier);
	}
}
