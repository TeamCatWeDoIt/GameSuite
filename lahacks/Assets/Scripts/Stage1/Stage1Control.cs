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
	public GameObject projectile;
	
	
	// Use this for initialization
	
	void Start () {
		Flip ();			// flip the  sprite
		jumping = false; 	// we are not jumping at the beginning
		canPickUp = true;
		holdingItem = false;
		flowerTaken = false;
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
		if (gameObject.transform.position.y < 0)
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
					itemToHold.transform.position = (Vector2)(gameObject.transform.position) + (Vector2)testVec;
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
				BroadcastMessage("jump");
			}
			
			if (Input.GetKey ("right")) {

				Vector3 temp = new Vector3(0.1f, 0, 0);
				gameObject.transform.position += temp;	// using 3d vector for this still

				if (!facingRight) {
					Flip ();
					facingRight = true;			// facing right
				}

				if (Input.GetKeyDown ("up"))
				{
					goY.AddForce (Vector2.up * 40.0f);
				}
				

			}
			if(Input.GetKey("space"))
			{

			}
			if (Input.GetKey ("left")) {
				//print("Forward!");
				
				gameObject.transform.position -= Vector3.right * 0.1F;	// using 3d vector for this still
				
				if (Input.GetKeyDown ("up"))
				{
					goY.AddForce (Vector2.up * 40.0f);
				}
				
				if (facingRight) {
					Flip ();
					facingRight = false;			// facing right
				}
			}
			if (Input.GetKey("up"))
			{
				Jump();
			}
			
			if (Input.GetKey ("down")) {
				goY.AddForce (-Vector2.up * 50.0f);
			}
			
			if (Input.GetKeyDown ("space") && canPickUp && !holdingItem && itemToHold != null) {
				
				print ("Attempting to pickup.");
				holdingItem = true;
				itemToHold.transform.position = (Vector2)itemToHold.transform.position + new Vector2(0.23f, 1.0f);
				// Freeze the position between the two objects while space is held down 
				objectDist = itemToHold.transform.position - this.transform.position;
			}
			
			else if (Input.GetKeyDown ("space") && holdingItem) {
				
				print ("Attempting to drop/throw");
				holdingItem = false;
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
				{
					tempThrow.AddForce(tempR);
				}
				else
				{
					tempThrow.AddForce(tempL);
				}
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
		
		goY.AddForce(new Vector2(0, 400));					// Applies a force in the up
		yield return null;									// return
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		
		// On collision, allow character to jump again. (wall jumps)
		jumping = false;
		BroadcastMessage ("defaultPose");
		
		
		// Check for endpoint (crude, could be done better)
		if (collision.gameObject.name == "Portal" & flowerTaken) {
			Application.LoadLevel ("trunkstage");
		} 
		if (collision.gameObject.name == "Portal") 
		{
		}
		if (collision.gameObject.name == "rose" || collision.gameObject.name =="purpleFlower") 
		{
			flowerTaken = true;
			BroadcastMessage("pickedUp", collision.gameObject);
			Destroy (collision.gameObject);
		} 
		if (collision.gameObject.name.Contains ("Stump") | collision.gameObject.name.Contains ("Flame")) 
		{
			BroadcastMessage ("takeDamage", 1);
		} 
		if (collision.gameObject.name.Contains("Rock") & !holdingItem) 
		{
			
			canPickUp = true;
			itemToHold = GameObject.Find(collision.gameObject.name);
			
			// Some code to bring us to the start point of a level
			// Load new level
			
		}
		
	}

	void dropped()
	{
		holdingItem = false;
		Destroy (itemToHold);
		canPickUp = false;
	}

	void respawn()
	{
		Application.LoadLevel ("Stage1");
	}

	void OnCollisionExit2D(Collision2D collisionInfo) {
		print("No longer in contact with " + collisionInfo.transform.name);
	}

	void handleDeath()
	{
		isDead = true;
		BroadcastMessage ("dead");
	}
}
