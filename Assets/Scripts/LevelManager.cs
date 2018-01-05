using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	[SerializeField] private Computer comp;

	string[] levels = { "Tutorial", "Level 1", "Level 2", "BossLevel" };

	void FixedUpdate() {
		if (comp.Activated) {
			int levelId = System.Array.IndexOf (levels, SceneManager.GetActiveScene ().name);
			SceneManager.LoadScene (levels [levelId + 1]);
		}
	}
}