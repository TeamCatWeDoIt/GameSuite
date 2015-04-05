using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour {


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
	public RawImage[] imageArray;
	public Text[] textArray;
	

	// Use this for initialization
	void Start () {
		currentInvSize = 0;
		sizeOfInventory = 5;

		imageArray = new RawImage[sizeOfInventory];
		textArray = new Text[sizeOfInventory];

		imageArray [0] = GameObject.Find ("slot1").GetComponent<RawImage>();
		textArray[0] = GameObject.Find("slot1").GetComponent<Text>();
		imageArray [1] = GameObject.Find ("slot2").GetComponent<RawImage>();
		textArray[1] = GameObject.Find("slot2").GetComponent<Text>();
		imageArray [2] = GameObject.Find ("slot3").GetComponent<RawImage>();
		textArray[2] = GameObject.Find("slot3").GetComponent<Text>();
		imageArray [3] = GameObject.Find ("slot4").GetComponent<RawImage>();
		textArray[3] = GameObject.Find("slot4").GetComponent<Text>();
		imageArray [4] = GameObject.Find ("slot5").GetComponent<RawImage>();
		textArray[4] = GameObject.Find("slot5").GetComponent<Text>();
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

		// figure out which image to load
		Texture t = loadImageTexture (g);

		// add q number of the item
		for (int i = 0; i < q; i++) {

			// make sure the additional items do not surpass inventory size
			if (currentInvSize < imageArray.Length) 
			{
				// change the slot image
				imageArray [currentInvSize].texture = t;
	
				// increase the current inventory size
				currentInvSize++;
			}
		}
	}

	Texture loadImageTexture(GameObject g)
	{
		Texture tex = new Texture();
		
		if (g.name.Contains ("rose")) 
		{
			tex = (Texture) Resources.Load("rosa-californica");
		} 
		else if (g.name.Contains ("purple")) 
		{
			tex = (Texture) Resources.Load("purple-loosestrife");
		}
		else if (g.name.Contains ("oxeye")) 
		{
			tex = (Texture) Resources.Load("oxeye-daisy");
		}
		else if (g.name.Contains ("gentian")) 
		{
			tex = (Texture) Resources.Load("elegant-gentian");
		}
		else if (g.name.Contains ("poppy")) 
		{
			tex = (Texture) Resources.Load("CA-poppy");
		}

		return tex;
	}
}
