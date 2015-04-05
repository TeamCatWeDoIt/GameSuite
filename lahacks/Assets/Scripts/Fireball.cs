using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	Vector3 initialLaunch;
	Vector3 offset;
	public bool facingRight;

	Fireball(bool face)
	{
		facingRight = face;
	}


	// Use this for initialization
	void Start () {
	
		// We need to know which direction the player is facing.


	

		// initialLaunch = new Vector3 (0.5f, 0.0f, 0.0f);

		offset = new Vector3 (1.0f, 1.0f, 0.0f);

		StartCoroutine (selfDestruct());
		this.gameObject.transform.position = GameObject.Find ("Player").transform.position + offset;
	}

	void setDirection(bool d)
	{



		if (d) {
			initialLaunch = new Vector3 (0.5f, 0.0f, 0.0f);
		}
		else
			initialLaunch = new Vector3 (-0.5f, 0.0f, 0.0f);

	}

	// Update is called once per frame
	void Update () {
	
		if (initialLaunch != null)

		this.gameObject.transform.position += initialLaunch; // TODO: will add more

	}


	IEnumerator selfDestruct()
	{
		// will run this method.return
		yield return new WaitForSeconds(3.0f); // wait for 3 seconds
		Destroy (this.gameObject);				// destroy this fireball
	}
}
