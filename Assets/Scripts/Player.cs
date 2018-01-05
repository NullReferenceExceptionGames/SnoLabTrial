using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity {

	private GameObject[] comp;
	public int HP = 20; 
	[SerializeField] private GameObject textSystem;
	private List<Vector2> history;

	void Start () {
		comp = GameObject.FindGameObjectsWithTag ("Comp");
		history = new List<Vector2> ();
		//InvokeRepeating ("PrintVals", 0f, 5f);
    }
    
	
	protected override void FixedUpdate() {
		anim.SetBool ("IsWalking", (rb.velocity.x != 0));
		base.FixedUpdate ();
		//history.Add (transform.position);
	}

	void PrintVals() {
		string d = "", e = "";
		foreach (Vector2 v in history) {
			d += (v.x.ToString() + ", ");
			e += (v.y.ToString() + ", ");
		}
		print (d);
		print (e);
	}
    

	// Update is called once per frame
	void Update () {
		if (textSystem != null) {
			transform.FindChild ("Main Camera").transform.localPosition = new Vector3 (0f, -1f, -10f);
			return;
		} else {
			transform.FindChild ("Main Camera").transform.localPosition = new Vector3 (0f, 0f, -10f);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump (250);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			rb.velocity = new Vector2 (2.5f, rb.velocity.y);
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			rb.velocity = new Vector2 (-2.5f, rb.velocity.y);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			foreach (GameObject g in comp) {
				if (Vector2.Distance (g.transform.position, transform.position) < 1f) {
					g.GetComponent<Computer> ().Activated = true;
				}
			}
		}
	}

	protected override void OnCollisionEnter2D (Collision2D coll) {
		base.OnCollisionEnter2D (coll);
		if (coll.gameObject.tag == "Rat") {
			if (coll.collider.bounds.max.y - bc.bounds.min.y < 0.1f) {
				coll.gameObject.GetComponent<Rat> ().Squash ();
			}
				
			else {
				HP -= 1;
			}
				
		}
        if (coll.gameObject.tag == "Proj")
        {
			HP = 0;
        }
        if (HP < 1) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        }
    }
}
