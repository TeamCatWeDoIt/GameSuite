using UnityEngine;
using System.Collections;

public class FlameDamage : MonoBehaviour {


	GameObject go;		// store the player reference in ir
	float distToPlayerX;
	float distToPlayerY;

	// Use this for initialization
	void Start () {

		go = GameObject.Find ("Player");			// finds the player object
	
	}
	
	// Update is called once per frame
	void Update () {

		findDistanceToPlayer ();

		if (distToPlayerX < 0.5f && distToPlayerY < 0.5f) {
			go.SendMessage("takeDamage", 1);
		}
	
	}

	void findDistanceToPlayer()
	{

		distToPlayerX = Mathf.Abs(this.transform.position.x - go.transform.position.x);
		distToPlayerY = Mathf.Abs(this.transform.position.y - go.transform.position.y);

		// print (distToPlayerX + ", " + distToPlayerY);

	}
}
