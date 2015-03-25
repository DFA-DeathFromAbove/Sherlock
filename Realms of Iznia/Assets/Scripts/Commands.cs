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
		for(int i = 0; i < attacks.Length; i++)
		{
			if(attacks[i] != null)
			{
				if(attacks[i].Length >= input.Length)
				{
					if(attacks[i].Substring(0,input.Length) == input)
					{
						return attacks[i];
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

	public Monster FindMonster(string input)
	{
		if(maps.ActiveRoom().GetMonsters().Count > 0)
		{
			foreach(Monster monster in maps.ActiveRoom().GetMonsters())
			{
				if(monster.monsterName.Length >= input.Length)
				{
					if(monster.monsterName.Contains(input)) //TODO: change from contains to match only the start of the monsterName ('at' should not find 'rat' in 'black rat')
					{
						return monster;
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
	
	void InitiateCommands()
	{
		cardinals[0] = "north";
		cardinals[1] = "east";
		cardinals[2] = "south";
		cardinals[3] = "west";
		cardinals[4] = "up";
		cardinals[5] = "down";
		
		commands[0] = "look";
		commands[1] = "go";
		commands[2] = "get";
		commands[3] = "attack";
		commands[4] = "move";
		commands[5] = "yes";
		commands[6] = "no";
		commands[7] = "find";
		commands[8] = "forage";
		
		attacks[0] = "punch";
	}
}
