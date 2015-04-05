using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {

// This will be put onto each and every item that controls access between levels.

	public string nextLevel;
	// public string backLevel;
	public string thisLevelName;
	public bool conditionMet;


	void Start () {
		// conditionMet = false;
	}

	void Update () {
	
	}

	void updateGlobalStats()
	{
		// TODO: Contact the relevant gameobject method and report status
		//SendMessage ("completedLevel", thisLevelName);
	}

	void conditionMetTrue()
	{
		print ("Message Recieved!");
		conditionMet = true;
	}
	
	// Handle collisions and load the next level

	void OnCollisionEnter2D(Collision2D collision) {

		print (collision.gameObject.name + " has collided with level change point" + conditionMet);

		/// If the player has touched the level change, and they have completed the level objective.
		if (collision.gameObject.name == "Player" && conditionMet) {
			print ("End level!");
			Application.LoadLevel (nextLevel); // Load the specified level.
		}

	}
}

