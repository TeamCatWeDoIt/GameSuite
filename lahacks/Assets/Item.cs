using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	protected int damage;			// some items will have damage on collision
	protected int id;				// each item will have a unique id
	protected string name;		// each item has a name

	// Use this for initialization
	void Start () {

		damage = 1;	// initialize to 1 

	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		collision.gameObject.SendMessage ("takeDamage", damage);		// on collision sends this to the player
	}
}
