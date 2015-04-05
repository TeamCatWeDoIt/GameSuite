using UnityEngine;
using System.Collections;

public class GlobalManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// Make sure this game object is not destroyed.
		DontDestroyOnLoad(transform.gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
