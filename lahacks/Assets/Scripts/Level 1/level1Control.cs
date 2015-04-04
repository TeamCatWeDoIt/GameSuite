using UnityEngine;
using System.Collections;

public class level1Control : MonoBehaviour {

	GameObject go;		// finds the player object and keep an active reference to it
	Rigidbody2D goY;		// Gets the rigidbody of the player object
	
	bool jumping;		// Initialize variable for jump

	bool facingRight;	
	
	Vector2 objectDist;
	GameObject camera1;
	
	
	// Use this for initialization
	
	void Start () {
		Flip ();			// flip the  sprite
		jumping = false; 	// we are not jumping at the beginning
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
				BroadcastMessage("jump");
			}
			
			if (Input.GetKey (KeyCode.RightArrow)) {
				//print("Forward!");
				//this.transform.position+= Vector3.right * 0.2F;
				goY.AddForce (new Vector2(10, 0));
			//camera1.transform.position = new Vector2(go.transform.position.x, go.transform.position.y);
				if (!facingRight) {
					Flip ();
					facingRight = true;			// facing right
				}
				
				
			}
			
			if (Input.GetKey (KeyCode.LeftArrow)) {
				//print("Forward!");
				goY.AddForce ( new Vector2(-10, 0));
			//camera1.transform.position = new Vector2(go.transform.position.x, go.transform.position.y);
			print ("left");
				if (facingRight) {
					Flip ();
					facingRight = false;			// facing right
				}
			}
			
			if (Input.GetKey (KeyCode.DownArrow)) {
				//print("Down!!");
				goY.AddForce (new Vector2(0, 50));
			}
			
			if (Input.GetKeyDown (KeyCode.Space)) {

			}
			
			else if (Input.GetKeyDown ("space")) {
				
				print ("Attempting to drop.");
			}
			
		if (Input.GetKeyDown ("space")) {
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
		
		goY.AddForce(new Vector2(0, 350));					// Applies a force in the up
		yield return null;									// return
	}
	
	void OnCollisionEnter(Collision collision) {
		
		// On collision, allow character to jump again. (wall jumps)
		jumping = false;
		BroadcastMessage ("defaultPose");
		
		
		// Check for endpoint (crude, could be done better)
		if (collision.gameObject.name == "End")
		{
			Application.LoadLevel("Level2");
			
		}

		if (collision.gameObject.name == "Floor") 
		{

		}
		
	}
	
	void OnCollisionExit(Collision collisionInfo) {
		print("No longer in contact with " + collisionInfo.transform.name);
	}
}
