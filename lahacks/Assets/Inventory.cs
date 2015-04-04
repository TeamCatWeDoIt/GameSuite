using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {


	class inventoryItem
	{
		public int id; // each item will have an associated id
		public string name; // each item will have an associated name
		public int quantity; // each item has a number, when it hits 0 it should disappear from inventory

		inventoryItem()
		{
			id = 0;
			name = "Empty";
			quantity = 0;
		}

	}


	int sizeOfInventory;
	inventoryItem [] myArray;  // declaration



	// Use this for initialization
	void Start () {
		sizeOfInventory = 3;
		myArray = new inventoryItem[sizeOfInventory]; 
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void printContents()
	{
		print ("Here is what is in the inventory right now");

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
		if (checkExisting(g.name) != -1) {
			// -1 means that the item does not exist
			// if it is not -1, the object exists and we must update it
			myArray[checkExisting(g.name)].quantity += q; 	// add on the quantity.

		}

		// otherwise, find the nearest inventory slot
		// and add the item to it
		// // TODO: Implement this feature

	}

	int checkExisting(string n)
	{
		for (int x = 0; x < sizeOfInventory; x++)
		{
			// compare the names
			if (myArray[x].name == n)
			{
				// if they are the same
				return x; // return the index
			}

		}
		print ("No repeats; item does not yet exist in inventory");
		return -1;


}
}
