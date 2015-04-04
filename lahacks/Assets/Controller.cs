using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	GameObject go;		// finds the player object
	Rigidbody goY;		// Gets the rigidbody

	GameObject begin;		// finds the start object
	Rigidbody beginY;		// Gets the rigidbody
	
	bool jumping;		// Initialize variable for jump
	int maxHealth;		// max total of health the character can have
	int health;			// how much health does the character now
	int jumpHeight;

	bool facingRight;

	bool canPickUp;		
	bool holdingItem;
	GameObject itemToHold;
	Vector3 objectDist;

	// Use this for initialization
	void Start () {
		Flip ();			// flip the  sprite
		jumping = false; 	// we are not jumping at the beginning
		maxHealth = 10;
		health = maxHealth;		// starting health set here.
		jumpHeight = 20;		// change to increase height of jump

		go = GameObject.Find ("Player");			// finds the player object
		goY = go.GetComponent<Rigidbody> ();		// 

		begin = GameObject.Find ("StartPoint");			// finds the start object
		beginY = go.GetComponent<Rigidbody> ();		// 

		facingRight = true;					// character starts facing right

		canPickUp = false;
		holdingItem = false;		
	}

	
	
	// Update is called once per frame
	void Update () {

		if (health == 0) {
			this.transform.position = begin.transform.position;
			health = maxHealth;

		}

		if (holdingItem == true) {

			itemToHold.transform.position = this.transform.position - objectDist;

		}
	
		// Very crude controller
			
		if (Input.GetKeyDown ("up") && !jumping ) {
			print("Jump!");
			// I would like to have a very smooth "jump"
			//this.transform.position+= Vector3.up * 0.2F; 
			jumping = true;
			StartCoroutine("Jump");
		

		}

		 if (Input.GetKey ("right")) {
			//print("Forward!");
			//this.transform.position+= Vector3.right * 0.2F;
			goY.AddForce(Vector3.right * 20.0f);
			if (!facingRight)
			{
				Flip ();
			facingRight = true;			// facing right
			}


		}

		 if (Input.GetKey ("left")) {
			//print("Forward!");
			goY.AddForce(Vector3.left * 20.0f);
			if (facingRight)
			{
				Flip ();
				facingRight = false;			// facing right
			}
		}

		 if (Input.GetKey ("down")) {
			//print("Down!!");
			goY.AddForce(Vector3.down * 50.0f);
		}

		if (Input.GetKeyDown ("space") && canPickUp && !holdingItem) {

			print ("Attempting to pickup.");
			holdingItem = true;

			// Freeze the position between the two objects while space is held down 
			 objectDist = itemToHold.transform.position - this.transform.position;
		}

		else if (Input.GetKeyDown ("space") && holdingItem) {
			
			print ("Attempting to drop.");
			holdingItem = false;
		}





	}

	void Flip()
	{	
		// Multiply the player's x local scale by -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	
	IEnumerator Jump() {

		goY.AddForce(Vector3.up * 350.0f);					// Applies a force in the up
		yield return null;									// return
	}

	void OnCollisionEnter(Collision collision) {

		// On collision, allow character to jump again. (wall jumps)
		jumping = false;


		// Check for endpoint (crude, could be done better)
		if (collision.gameObject.name == "EndPoint")
		{
			print ("END LEVEL"); 	// print to console

			// Some code to bring us to the start point of a level
			// Load new level
		
		}

		if (collision.gameObject.name == "Terrain")
		{
			print ("Fell out of stage!"); 	// print to console
			this.health = 0; // kill character instantly
			
			// Some code to bring us to the start point of a level
			// Load new level
			
		}

		if (collision.gameObject.name.Contains("dmg"))
		{
			print ("Taking Damage"); 	// print to console
			this.health--;
			
			// Some code to bring us to the start point of a level
			// Load new level
			
		}

		if (collision.gameObject.name.Contains("pickUp"))
		{

			canPickUp = true;
			itemToHold = GameObject.Find(collision.gameObject.name);

			print ("Can pick up: " + itemToHold.name); 	// print to console
			
			// Some code to bring us to the start point of a level
			// Load new level
			
		}

	
	}

	void OnCollisionExit(Collision collisionInfo) {
		print("No longer in contact with " + collisionInfo.transform.name);

		if (collisionInfo.transform.name.Contains("pickUp"))
		{
			print ("OutOfRange!"); 	// print to console
			canPickUp = false;
		}
		
		
		
	}

}