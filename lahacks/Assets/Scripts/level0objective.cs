using UnityEngine;
using System.Collections;

public class level0objective : MonoBehaviour {

	// We'll use this class to keep track of what objectives there will be in the intro level, level 0.
	// This will be attached to the player for any particular level.

	// Use this for initialization

	GameObject obj;

	void Start () {
		obj = GameObject.Find ("EndpointSprite");	// find and store a reference to the endpoint.
		obj.SendMessage ("conditionMetTrue"); // broadcast a "true" since intro level has nothing.
	
	}
	
	// Update is called once per frame
	void Update () {
		// no need for an update.
	}
}
