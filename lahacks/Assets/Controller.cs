using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	GameObject go;		// finds the player object
	Rigidbody goY;		// Gets the rigidbody
	
	bool jumping;		// Initialize variable for jump
	int health;			// how much health does the character
	int jumpHeight;
	// Use this for initialization
	void Start () {

		jumping = false; 	// we are not jumping at the beginning
		health = 10;		// starting health set here.
		jumpHeight = 20;		// change to increase height of jump

		go = GameObject.Find ("Player");			// finds the player object
		goY = go.GetComponent<Rigidbody> ();		// 
	}
	
	
	// Update is called once per frame
	void Update () {


	
		// Very crude controller
			
		if (Input.GetKeyDown ("up") && !jumping ) {
			print("Jump!");
			// I would like to have a very smooth "jump"
			//this.transform.position+= Vector3.up * 0.2F; 
			jumping = true;
			StartCoroutine("Jump");
		

		}

		 if (Input.GetKey ("right")) {
			print("Forward!");
			//this.transform.position+= Vector3.right * 0.2F;
			goY.AddForce(Vector3.right * 20.0f);

		}

		 if (Input.GetKey ("left")) {
			print("Forward!");
			goY.AddForce(Vector3.left * 20.0f);
		}

		 if (Input.GetKey ("down")) {
			print("Down!!");
			goY.AddForce(Vector3.down * 50.0f);
		}


	}


	IEnumerator Jump() {

		goY.AddForce(Vector3.up * 350.0f);					// Applies a force in the up
		yield return null;									// return
	}

	void OnCollisionEnter(Collision collision) {

		print ("Collision");
		jumping = false;

	}




}
