using UnityEngine;
using System.Collections;

public class FlameWalk : MonoBehaviour {


	float currentX;
	float maxX;
	float minX;
	bool movingRight;
	bool destroyed;

	// Use this for initialization
	void Start () 
	{
		currentX = gameObject.transform.position.x;
		maxX = currentX + 10;
		minX = currentX - 10;
		destroyed = false;
		movingRight = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!destroyed) 
		{
			if (!destroyed) 
			{
				if (currentX <= maxX && movingRight) {
					currentX++;
					Vector3 temp = new Vector3(0.1f,0,0);
					gameObject.transform.position += temp;
					if(currentX > maxX)
					{
						movingRight = false;
					}
				}
				else if(currentX >= minX && !movingRight)
				{
					currentX--;
					Vector3 temp = new Vector3(-0.1f,0,0);
					gameObject.transform.position+=temp;
					if(currentX < minX)
					{
						movingRight = true;
					}
				}
				
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		if(collision.gameObject.name.Contains ("Rock"))
		{
			destroyed = true;
			Destroy(gameObject);
			GameObject.Find("Player").SendMessage("dropped");
		}
		if (collision.gameObject.name == "background" || collision.gameObject.name == "Background") 
		{

		}
		if(collision.gameObject.name == "Player")
		{
			collision.gameObject.SendMessage("Damage", 1);
		}
	}
}
