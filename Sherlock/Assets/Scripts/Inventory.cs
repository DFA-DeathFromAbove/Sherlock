﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Inventory : MonoBehaviour {
	
	public List<Interactable> items = new List<Interactable> ();
	private TextController textController;

	void Awake()
	{
		textController = GameObject.Find ("Scripts").GetComponent<TextController>();
		items.Add(gameObject.AddComponent<Interactable>());
		items[0].SetupObject ("magnifying glass");
	}
	
	public void AddInteractable(string item)
	{
		items.Add(gameObject.AddComponent<Interactable>());
		items [items.OfType<Interactable> ().Count() - 1].SetupObject (item);
	}

	public void ListAll()
	{
		Debug.Log (items.Count ());
		textController.AppendMain ("You're inventory contains: ");
		for (int i = 0; i < items.Count(); i++) {
			textController.AppendMain (items[i].objectName);
		}
	}

}