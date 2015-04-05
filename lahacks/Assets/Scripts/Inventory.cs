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


	int sizeOfInventory;
	Text[] myArray;  // declaration



	// Use this for initialization
	void Start () {
		sizeOfInventory = 5;
		myArray = new Text[sizeOfInventory];
		myArray [0] = GameObject.Find ("Poppy").transform.GetComponent<Text>();
		myArray [1] = GameObject.Find ("Gentian").transform.GetComponent<Text>();
		myArray [2] = GameObject.Find ("Oxeye").transform.GetComponent<Text>();
		myArray [3] = GameObject.Find ("Purple").transform.GetComponent<Text>();
		myArray [4] = GameObject.Find ("Rose").transform.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void printContents()
	{
		print ("Here is what is in the inventory right now");
		for (int i = 0; i < sizeOfInventory; i++) 
		{
			print(myArray[i].name + " ");
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
			if (g.name.Contains("rose")) 
			{
				int orig = Int32.Parse(myArray[4].text.ToString());
				orig += q;
				myArray[4].text = orig.ToString();
			}

	}
	
}
