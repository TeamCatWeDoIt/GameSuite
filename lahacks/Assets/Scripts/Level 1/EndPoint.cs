using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player") 
		{
			Application.LoadLevel("level2");		// on collision sends this to the player
		}
	}
}
