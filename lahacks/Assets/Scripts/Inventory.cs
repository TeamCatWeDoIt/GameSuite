using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour {


//
//	class inventoryItem
//	{
//		public int id; // each item will have an associated id
//		public string name; // each item will have an associated name
//		public int quantity; // each item has a number, when it hits 0 it should disappear from inventory
//
//		public inventoryItem()
//		{
//			id = 0;
//			name = "Empty";
//			quantity = 0;
//		}
//
//	}

	public int currentInvSize; 	// current size of the inventory
	public int sizeOfInventory;
	public Text[] textArray;  // declaration
	public RawImage[] imageArray;



	// Use this for initialization
	void Start () {
		currentInvSize = 0;
		sizeOfInventory = 5;

		textArray = new Text[sizeOfInventory];
		textArray [0] = GameObject.Find ("Poppy").transform.GetComponent<Text>();
		textArray [1] = GameObject.Find ("Gentian").transform.GetComponent<Text>();
		textArray [2] = GameObject.Find ("Oxeye").transform.GetComponent<Text>();
		textArray [3] = GameObject.Find ("Purple").transform.GetComponent<Text>();
		textArray [4] = GameObject.Find ("Rose").transform.GetComponent<Text>();

		imageArray = new RawImage[sizeOfInventory];
		imageArray [0] = GameObject.Find ("slot1").transform.GetComponent<RawImage>();
		imageArray [1] = GameObject.Find ("slot2").transform.GetComponent<RawImage>();
		imageArray [2] = GameObject.Find ("slot3").transform.GetComponent<RawImage>();
		imageArray [3] = GameObject.Find ("slot4").transform.GetComponent<RawImage>();
		imageArray [4] = GameObject.Find ("slot5").transform.GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void printContents()
	{
		print ("Here is what is in the inventory right now");
		for (int i = 0; i < sizeOfInventory; i++) 
		{
			print(textArray[i].name + " ");
		}

	}


	void pickedUp(GameObject g)
	{
		print ("Picked up item[" + g.name + "]");
		addItem (g, 1);				// pickups generally just give one of each item
	}

	void addItem(GameObject g, int q)
	{
		// Add items will take the name, and quantity
		// First check if existing
		// if it already exists
		int index = -1;
			if (g.name.Contains ("rose")) {
			index = 4;
		} 
		else if (g.name.Contains ("purple")) 
		{
			index = 3;
		}
		else if (g.name.Contains ("oxeye")) 
		{
			index = 2;
		}
		else if (g.name.Contains ("gentian")) 
		{
			index = 1;
		}
		else if (g.name.Contains ("poppy")) 
		{
			index = 0;
		}
		int orig = Int32.Parse (textArray [index].text.ToString ());
		orig += q;
		textArray [index].text = orig.ToString ();
	}
}
