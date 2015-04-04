using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {
	
	public float dampTime;
	private Vector3 velocity;
	public Transform target;
	public Camera camera1;


	void Start()
	{
		dampTime = 0.15f;
		velocity = Vector3.zero;
		target = GameObject.Find ("Player").transform;
		camera1 = GameObject.Find ("Main Camera").GetComponent<Camera> ();
	}


	// Update is called once per frame
	void Update () 
	{
		if (target)
		{
			Vector3 point = camera1.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera1.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);}
	}
}