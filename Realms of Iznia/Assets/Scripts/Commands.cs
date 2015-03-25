using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Commands : MonoBehaviour {

	private TextController textController;
	private Maps maps;
	private string[] commands = new string[100];
	private string[] cardinals = new string[20];
	private string[] attacks = new string[30];
	
	// Use this for initialization
	void Awake()
	{
		maps = GameObject.Find ("Scripts").GetComponent<Maps>();
		textController = GameObject.Find ("Scripts").GetComponent<TextController>();
		InitiateCommands();
		Array.Sort(commands);
	}
	
	public string FindCommand(string input)
	{
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
	
//	public string FindObject(string input)
//	{
//		List<string> objects = new List<string>();
//		for(int i = 0; i < textController.GetMaps().ActiveRoom().roomObjects.Length; i++)
//		{
//			
//		}
//	}

	public NPC FindNPC(string input)
	{
		if(maps.ActiveRoom().GetNPCs().Count > 0)
		{
			foreach(NPC NPC in maps.ActiveRoom().GetNPCs())
			{
				if(NPC.npcName.Length >= input.Length)
				{
					if(NPC.npcName.Contains(input)) //TODO: change from contains to match only the start of the monsterName ('at' should not find 'rat' in 'black rat')
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
		if(input == "go" || input == "walk")
		{
			return "move";
		}
		if(input == "forage")
		{
			return "search";
		}
		if(input == "ask")
		{
			return "question";
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
	}
}
