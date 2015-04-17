using UnityEngine;
using System.Collections;

public class CharAnimator : MonoBehaviour {

	public Sprite idleSprite; // Drag your 0 sprite here
	public Sprite normalSprite; // Drag your first sprite here
	public Sprite jumpSprite; // Drag your second sprite here
	public Sprite deadSprite; // Drag your second sprite here
	public Sprite attackSprite; // Drag your second sprite here


	bool action;

	private SpriteRenderer spriteRenderer; 

	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		action = false;

	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void attack()
	{
		// Attack sequence will launch a fireball.
		spriteRenderer.sprite = attackSprite;
	}

	void jump()
	{
		spriteRenderer.sprite = jumpSprite;
	}

	void defaultPose()
	{
		// print ("Rendering normal pose");
		StartCoroutine (idle ());

	}

	void dead()
	{
		//action = true; 	// BEING DEAD CAN BE AN ACTION TOO.
		spriteRenderer.sprite = deadSprite;
	}

	IEnumerator idle()
	{	
		// Multiply the player's x local scale by -1
		spriteRenderer.sprite = normalSprite;
		yield return new WaitForSeconds(0.5f);
		spriteRenderer.sprite = idleSprite;
		yield return new WaitForSeconds(0.5f);
		spriteRenderer.sprite = normalSprite;
	}


}
