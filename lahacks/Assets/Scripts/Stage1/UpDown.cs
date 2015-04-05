using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour {
	
	float maxY;
	float minY;
	bool movingUp;
	float currY;
	bool destroyed;
	// Use this for initialization
	void Start () 
	{
		movingUp = true;
		currY = gameObject.transform.position.y;
		maxY = currY + 10;
		minY = currY - 10;
		destroyed = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!destroyed) 
		{
			if (currY <= maxY & movingUp) {
				currY++;
				Vector3 temp = new Vector3(0,0.1f,0);
				gameObject.transform.position += temp;
				if(currY > maxY)
				{
					movingUp = false;
				}
			}
			else if(currY >= minY & !movingUp)
			{
				currY--;
				Vector3 temp = new Vector3(0,-0.1f,0);
				gameObject.transform.position += temp;
				if(currY < minY)
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
