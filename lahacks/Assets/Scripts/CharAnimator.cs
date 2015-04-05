using UnityEngine;
using System.Collections;

public class CharAnimator : MonoBehaviour {

	public Sprite sprite0; // Drag your 0 sprite here
	public Sprite sprite1; // Drag your first sprite here
	public Sprite sprite2; // Drag your second sprite here
	public Sprite sprite3; // Drag your second sprite here

	bool action;

	private SpriteRenderer spriteRenderer; 

	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer>();
		action = false;
		spriteRenderer.sprite = sprite1; // set the sprite to sprite1
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void jump()
	{
		spriteRenderer.sprite = sprite2;
	}

	void defaultPose()
	{
		// print ("Rendering normal pose");
		StartCoroutine (idle ());

	

	}

	void dead()
	{
		//action = true; 	// BEING DEAD CAN BE AN ACTION TOO.
		spriteRenderer.sprite = sprite3;
	}

	IEnumerator idle()
	{	
		// Multiply the player's x local scale by -1
		spriteRenderer.sprite = sprite1;
		yield return new WaitForSeconds(0.5f);
		spriteRenderer.sprite = sprite0;
		yield return new WaitForSeconds(0.5f);
		spriteRenderer.sprite = sprite1;
	}


}
