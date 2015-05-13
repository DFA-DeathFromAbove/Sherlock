using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Commands : MonoBehaviour {

	private TextController textController;
	private Maps maps;
	private Inventory inventory;
	private string[] commands = new string[100];
	private string[] cardinals = new string[20];
	private string[] attacks = new string[30];
	
	// Use this for initialization
	void Awake()
	{
		maps = GameObject.Find ("Scripts").GetComponent<Maps>();
		textController = GameObject.Find ("Scripts").GetComponent<TextController>();
		inventory = textController.inventory;
		InitiateCommands();
		Array.Sort(commands);
	}
	
	public string FindCommand(string input)
	{
		input = FindSyn(input);
		for(int i = 0; i < cardinals.Length; i++)
		{
			if(cardinals[i] != null)
			{
				if(cardinals[i].Length >= input.Length)
				{
					if(cardinals[i].Substring(0,input.Length) == input)
					{
						return cardinals[i];
					}
				}
			}
		}
		for(int i = 0; i < commands.Length; i++)
		{
			if(commands[i] != null)
			{
				if(commands[i].Length >= input.Length)
				{
					if(commands[i].Substring(0,input.Length) == input)
					{
						return commands[i];
					}
				}
			}
		}
		return "Not Found";
	}
	
	public Interactable FindObject(string input)
	{
		if(maps.ActiveRoom().GetObjects().Count > 0)
		{
			foreach(Interactable item in maps.ActiveRoom().GetObjects())
			{
				if(item.objectName.Length >= input.Length)
				{
					if(item.objectName.ToLower().Contains(input)) //TODO: change from contains to match only the start of the monsterName ('at' should not find 'rat' in 'black rat')
					{
						return item;
					}
				}
			}
			return null;
		}
		else
		{
			return null;
		}
	}

	public Interactable FindInventory(string input)
	{
		inventory = textController.inventory;
		Debug.Log (inventory.GetObjects ());
		if (inventory.GetObjects ().Count > 0)
		{
			foreach (Interactable item in inventory.GetObjects())
			{
				if (item.objectName.Length >= input.Length)
				{
					if (item.objectName.ToLower ().Contains (input)) 
					{ //TODO: change from contains to match only the start of the monsterName ('at' should not find 'rat' in 'black rat')
						return item;
					}
				}
			}
			return null;
		} 
		else 
		{
			return null;
		}
	}

	public NPC FindNPC(string input)
	{
		if(maps.ActiveRoom().GetNPCs().Count > 0)
		{
			foreach(NPC npc in maps.ActiveRoom().GetNPCs())
			{
				if(npc.npcName.Length >= input.Length)
				{
					if(npc.npcName.ToLower().Contains(input)) //TODO: change from contains to match only the start of the monsterName ('at' should not find 'rat' in 'black rat')
					{
						return npc;
					}
				}
			}
			return null;
		}
		else
		{
			return null;
		}
	}
	
	public string FindSyn(string input)
	{
		input = input.ToLower();
		if(input == "go" || input == "walk")
		{
			return "move";
		}
		if(input == "forage")
		{
			return "search";
		}
		if(input == "ask" || input == "talk")
		{
			return "question";
		}
		else
		{
			return input;
		}
	}
	
	void InitiateCommands()
	{
		cardinals[0] = "north";
		cardinals[1] = "east";
		cardinals[2] = "south";
		cardinals[3] = "west";
		cardinals[4] = "up";
		cardinals[5] = "down";
		
		commands[0] = "look";
		commands[1] = "get";
		commands[2] = "question";
		commands[3] = "move";
		commands[4] = "yes";
		commands[5] = "no";
		commands[6] = "find";
		commands[7] = "use";
	}
}
