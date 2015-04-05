using UnityEngine;
using System.Collections;

public class Stage1Control : MonoBehaviour {

	GameObject go;		// finds the player object and keep an active reference to it
	Rigidbody2D goY;		// Gets the rigidbody of the player object
	
	bool jumping;		// Initialize variable for jump
	
	bool facingRight;	
	
	Vector2 objectDist;
	GameObject camera1;
	GameObject itemToHold;
	string myLevel;

	bool flowerTaken;
	bool canPickUp;
	bool holdingItem;
	bool isDead;
	
	
	// Use this for initialization
	
	void Start () {
		Flip ();			// flip the  sprite
		jumping = false; 	// we are not jumping at the beginning
		canPickUp = true;
		holdingItem = false;
		isDead = false;
		go = GameObject.Find ("Player");
		camera1 = GameObject.Find ("main Camera");// finds the player object
		goY = go.GetComponent<Rigidbody2D> ();		// 
		if (goY == null) {
			print ("null");
		}
		
		facingRight = true;					// character starts facing right
		
	}
	
	
	// Update is called once per frame
	void Update () {
		if (!isDead) 
		{
			if (holdingItem == true) {
				if (facingRight)
					itemToHold.transform.position = (Vector2)(this.transform.position) + (Vector2)objectDist;
				else {
					Vector2 reverseVec = new Vector2 ();
					Vector2 testVec = new Vector2 (-objectDist.x, objectDist.y);
					itemToHold.transform.position = (Vector2)(this.transform.position) + (Vector2)testVec;
				}
			}
		
			if (Input.GetKeyDown (KeyCode.Tab)) {
				// print("Printing contents of inventory!");
				SendMessage ("printContents");
			
			}
		
			if (Input.GetKeyDown (KeyCode.UpArrow) && !jumping) {
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
				if (facingRight) {
					Flip ();
					facingRight = false;			// facing right
				}
			}
		
			if (Input.GetKey (KeyCode.DownArrow)) {
				//print("Down!!");
				goY.AddForce (new Vector2 (0, 50));
			}
		
			if (Input.GetKeyDown (KeyCode.Space) & canPickUp & !holdingItem) 
			{
				holdingItem = true;
				itemToHold.transform.position += new Vector3 (1.0f, 1.0f, 0.0f);
				// Freeze the position between the two objects while space is held down 
				objectDist = itemToHold.transform.position - this.transform.position;
			} 
			else if (Input.GetKeyDown ("space") & holdingItem) {
			
				print ("Attempting to drop.");
				holdingItem = false;
				Rigidbody tempThrow = itemToHold.GetComponent<Rigidbody> (); // gets the rigid body
				print (this.transform.forward);
				// Vector3 tempU = new Vector3(0.0f, 80.0f, 1.0f);
				Vector3 tempR = new Vector3(70.0f, 50.0f, 1.0f);
				Vector3 tempL = new Vector3(-70.0f, 50.0f, 1.0f);
				/*
				 * if (Input.GetKey ("up"))
				    {
					print ("throw up");
					tempThrow.AddForce(tempU);
				}
				*/
				if (facingRight)
					tempThrow.AddForce(tempR);
				else
					tempThrow.AddForce(tempL);
				
				// itemToHold.transform.position += goY.velocity;

			}
		}
		
		if (Input.GetKeyDown ("space") & isDead) {
			SendMessage("respawn");
			BroadcastMessage("defaultPose");
		}

	}
	
	void Flip()
	{	
		// Multiply the player's x local scale by -1
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	
	IEnumerator Jump() {
		
		goY.AddForce(new Vector2(0, 400));					// Applies a force in the up
		yield return null;									// return
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		
		// On collision, allow character to jump again. (wall jumps)
		jumping = false;
		BroadcastMessage ("defaultPose");
		
		
		// Check for endpoint (crude, could be done better)
		if (collision.gameObject.name == "End" & flowerTaken) 
		{
			Application.LoadLevel ("Level2");
		} 
		else if (collision.gameObject.name == "Rose") 
		{
			flowerTaken = true;
			// add into inventory
			Destroy(collision.gameObject);
		}

		else if(collision.gameObject.name.Contains("Stump") | collision.gameObject.name.Contains("Flame"))
		{
			Damage(1);
		}
		else if (collision.gameObject.name.Contains("Rock"))
		{
			
			canPickUp = true;
			itemToHold = GameObject.Find(collision.gameObject.name);
			
			// Some code to bring us to the start point of a level
			// Load new level
			
		}
		
	}

	void Damage (int q)
	{

	}
	

	void respawn()
	{
		Application.LoadLevel ("Stage1");
	}

	void OnCollisionExit2D(Collision2D collisionInfo) {
		print("No longer in contact with " + collisionInfo.transform.name);
	}
}
