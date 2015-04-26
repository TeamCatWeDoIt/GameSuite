using UnityEngine;
using System.Collections;

public class LeftRight : MonoBehaviour {

	// Use this for initialization
	float minX;
	float maxX;
	float currX;
	bool destroyed;
	bool movingRight;
	public float diff = 10.0f;

	void Start () 
	{
		currX = gameObject.transform.position.x;
		maxX = currX + diff;
		minX = currX - diff;
		movingRight = true;
		destroyed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!destroyed) 
		{
			if (currX <= maxX && movingRight) {
				currX++;
				Vector3 temp = new Vector3(0.1f,0,0);
				gameObject.transform.position += temp;
				if(currX > maxX)
				{
					movingRight = false;
				}
			}
			else if(currX >= minX && !movingRight)
			{
				currX--;
				Vector3 temp = new Vector3(-0.1f,0,0);
				gameObject.transform.position+=temp;
				if(currX < minX)
				{
					movingRight = true;
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
