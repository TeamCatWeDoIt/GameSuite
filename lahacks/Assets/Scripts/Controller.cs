using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class Controller : MonoBehaviour {

	GameObject go;		// finds the player object and keep an active reference to it
	Rigidbody2D goY;		// Gets the rigidbody of the player object

	GameObject begin;		// finds the location of the start object
	Rigidbody2D beginBody;	// body of the item

	bool jumping;		// Initialize variable for jump
	
	bool isDead;
	bool facingRight;	

	bool canPickUp;		
	bool holdingItem;
	GameObject itemToHold;
	public GameObject projectile;
	Vector2 objectDist;

	Text statusText;

	public string nextLevel;



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

		statusText = GameObject.Find("statusText").GetComponent<Text>();



		print (statusText.text);

	}

	public bool isFacingRight()
	{
		return facingRight;
	}

	void handleDeath()
	{
		isDead = true;
		BroadcastMessage ("dead");
	}

	
	// Update is called once per frame
	void Update () {

		if (this.transform.position.y < 0)
		{
			handleDeath();
		}

		if (!isDead) {
			if (holdingItem == true) {
				if(facingRight)
				itemToHold.transform.position = (Vector2)(this.transform.position) + (Vector2)objectDist;
				else
				{
					Vector2 testVec = new Vector2(-objectDist.x, objectDist.y);
					itemToHold.transform.position = (Vector2)(this.transform.position) + (Vector2)testVec;
				}
			}

			if (Input.GetKeyDown ("tab")) {
				print("Printing contents of inventory!");
				SendMessage ("printContents");
			
			}

			if (Input.GetKeyDown ("z")) {		// if z is pressed down
				print("Shooting out fireball!");
				BroadcastMessage("attack");
				GameObject flame = Instantiate(projectile);
				flame.SendMessage("setDirection",facingRight);
			}
			
			if (Input.GetKeyDown ("up") && !jumping) {
				print ("Jump!");
				// I would like to have a very smooth "jump"
				//this.transform.position+= Vector3.up * 0.2F; 
				jumping = true;
				StartCoroutine ("Jump");
				BroadcastMessage("jump");	statusText.text = "BOING";
					}

			if (Input.GetKey ("right")) {
				goY.AddForce (Vector2.right * 8.0f);
				if (!facingRight) {
					Flip ();
					facingRight = true;			// facing right
					statusText.text = "kekekeke";
				}
			}

			if (Input.GetKey ("left")) {
				//print("Forward!");
				
				goY.AddForce (-Vector2.right * 8.0f);
				
				if (facingRight) {
					Flip ();
					facingRight = false;			// facing right
					statusText.text = "ooh hee hee";
				}
			}
			if (Input.GetKey("up"))
			{
				Jump();
			}
			
			if (Input.GetKey ("down")) {
				goY.AddForce (-Vector2.up * 50.0f);
				statusText.text = "TURN DOWN FOR WAT meow";
			}

			if (Input.GetKeyDown ("space") && canPickUp && !holdingItem) {
				
				print ("Attempting to pickup.");
				holdingItem = true;
				itemToHold.transform.position = (Vector2)itemToHold.transform.position + new Vector2(0.23f, 1.0f);
				// Freeze the position between the two objects while space is held down 
				objectDist = itemToHold.transform.position - this.transform.position;
			}
			
			else if (Input.GetKeyDown ("space") && holdingItem) {
				
				print ("Attempting to drop/throw");
				holdingItem = false;
				statusText.text = "that was rly rly heavy";
				Rigidbody2D tempThrow = itemToHold.GetComponent<Rigidbody2D> (); // gets the rigid body
				print (this.transform.forward);
				// Vector3 tempU = new Vector3(0.0f, 80.0f, 1.0f);
				Vector2 tempR = new Vector2(70.0f, 50.0f);
				Vector2 tempL = new Vector2(-70.0f, 50.0f);
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

		if (Input.GetKeyDown ("space") && isDead) {
			SendMessage("respawn");
			isDead = false;
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

		goY.AddForce(Vector2.up * 375.0f);					// Applies a force in the up
		yield return null;									// return
	}

	void OnCollisionEnter2D(Collision2D collision) {

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

		if (collision.gameObject.name.Contains ("rose")) 
		{
			BroadcastMessage("pickedUp", collision.gameObject);
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.name.Contains ("Trap")) 
		{
			BroadcastMessage("takeDamage", 1);
		}

	
	}

	void respawn()
	{
		Application.LoadLevel ("Stage0");
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