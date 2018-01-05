using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radiation_Shield : MonoBehaviour {
	public bool shield = false;
	private bool permdis = false;
	private Animator anim;
	[SerializeField] private RuntimeAnimatorController shielded, normal;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.runtimeAnimatorController = normal;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (permdis)
			return;
		if (Input.GetKeyDown(KeyCode.DownArrow))
			shield = !shield;
		if (shield) {
			anim.runtimeAnimatorController = shielded;
		} else {
			anim.runtimeAnimatorController = normal;		
		}
	}

	public void PermanentlyDisable() {
		anim.runtimeAnimatorController = normal;
		shield = false;
		permdis = true;
	}
}
