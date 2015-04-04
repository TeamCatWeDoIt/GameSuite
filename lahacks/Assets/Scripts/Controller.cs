using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class Controller : MonoBehaviour {

	GameObject go;		// finds the player object and keep an active reference to it
	Rigidbody goY;		// Gets the rigidbody of the player object

	GameObject begin;		// finds the location of the start object

	bool jumping;		// Initialize variable for jump
	
	bool isDead;
	bool facingRight;	

	bool canPickUp;		
	bool holdingItem;
	GameObject itemToHold;
	Vector3 objectDist;

	Text statusText;



	// Use this for initialization

	void Start () {
		Flip ();			// flip the  sprite
		jumping = false; 	// we are not jumping at the beginning
		isDead = false;
		go = GameObject.Find ("Player");			// finds the player object
		goY = go.GetComponent<Rigidbody> ();		// 

		begin = GameObject.Find ("StartPoint");			// finds the start object

		facingRight = true;					// character starts facing right

		canPickUp = false;
		holdingItem = false;		

		statusText = GameObject.Find("statusText").GetComponent<Text>();



		print (statusText.text);

	}

	void handleDeath()
	{
		isDead = true;
		BroadcastMessage ("dead");
	}

	
	// Update is called once per frame
	void Update () {

	
		if (!isDead) {
			if (holdingItem == true) {
				itemToHold.transform.position = this.transform.position + objectDist;
			}

			if (Input.GetKeyDown ("tab")) {
				print("Printing contents of inventory!");
				SendMessage ("printContents");
			
			}
			
			if (Input.GetKeyDown ("up") && !jumping) {
				print ("Jump!");
				// I would like to have a very smooth "jump"
				//this.transform.position+= Vector3.up * 0.2F; 
				jumping = true;
				StartCoroutine ("Jump");
				BroadcastMessage("jump");
				statusText.text = "BOING";
					}

			if (Input.GetKey ("right")) {
				//print("Forward!");
				//this.transform.position+= Vector3.right * 0.2F;
				goY.AddForce (Vector3.right * 20.0f);
				if (!facingRight) {
					Flip ();
					facingRight = true;			// facing right
					statusText.text = "kekekeke";
				}


			}

			if (Input.GetKey ("left")) {
				//print("Forward!");
				goY.AddForce (Vector3.left * 20.0f);
				if (facingRight) {
					Flip ();
					facingRight = false;			// facing right
					statusText.text = "ooh hee hee";
				}
			}

			if (Input.GetKey ("down")) {
				goY.AddForce (Vector3.down * 50.0f);
				statusText.text = "TURN DOWN FOR WAT meow";
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
				statusText.text = "that was rly rly heavy";
				itemToHold.transform.forward += this.transform.forward;

			}

		}

		if (Input.GetKeyDown ("space") && isDead) {
			SendMessage("respawn");
			isDead = false;
			BroadcastMessage("defaultPose");
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
		BroadcastMessage ("defaultPose");


		// Check for endpoint (crude, could be done better)
		if (collision.gameObject.name == "EndPoint")
		{
			print ("END LEVEL"); 	// print to console
			statusText.text = "GG WELL PLAYED MEOW";
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