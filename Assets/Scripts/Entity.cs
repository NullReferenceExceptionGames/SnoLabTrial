using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	protected Rigidbody2D rb;
	protected Collider2D bc;
	protected bool defaultFacingLeft = false;

	private bool jumping = false;
	private SpriteRenderer sp;
	protected Animator anim;
	private const float climbMultiplier = 20000f;

	// Use this for initialization
	private void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		bc = GetComponent<Collider2D> ();
		sp = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}

	protected virtual void FixedUpdate() {
		if (rb.velocity.x > 0) {
			sp.flipX = defaultFacingLeft;
		} else if (rb.velocity.x < 0) {
			sp.flipX = !defaultFacingLeft;
		}

			
	}


	protected virtual void OnCollisionEnter2D (Collision2D coll) {
		jumping = false;
	}

	protected void Jump (int force) {
		if (jumping == true)
			return;
		rb.AddForce (new Vector2 (0, force));
		jumping = true;
		anim.SetTrigger ("Jump");
	}
}
