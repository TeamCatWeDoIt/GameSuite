using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	int maxHealth;		// max total of health the character can have
	int health;			// how much health does the character now

	GameObject begin;		// finds the location of the start object

	GameObject healthDisp;	// health display bar that we will scale
	
	// Use this for initialization
	void Start () {

		maxHealth = 10;
		health = maxHealth;		// starting health set here.

		begin = GameObject.Find ("StartPoint");			// finds the start object

		healthDisp = GameObject.Find ("HealthBar");
		healthDisp.transform.localScale = new Vector3 (5.0f, 0.36f, 1.0f);

		
	}
	
	// Update is called once per frame
	void Update () {

		// Health related effects go in this script

		if (health < 0) {
			respawn ();
			}
	}

	void respawn()
	{
		this.transform.position = begin.transform.position;
		health = maxHealth;
		healthDisp.transform.localScale = new Vector3 (5.0f, 0.36f, 1.0f);
		// healthDisp.transform.localScale += new Vector3(5.0F, 0, 0);

		
	}

	void takeDamage(int i)
	{
		health -= i;
		print ("Took this much damage: " + i);
		healthDisp.transform.localScale -= new Vector3(0.5F * i, 0, 0);

	}

	void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.name == "Terrain")
		{
			print ("Fell out of stage!"); 	// print to console
			takeDamage(100);				// instant kill!

			
			
			// Some code to bring us to the start point of a level
			// Load new level
			
		}

		}

	}

