using UnityEngine;
using System.Collections;

public class GlobalManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if (!GameObject.Find ("GlobalGameManager")) {

			DontDestroyOnLoad(transform.gameObject);
		}


		// Make sure this game object is not destroyed.

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
