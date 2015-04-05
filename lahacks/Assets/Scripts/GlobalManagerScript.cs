using UnityEngine;
using System.Collections;

public class GlobalManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject g = GameObject.Find ("GlobalGameManager");

		if (g == null) {

			DontDestroyOnLoad(transform.gameObject);
		}


		// Make sure this game object is not destroyed.

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
