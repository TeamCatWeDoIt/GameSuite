using UnityEngine;
using System.Collections;

public class CharAnimator : MonoBehaviour {


	public Sprite sprite1; // Drag your first sprite here
	public Sprite sprite2; // Drag your second sprite here
	public Sprite sprite3; // Drag your second sprite here

	private SpriteRenderer spriteRenderer; 

	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer>();
		
		spriteRenderer.sprite = sprite1; // set the sprite to sprite1
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void jump()
	{
		print ("Rendering jump");
		spriteRenderer.sprite = sprite2;
	}

	void defaultPose()
	{
		print ("Rendering normal pose");
		spriteRenderer.sprite = sprite1;
	}

	void dead()
	{
		print ("Rendering dead pose");
		spriteRenderer.sprite = sprite3;
	}

}
