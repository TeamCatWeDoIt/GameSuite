using UnityEngine;
using System.Collections;

public class FlameAnim : MonoBehaviour {

	public Sprite sprite1; // Drag your first sprite here
	public Sprite sprite2; // Drag your second sprite here
	bool switchs;
	// public Sprite sprite3; // Drag your second sprite here

	private SpriteRenderer spriteRenderer; 
	
	// Use this for initialization
	void Start () {
		
		spriteRenderer = GetComponent<SpriteRenderer>();
		switchs = true;
		spriteRenderer.sprite = sprite1; // set the sprite to sprite1
	}
	
	// Update is called once per frame
	void Update () {

		if (switchs) {
			switchs = false;		// set the switch to false
			beginAnimation ();

		}


	
	}

	void beginAnimation()
	{
		StartCoroutine(Flip());
	}

	IEnumerator Flip()
	{	
		// Multiply the player's x local scale by -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		print ("FLip");
		yield return new WaitForSeconds(0.5f);
		switchs = true;

	}



}
