using UnityEngine;
using System.Collections;

public class level1objective : MonoBehaviour {
	
	// We'll use this class to keep track of what objectives there will be in the intro level, level 0.
	// This will be attached to the player for any particular level.
	
	// Use this for initialization
	GameObject obi;
	GameObject obj;
	
	void Start () {
		obi = GameObject.Find ("StartPointSprite");	// find and store a reference to the startpoint.
		obj = GameObject.Find ("EndPointSprite");	// find and store a reference to the endpoint.

		obi.SendMessage ("conditionMetTrue"); // broadcast a "true" since intro level has nothing.
		obj.SendMessage ("conditionMetTrue"); // broadcast a "true" since intro level has nothing.

	}
	
	// Update is called once per frame
	void Update () {
		// no need for an update.
	}
}
