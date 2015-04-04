using UnityEngine;
using System.Collections;

public class Flower : Item {

	// Use this for initialization
	void Start () {

		damage = 0;			// flowers shouldn't do any damage!

	}
	
	// Update is called once per frame
	void Update () {

		// wither or something
	
	}

	void OnCollisionEnter(Collision collision)
	{
		// collision.gameObject.SendMessage ("takeDamage", damage);		// on collision sends this to the player

		if (collision.gameObject.name == "Player") {
			// print ("Picked up");
			collision.gameObject.SendMessage ("pickedUp", this.gameObject);		// sends player a "pickedUp" message with item NAME
			Destroy (this.gameObject);
		}
	}

}
