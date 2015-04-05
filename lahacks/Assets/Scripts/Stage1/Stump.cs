using UnityEngine;
using System.Collections;

public class Stump : MonoBehaviour {

	Vector3 ori;

	// Use this for initialization
	void Start () {
		ori = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 diff = gameObject.transform.position - ori;
		gameObject.transform.position -= diff;
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		Vector3 diff = gameObject.transform.position - ori;
		gameObject.transform.position -= diff;
	}
}
