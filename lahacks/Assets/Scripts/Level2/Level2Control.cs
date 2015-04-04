using UnityEngine;
using System.Collections;

public class Level2Control : MonoBehaviour {

	GameObject go;		// finds the player object and keep an active reference to it
	Rigidbody2D goY;		// Gets the rigidbody of the player object
	
	GameObject begin;		// finds the location of the start object
	
	bool jumping;		// Initialize variable for jump
	
	bool isDead;
	bool facingRight;	
	
	bool canPickUp;		
	bool holdingItem;
	GameObject itemToHold;
	Vector3 objectDist;

	
	
	
	// Use this for initialization
	
	void Start () {
		Flip ();			// flip the  sprite
		jumping = false; 	// we are not jumping at the beginning
		isDead = false;
		go = GameObject.Find ("Player");			// finds the player object
		goY = go.GetComponent<Rigidbody2D> ();		// 
		
		begin = GameObject.Find ("StartPoint");			// finds the start object
		
		facingRight = true;					// character starts facing right
		
		canPickUp = false;
		holdingItem = false;		
		
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
			
			
			if (Input.GetKeyDown (KeyCode.Tab)) {
				// print("Printing contents of inventory!");
				SendMessage ("printContents");
				
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) && !jumping) {
				print ("Jump!");
				// I would like to have a very smooth "jump"
				//this.transform.position+= Vector3.up * 0.2F; 
				jumping = true;
				StartCoroutine ("Jump");
				BroadcastMessage ("jump");
			}
			
			if (Input.GetKey (KeyCode.RightArrow)) {
				//print("Forward!");
				//this.transform.position+= Vector3.right * 0.2F;
				goY.AddForce (new Vector2 (10, 0));
				//camera1.transform.position = new Vector2(go.transform.position.x, go.transform.position.y);
				if (!facingRight) {
					Flip ();
					facingRight = true;			// facing right
				}
				
				
			}
			
			if (Input.GetKey (KeyCode.LeftArrow)) {
				//print("Forward!");
				goY.AddForce (new Vector2 (-10, 0));
				//camera1.transform.position = new Vector2(go.transform.position.x, go.transform.position.y);
				print ("left");
				if (facingRight) {
					Flip ();
					facingRight = false;			// facing right
				}
			}
			
			if (Input.GetKey (KeyCode.DownArrow)) {
				//print("Down!!");
				goY.AddForce (new Vector2 (0, 50));
			}
			
			if (Input.GetKeyDown (KeyCode.Space)) {
				
			} else if (Input.GetKeyDown ("space")) {
				
				print ("Attempting to drop.");
			}
			
			if (Input.GetKeyDown ("space")) {
				SendMessage ("respawn");
				BroadcastMessage ("defaultPose");
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
	
	void OnCollisionEnter2D(Collision2D collision) {
		
		// On collision, allow character to jump again. (wall jumps)
		jumping = false;
		BroadcastMessage ("defaultPose");
		
		
		// Check for endpoint (crude, could be done better)
		if (collision.gameObject.name == "River") {
			print ("END LEVEL");
			handleDeath ();
			// print to console
			// Some code to bring us to the start point of a level
			// Load new level
			
		} else if (collision.gameObject.name == "End") 
		{
			Application.LoadLevel("Level3");
		}
		
		
	}
	
	void OnCollisionExit2D(Collision2D collisionInfo) {
		print("No longer in contact with " + collisionInfo.transform.name);
		
		if (collisionInfo.transform.name.Contains("pickUp"))
		{
			print ("OutOfRange!"); 	// print to console
			canPickUp = false;
		}
	}

	void respawn()
	{
		Application.LoadLevel("Level2");
	}
}
