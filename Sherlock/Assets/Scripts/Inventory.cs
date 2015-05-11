using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	
	private List<Interactable> items = new List<Interactable> ();
	private TextController textController;

	void Awake()
	{
		textController = GameObject.Find ("Scripts").GetComponent<TextController>();
		items.Add ("magnifying glass");

	}
}
