using UnityEngine;
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
		AddInteractable ("fingerprint kit");
	}
	
	public void AddInteractable(string item)
	{
		items.Add(gameObject.AddComponent<Interactable>());
		items [items.OfType<Interactable> ().Count() - 1].SetupObject (item);
	}
	
	public bool HasItem(string item)
	{
		foreach(Interactable interactable in items)
		{
			if(interactable.objectName == item)
			{
				return true;
			}
		}
		return false;
	}

	public void ListAll()
	{
		Debug.Log (items.Count ());
		textController.AppendMain ("Your inventory contains: ");
		for (int i = 0; i < items.Count(); i++) {
			textController.AppendMain (items[i].objectName);
		}
	}
	
	public List<Interactable> GetObjects()
	{
		return items;
	}

	public void DeleteInteractable(Interactable item)
	{
		if(items.Contains(item))
		{
			items.Remove(item);
		}
	}

}
