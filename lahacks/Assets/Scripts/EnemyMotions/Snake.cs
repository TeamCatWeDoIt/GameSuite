using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour {

	float currX;
	float currY;
	float maxX;
	float minX;
	float maxY;
	float minY;
	bool destroyed;
	bool movingRight;
	bool movingUp;


	// Use this for initialization
	void Start () 
	{
		destroyed = false;
		movingUp = true;
		movingRight = true;
		currX = gameObject.transform.position.x;
		currY = gameObject.transform.position.y;
		maxX = currX + 50;
		minX = currX - 50;
		maxY = currY + 6;
		minY = currY - 6;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!destroyed) 
		{
			if (currX <= maxX & movingRight) {
				currX += 1;
				Vector3 temp = new Vector3 (0.2f, 0, 0);
				gameObject.transform.position+= temp;
				if(currX > maxX)
				{
					movingRight = false;
				}
			}
			else if(currX >= minX & !movingRight)
			{
				currX -= 1;
				Vector3 temp = new Vector3(-0.2f, 0, 0);
				gameObject.transform.position += temp;
				if(currX < minX)
				{
					movingRight = true;
				}
			}
			if(currY <= maxY & movingUp)
			{
				currY += 1;
				Vector3 temp = new Vector3(0,0.2f,0);
				gameObject.transform.position += temp;
				if(currY > maxY)
				{
					movingUp = false;
				}
			}
			else if(currY >= minY & !movingUp)
			{
				currY -= 1;
				Vector3 temp = new Vector3(0, -0.2f, 0);
				gameObject.transform.position += temp;
				if(currY <minY)
				{
					movingUp = true;
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
		else if(collision.gameObject.name == "Player")
		{
			collision.gameObject.SendMessage("Damage", 1);
		}
	}
}
